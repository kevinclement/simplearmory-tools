var myMounts = require('../../simplearmory/web/app/data/mounts.json');
var blizzardMounts = require('./blizzardMounts.7.2.json');
var request = require('request');
var fs = require('fs');
var wait = require('wait.for');
var RateLimiter = require('limiter').RateLimiter;

var outputFilename = './output/Mounts.added.json';
var limiter = new RateLimiter(1, 1000);

// https://us.api.battle.net/wow/mount/?locale=en_US&apikey=kwptv272nvrashj83xtxcdysghbkw6ep
// README:
//   Steps I did when 7.2 came output
//     curl "https://us.api.battle.net/wow/mount/?locale=en_US&apikey=kwptv272nvrashj83xtxcdysghbkw6ep" | python -mjson.tool > blizzardMounts.7.2.json
//     ran tool to compare against my live version
//     copied out of Mounts.added.json into my live version, checking wowhead for their source and limitations

var notFound = [];
var totalMine = 0;
var totalTheirs = 0;

// known mounts that are not in the game but still show up
var knownMissing = {
    '17458':true, // Fluorescent Green Mechanostrider - only give to one player on accident
    '147595':true, // Stormcrow - unknown origin yet in game
    '127178':true, // Jungle Riding Crane - mop mounts never available
    '127180':true, // Albino Riding Crane - mop mounts never available
    '127213':true, // Black Riding Yak - mop mounts never available
    '123160':true, // Brown Riding Yak - mop mounts never available
    '123160':true, // Crimson Riding Crane - mop mounts never available
    '127272':true, // Orange Water Strider - mop mounts never available
    '127274':true, // Jade Water Strider - mop mounts never available
    '123182':true, // White Riding Yak - mop mounts never available
    '127278':true, // Golden Water Strider - mop mounts never available
    '127209':true, // Black Riding Yak - mop mounts never available
    '215545':true, // Fel Bat (Test)
    '10788':true,  // Leopard - Alpha only mount
    '10790':true,  // Tiger - Alpha only mount
    '171618':true, // Ancient Leatherhide - unknown
    '48954':true   // Old Swift Zhevra 
}

function main() {
    
    // build up a hashtable of all of my mounts
    var allMounts = {};
    for (var key in myMounts) {
	 	var cat = myMounts[key];

        for (var k2 in cat.subcats) {
            var subcat = cat.subcats[k2];

            for (var i in subcat.items) {
                var mount = subcat.items[i];
                
                allMounts[mount.spellid] = mount;
                totalMine++;
             }
        }
    }
	
    for (var key in blizzardMounts.mounts) {
        var mount = blizzardMounts.mounts[key];

        totalTheirs++;

        if (!allMounts[mount.spellId] && !knownMissing[mount.spellId])
        {
            console.log('NOT FOUND: s:' + mount.spellId + ' i:' + mount.itemId + '- ' + mount.name);
            notFound.push(mount);
        }
    }

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
    for (var nf in notFound) {
        var mount = notFound[nf];

        // check to make sure mount has stuff we require
        if (!mount.spellId) {
            console.log('ERROR: mount doesn\'t have spellId: ' + mount.name);
        }
        if (!mount.itemId) {
            console.log('ERROR: mount doesn\'t have itemId: ' + mount.name);
        }
        if (!mount.icon) {
            console.log('ERROR: mount doesn\'t have icon: ' + mount.name);
        }

        // format it properly for me
        var myMount = {
            'spellid': mount.spellId,
            'allianceId': null,
            'hordeId': null,
            'itemId': mount.itemId,
            'icon': mount.icon,
            'obtainable': true,
            'allowableRaces': [],
            'allowableClasses': null
        };

        myStr += JSON.stringify(myMount, null, 2) + '\n';
    }

	fs.writeFile(outputFilename, myStr, function(err) {
	     if(err) {
	       console.log(err);
	     } else {
	       console.log("JSON saved to " + outputFilename);
	     }
	}); 
}