var myMounts = require('../../web/app/data/mounts.json');
// var blizzardMounts = require('./blizzardMounts.7.1.5.json');
// var request = require('request');
// var fs = require('fs');
// var wait = require('wait.for');
// var RateLimiter = require('limiter').RateLimiter;

// var outputFilename = './output/Mounts.added.json';
// var limiter = new RateLimiter(1, 1000);

// https://us.api.battle.net/wow/mount/?locale=en_US&apikey=kwptv272nvrashj83xtxcdysghbkw6ep

// README:
//   Steps I did when 7.1.5 came output
//     went to above url and grabbed json, saved it to blizzardMounts.7.1.5.json
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
    
};

