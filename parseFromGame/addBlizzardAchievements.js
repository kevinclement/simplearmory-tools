var myAchievements = require('./tmp/Achievements.json');
var blizzardAchievements = require('./blizzardAchievements.7.1.5.json');
var request = require('request');
var fs = require('fs');
var wait = require('wait.for');
var RateLimiter = require('limiter').RateLimiter;

var outputFilename = './output/Achievements.added.json';
var limiter = new RateLimiter(1, 1000);

// https://us.api.battle.net/wow/data/character/achievements?locale=en_US&apikey=kwptv272nvrashj83xtxcdysghbkw6ep

// README:
//   Steps I did when 7.1.5 came output
//     went to above url and grabbed json, saved it to blizzardAchievements.7.1.5.json
//     ran tool to compare against my live version
//     copied out of Achievements.added.json into my live version
//     ran fetchWowheadAchivements.js to get criteria json
//     ran updateAchievementsForCriteria to account for new items
//     removed the remainder of criteria from json by hand/find&replace

var notFound = [];
var totalMine = 0;
var totalTheirs = 0;

// known achievements that are not in the game but still show up
var knownMissing = {
    '7268':true,
    '7269':true,
    '7270':true,
    '8812':true, // You're Really Doing It Wrong (Level 90) - this one might actually be in game
}

function main() {
    
    // build up a hashtable of all of my achievements
    var allAchievements = {};
    for (var key in myAchievements.supercats) {
	 	var supercat = myAchievements.supercats[key];

        for (var k2 in supercat.cats) {
            var cat = supercat.cats[k2];

            for (var k3 in cat.zones) {
                var zone = cat.zones[k3];
            
                for (var k4 in zone.achs) {
                    var ach = zone.achs[k4];
                    allAchievements[ach.id] = ach; 
                    totalMine++;
                }
            }
        }
    }

	console.log("Total categories to check: " + blizzardAchievements.achievements.length);
    for (var key in blizzardAchievements.achievements) {
        var supercat = blizzardAchievements.achievements[key];

        //console.log('Looking at \'' + supercat.name + '\'');        
        
        // categories
        for (var c1 in supercat.categories) {
            var cat = supercat.categories[c1];
            
            //console.log('  ' + cat.name);

            for (var a1 in cat.achievements) { 
                var ach = cat.achievements[a1];

                checkAch(ach, allAchievements);
            }
        }

        // top level achievements
        //console.log('  Achievements:');        
        for (var a1 in supercat.achievements) { 
            var ach = supercat.achievements[a1];

            checkAch(ach, allAchievements);
        }
    }	  

    console.log();
    console.log('mine: ' + totalMine + ' theirs: ' + totalTheirs + ' not found: ' + notFound.length);
    console.log();
	
    writeToFile(notFound);
};

// Main wait section
wait.launchFiber(main);

function checkAch(ach, allAchievements) {
    totalTheirs++;
    if (!allAchievements[ach.id] && !knownMissing[ach.id])
    {
        console.log('NOT FOUND: ' + ach.id + ' - ' + ach.title + '...');
        notFound.push(ach);
    }
}

function writeToFile(notFound) {
	console.log();

    var myStr = '';
    for (var nf in notFound) {
        var ach = notFound[nf];

        // format it properly for me
        var myAch = {
            'id': ach.id,
            'icon': ach.icon,
            'side': getFactionSymbol(ach.id, ach.factionId),
            'obtainable': true,
            'points': ach.points,
            'criteria': {}
        };

        myStr += JSON.stringify(myAch, null, 2) + '\n';
    }

	fs.writeFile(outputFilename, myStr, function(err) {
	     if(err) {
	       console.log(err);
	     } else {
	       console.log("JSON saved to " + outputFilename);
	     }
	}); 
}

function getFactionSymbol(id, factionId) {
    // 0 is alliance
    // 1 is horde
    // 2 is anyone
    if (factionId === 0) {
        return 'A';
    }
    else if (factionId === 1) { 
        return 'H';
    }
    else if (factionId === 2) {
        return '';
    }
    else {
        console.log('UNKNOWN FACTION: ' + factionId + ' for ' + id);
    }
}