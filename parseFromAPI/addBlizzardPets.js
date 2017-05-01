var request = require('request');
var fs = require('fs');
var wait = require('wait.for');
var RateLimiter = require('limiter').RateLimiter;

var outputFilename = './output/Pets.missing.txt';
var limiter = new RateLimiter(1, 300);
var blizzardAPI = 'https://us.api.battle.net/wow/pet/?locale=en_US&apikey=kwptv272nvrashj83xtxcdysghbkw6ep';

// README:
//   Steps I did when 7.2 came output
//     

// Pets that didn't show up from uber players, but I have in DB.  
// This is because these pets are super rare or regional
var knownMissing = {
    '15186':true,  // Murky
    '16456':true,  // Poley
    '23198':true,  // Lucky
    '27346':true,  // Competitor's Souvenir
    '35468':true,  // Onyx Panther
    '68502':true,  // Spectral Cub
    '114543':true, // Igneous Flameling (not out yet, summer time, when queried so uber player was missing it)
}

function main() {
    var { myBattlePets, myCompanions } = getPetsFromSimpleArmory();
    var { battlePets, companions } = getPetsFromUberPlayers(true);

    var missingCompanions = getMissingSiteCompanions(companions, myCompanions);
    var missingBattlePets = getMissingSiteBattlePets(battlePets, myBattlePets);
    var missingUnclassified = getMissingUnclassified(battlePets, companions);

    console.log();
    console.log('Missing companions:   (' + missingCompanions.length + '/' + companions.length + ')');
    console.log('Missing battlepets:   (' + missingBattlePets.length + '/' + battlePets.length + ')');
    console.log('Missing unclassified: (' + missingUnclassified.length + ')');

    writeToFile(missingCompanions, missingBattlePets, missingUnclassified);
};

// Main wait section
wait.launchFiber(main);

function getPetsFromSimpleArmory() {
    var myBattlePetsJson = require('../../simplearmory/web/app/data/battlepets.json');
    var myCompanionsJson = require('../../simplearmory/web/app/data/pets.json');

    // build up a hashtable of all of my battle pets
    var myBattlePets = {};
    for (var key in myBattlePetsJson) {
        var cat = myBattlePetsJson[key];

        for (var k2 in cat.subcats) {
            var subcat = cat.subcats[k2];

            for (var i in subcat.items) {
                var pet = subcat.items[i];
                myBattlePets[pet.creatureId] = pet;
             }
        }
    }

    // build up a hashtable of all of my pets
    var myCompanions = {};
    for (var key in myCompanionsJson) {
        var cat = myCompanionsJson[key];

        for (var k2 in cat.subcats) {
            var subcat = cat.subcats[k2];

            for (var i in subcat.items) {
                var pet = subcat.items[i];
                myCompanions[pet.spellid] = pet;
             }
        }
    }

    return { myBattlePets: myBattlePets, myCompanions: myCompanions };
}

function getPetsFromUberPlayers() {

    // NOTE: I couldn't use the blizzard API to get pets because it doesn't have all the info the site uses, or a way to get all the info
    //  I really need spellId, and itemId, and the blizzard api doesn't give you that, it only has creatureId, and speciesId
    //  I could use speciesId to query the api for species, but that only has ability info, not item or spell info
    //  However, when you ask the blizzard api for information about what pets a character has, it contains this info.  So I just went
    //  and found the top players and queried their info off there characters.
    //    curl "https://eu.api.battle.net/wow/character/die-nachtwache/Nyari?fields=pets&apikey=kwptv272nvrashj83xtxcdysghbkw6ep" | python -mjson.tool > cached\topPetPerson.horde.json
    //    curl "https://us.api.battle.net/wow/character/Stormrage/Kyran?fields=pets&apikey=kwptv272nvrashj83xtxcdysghbkw6ep" | python -mjson.tool > cached\topPetPerson.alliance.json
    var horde = require('./cached/topPetPerson.horde.json').pets.collected;
    var alliance = require('./cached/topPetPerson.alliance.json').pets.collected;
    var pets = [...horde, ...alliance];

    var visited = {}
    var battlePets = [];
    var companions = [];

    for(var pet of pets) {

        // Pet Object
        //    pet.creatureId - seems to be the unique id (speciesid is showing up as 0 for some pets)
        //    pet.creatureName
        //    pet.icon
        //    pet.itemId
        //    pet.spellId
        //    pet.stats.speciesId - can use blizzard api to look it up

        // if we've seen this creature just assert its the same one by checking icon
        if (visited[pet.creatureId] && visited[pet.creatureId].icon != pet.icon) {
            console.log("ASSERT: our assumption about unique creatureId is bad: " + pet.creatureId);
        }

        // only look at one version of the collected pet, since players can have 3, no need to look at all of them
        if (visited[pet.creatureId]) {
            continue;
        }
        else {
            visited[pet.creatureId] = pet;
        }

        // if a pet doesn't have a spellid and itemid, then its a battlepet you capture
        if (!pet.itemId && !pet.spellId) {
            // Used this to confirm that all the pets that didn't have itemIds and spellIds were battle pets
            //   wait.for(getSpeciesFromBlizzard, pet.stats.speciesId);

            battlePets.push(pet);
        }
        else {
            // if there isn't a item for this, we have to check if its a pet battle using the blizzard api
            if (pet.itemId == "0") {

                var isBattlePet = wait.for(getSpeciesFromBlizzard, pet.stats.speciesId);
                if (isBattlePet) {
                    battlePets.push(pet);
                }
                else {
                    companions.push(pet);
                }
            }
            else {
                companions.push(pet);
            }
        }
    }

    return { battlePets: battlePets, companions: companions};
}

function getMissingSiteBattlePets(battlePets, myBattlePets) {
    console.log('Finding missing battle pets...');

    var missing = [];
    for(var pet of battlePets) {
        if (!myBattlePets[pet.creatureId]) {
            missing.push(pet);
        }
    }

    return missing;
}

function getMissingSiteCompanions(companions, myCompanions) {
    console.log('Finding missing companions...');

    var missing = [];
    for(var pet of companions) {
        if (!myCompanions[pet.spellId]) {
            missing.push(pet);
        }
    }

    return missing;
}

function getMissingUnclassified(battlePets, companions) {
    console.log('Finding unclassified pets...');

    var blizzardPets = {}; // hash of pets and if they were found
    for(var pet of require('./cached/blizzardPets.7.2.json').pets) {
        blizzardPets[pet.creatureId] = {pet: pet, found: false};
    }

    for(var pet of [...battlePets, ...companions]) {
        // check for pets that aren't in blizzards system
        if (!blizzardPets[pet.creatureId]) {
            console.log('WARNING: missing pet from blizzard, species: ' + pet.stats.speciesId + ' creatureId: ' + pet.creatureId + ' icon: ' + pet.icon + ' spellId:' + pet.spellId);
            continue;
        } 

        // assert that we have unique creatureId
        if (blizzardPets[pet.creatureId].found) {
            console.error('ASSERT: assumed unique creature id but found ' + pet.creatureId + ' already.');
        }

         // mark that we found this pet in the master pet list
         blizzardPets[pet.creatureId].found = true;
    }

    // check which blizzard pets that our uber player didn't have at time of running (will need to handle by hand)
    var missing = [];
    for(var key of Object.keys(blizzardPets)) {
        var pet = blizzardPets[key].pet;
        if(!blizzardPets[key].found && !knownMissing[key]) {
            missing.push(pet);
        }
    }

    return missing;
}

function getSpeciesFromBlizzard(speciesId, cb) {
    // NOTE: to limit api calls: limiter.removeTokens(1, function() {

    request('https://us.api.battle.net/wow/pet/species/' + speciesId + '?locale=en_US&apikey=kwptv272nvrashj83xtxcdysghbkw6ep', (error, response, body) => {
        if (!error && response.statusCode == 200) {
            var blizzardSpeciesObj = JSON.parse(body);
            var source = blizzardSpeciesObj.source;
            var isBattlePet = source.startsWith("Pet Battle");

            cb(null, isBattlePet);
        }
        else {
            //console.log("\n  ERR: " + error);
            //if (response) {
            //    console.log("  CODE: " + response.statusCode);
            //    console.log("  BODY: " + response.body);	
            //}

            cb(error);
        }
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

function writeToFile(missingCompanions, missingBattlePets, missingUnclassified) {
    console.log();

    var myStr = '';

    myStr += 'Unclassified:\n';
    for(var pet of missingUnclassified) {
        myStr += '  http://www.wowhead.com/npc=' + pet.creatureId + '\n';
    }
    myStr += '\n';

    myStr += 'Companions:\n';
    for(var pet of missingCompanions) {

        // check to make sure pet has stuff we require
    //     if (!pet.spellId) {
    //         console.log('ERROR: pet doesn\'t have spellId: ' + pet.name);
    //     }
    //     if (!pet.itemId) {
    //         console.log('ERROR: pet doesn\'t have itemId: ' + pet.name);
    //     }
         if (!pet.icon) {
             console.log('  ERROR: mount doesn\'t have icon: ' + pet.name);
         }

        // TODO: how can I tell alliance vs horde, and races/classes?
        var myPet = {
            "spellid": pet.spellId,
            "allianceId": null,
            "hordeId": null,
            "itemId": pet.itemId,
            "icon": pet.icon,
            "obtainable": true,
            "allowableRaces": [],
            "allowableClasses": null
        };
        
        myStr += 'http://www.wowhead.com/npc=' + pet.creatureId + '\n';
        var tmpP = `{"spellid": ${pet.spellId},"allianceId": null,"hordeId": null,"itemId": ${pet.itemId},"icon": ${pet.icon},"obtainable": true,"allowableRaces": [],"allowableClasses": null}`;

        //myStr += JSON.stringify(myPet, null, 2) + '\n';
        myStr += tmpP + '\n';
    }
    myStr += '\n';

    fs.writeFile(outputFilename, myStr, function(err) {
         if(err) {
           console.log(err);
         } else {
           console.log("Saved to " + outputFilename);
         }
    }); 
}