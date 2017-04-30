var request = require('request');
var fs = require('fs');
var wait = require('wait.for');
var RateLimiter = require('limiter').RateLimiter;

var outputFilename = './output/Pets.added.json';
var limiter = new RateLimiter(1, 300);
var blizzardAPI = 'https://us.api.battle.net/wow/pet/?locale=en_US&apikey=kwptv272nvrashj83xtxcdysghbkw6ep';

// README:
//   Steps I did when 7.2 came output

var notFound = [];
var totalMine = 0;
var totalTheirs = 0;

// known pets that are not in the game but still show up
var knownMissing = {
    
}

function main() {

    var { battlePets, companions } = getPetsFromUberPlayer(true);

    console.log('Looking for missing pets...');
    var missingPets = findMissingPets(battlePets, companions);

    for(var pet of missingPets) {
        console.log('Missing pet: http://www.wowhead.com/npc=' + pet.creatureId);
    }

    // Now tha twe know our data set of all known pets, lets search site for what we're missing
    var missingCompanions = getMissingSiteCompanions(companions);
    var missingBattlePets = getMissingSiteBattlePets(battlePets);

    // hypo: blizzard api creatureId and speciesId are unique
    // todo: when done, loop through all the ones that comes out of pets blizzard api to see what speciesid is missing

    console.log();
    console.log('Missing companions: (' + missingCompanions.length + '/' + companions.length + ')');
    console.log('Missing battlepets: (' + missingBattlePets.length + '/' + battlePets.length + ')');
    console.log();

    writeToFile(notFound);
};

// Main wait section
wait.launchFiber(main);

function getPetsFromUberPlayer(useCache) {

    // NOTE: I couldn't use the blizzard API to get pets because it doesn't have all the info the site uses, or a way to get all the info
    //  I really need spellId, and itemId, and the blizzard api doesn't give you that, it only has creatureId, and speciesId
    //  I could use speciesId to query the api for species, but that only has ability info, not item or spell info
    //  However, when you ask the blizzard api for information about what pets a character has, it contains this info.  So I just went
    //  and found the top players and queried their info off there characters.

    var pets = [];
    if (useCache) {

        // curl "https://eu.api.battle.net/wow/character/die-nachtwache/Nyari?fields=pets&apikey=kwptv272nvrashj83xtxcdysghbkw6ep" | python -mjson.tool > cached\topPetPerson.horde.json
        var horde = require('./cached/topPetPerson.horde.json').pets.collected;

        // curl "https://us.api.battle.net/wow/character/Stormrage/Kyran?fields=pets&apikey=kwptv272nvrashj83xtxcdysghbkw6ep" | python -mjson.tool > cached\topPetPerson.alliance.json
        var alliance = require('./cached/topPetPerson.alliance.json').pets.collected;

        pets = [...horde, ...alliance];
    }


    var visited = {}
    var battlePets = [];
    var companions = [];

    for(var pet of pets) {

        // Pet Object
        //    pet.creatureId
        //    pet.creatureName
        //    pet.icon
        //    pet.itemId
        //    pet.spellId
        //    pet.stats.speciesId - can use blizzard api to look it up

        // only look at one version of the collected pet, since players can have 3, no need to look at all of them
        if (visited[pet.stats.speciesId]) {
            continue;
        }
        else {
            visited[pet.stats.speciesId] = true;
        }

        // if a pet doesn't have a spellid and itemid, then its a battlepet you capture
        if (!pet.itemId && !pet.spellId) {
            // Used this to confirm that all the pets that didn't have itemIds and spellIds were battle pets
            //   wait.for(getSpeciesFromBlizzard, pet.stats.speciesId);

            battlePets.push(pet);
        }
        else {
            companions.push(pet);
        }
    }

    return { battlePets: battlePets, companions: companions};
}

function getMissingSiteBattlePets(battlePets) {
    var myPets = require('../../simplearmory/web/app/data/battlepets.json');

    // build up a hashtable of all of my pets
    console.log('Finding missing battle pets...');
    var allPets = {};
    for (var key in myPets) {
        var cat = myPets[key];

        for (var k2 in cat.subcats) {
            var subcat = cat.subcats[k2];

            for (var i in subcat.items) {
                var pet = subcat.items[i];
                
                allPets[pet.creatureId] = pet;
                totalMine++;
             }
        }
    }

    var missing = [];
    for(var pet of battlePets) {
        if (!allPets[pet.creatureId]) {
            missing.push(pet);
        }
    }

    return missing;
}

function getMissingSiteCompanions(companions) {
    var myPets = require('../../simplearmory/web/app/data/pets.json');

    // build up a hashtable of all of my pets
    console.log('Finding missing companions...');
    var allPets = {};
    for (var key in myPets) {
        var cat = myPets[key];

        for (var k2 in cat.subcats) {
            var subcat = cat.subcats[k2];

            for (var i in subcat.items) {
                var pet = subcat.items[i];
                
                allPets[pet.spellid] = pet;
                totalMine++;
             }
        }
    }

    var missing = [];
    for(var pet of companions) {
        if (!allPets[pet.spellId]) {
            missing.push(pet);
        }
    }

    return missing;
}

function findMissingPets(battlePets, companions) {
    var blizzardPets = {}; // hash of pets and if they were found
    for(var pet of require('./cached/blizzardPets.7.2.json').pets) {
        blizzardPets[pet.stats.speciesId] = {pet: pet, found: false};
    }

    for(var pet of [...battlePets, ...companions]) {
        // check for pets that aren't in blizzards system
        if (!blizzardPets[pet.stats.speciesId]) {
            // TODO: handle this outside this function?
            console.log('WARNING: missing pet from blizzard, species: ' + pet.stats.speciesId + ' creatureId: ' + pet.creatureId + ' icon: ' + pet.icon + ' spellId:' + pet.spellId);
            continue;
        } 

        // assert that we have unique speciesId
        if (blizzardPets[pet.stats.speciesId].found) {
            console.error('ASSERT: assumed unique species id but found ' + pet.stats.speciesId + ' already.');
        }

         // mark that we found this pet in the master pet list
         blizzardPets[pet.stats.speciesId].found = true;
    }

    // check which blizzard pets that our uber player didn't have at time of running (will need to handle by hand)
    var missing = [];
    for(var key of Object.keys(blizzardPets)) {
        if(!blizzardPets[key].found  && !knownMissing[key]) {
            missing.push(blizzardPets[key].pet);
        }
    }

    return missing;
}

function getSpeciesFromBlizzard(speciesId, cb) {
    var nonBattlePets = [];

    limiter.removeTokens(1, function() {
        request('https://us.api.battle.net/wow/pet/species/' + speciesId + '?locale=en_US&apikey=kwptv272nvrashj83xtxcdysghbkw6ep', (error, response, body) => {
            process.stdout.write("Got species info for '" + speciesId + "'...");
            if (!error && response.statusCode == 200) {
                var blizzardSpeciesObj = JSON.parse(body);
                var source = blizzardSpeciesObj.source;

                var isPetBattlePet = source.startsWith("Pet Battle");
                if (!isPetBattlePet) {
                    nonBattlePets.push(speciesId);
                }
                console.log(isPetBattlePet);
            }
            else {
                console.log("  ERR: " + error);
                if (response) {
                    console.log("  CODE: " + response.statusCode);
                    console.log("  BODY: " + response.body);	
                }
            }

            cb();
        });
    });
}

function getPetsFromBlizzard() {
    // get json from blizzard
    console.log('Getting pets from blizzard...');
    request(blizzardAPI, (error, response, body) => {
        if (error) console.log(error);
        else {
            var blizzardPetsObj = JSON.parse(body);
            var blizzardPets = blizzardPetsObj.pets;
            console.log('  found ' + blizzardPets.length + ' pets.');

            fs.writeFile(outputFilename, JSON.stringify(blizzardPetsObj, null, 2), function(err) {
                if(err) {
                    console.log(err);
                } else {
                    console.log("JSON saved to " + outputFilename);
                }
            }); 
        }
    });
}

function writeToFile(notFound) {
	console.log();

    var myStr = '';
    // for (var nf in notFound) {
    //     var mount = notFound[nf];

    //     // check to make sure mount has stuff we require
    //     if (!mount.spellId) {
    //         console.log('ERROR: mount doesn\'t have spellId: ' + mount.name);
    //     }
    //     if (!mount.itemId) {
    //         console.log('ERROR: mount doesn\'t have itemId: ' + mount.name);
    //     }
    //     if (!mount.icon) {
    //         console.log('ERROR: mount doesn\'t have icon: ' + mount.name);
    //     }

    //     // format it properly for me
    //     var myMount = {
    //         'spellid': mount.spellId,
    //         'allianceId': null,
    //         'hordeId': null,
    //         'itemId': mount.itemId,
    //         'icon': mount.icon,
    //         'obtainable': true,
    //         'allowableRaces': [],
    //         'allowableClasses': null
    //     };

    //     myStr += JSON.stringify(myMount, null, 2) + '\n';
    // }

    // fs.writeFile(outputFilename, myStr, function(err) {
	//     if(err) {
	//       console.log(err);
	//     } else {
	//       console.log("JSON saved to " + outputFilename);
	//     }
    // }); 
}