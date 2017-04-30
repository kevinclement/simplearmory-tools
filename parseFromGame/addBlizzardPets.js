var myPets = require('../../web/app/data/pets.json');
var blizzardMounts = require('./blizzardPets.7.1.5.json');
var request = require('request');
var fs = require('fs');
var wait = require('wait.for');
var RateLimiter = require('limiter').RateLimiter;

var outputFilename = './output/Pets.added.json';
var limiter = new RateLimiter(1, 1000);

// https://us.api.battle.net/wow/pet/?locale=en_US&apikey=kwptv272nvrashj83xtxcdysghbkw6ep

// README:
//   Steps I did when 7.1.5 came output
//     went to above url and grabbed json, saved it to blizzardPets.7.1.5.json

var notFound = [];
var totalMine = 0;
var totalTheirs = 0;

// known pets that are not in the game but still show up
var knownMissing = {
//    '17458':true, // 
}

function main() {
    
    // build up a hashtable of all of my pets
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
	
    // for (var key in blizzardMounts.mounts) {
    //     var mount = blizzardMounts.mounts[key];

    //     totalTheirs++;

    //     if (!allMounts[mount.spellId] && !knownMissing[mount.spellId])
    //     {
    //         console.log('NOT FOUND: s:' + mount.spellId + ' i:' + mount.itemId + '- ' + mount.name);
    //         notFound.push(mount);
    //     }
    // }

    console.log();
    console.log('mine: ' + totalMine + ' theirs: ' + totalTheirs + ' not found: ' + notFound.length);
    console.log();
	
    writeToFile(notFound);
};

// Main wait section
wait.launchFiber(main);

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

    fs.writeFile(outputFilename, myStr, function(err) {
	    if(err) {
	      console.log(err);
	    } else {
	      console.log("JSON saved to " + outputFilename);
	    }
    }); 
}