var parsedJSON = require('./tmp/Achievements.json');
var parsedWowheadJSON = require('./output/criteria.json');
var request = require('request');
var fs = require('fs');
var wait = require('wait.for');
var RateLimiter = require('limiter').RateLimiter;

var outputFilename = './output/Achievements.fixed.json';
var limiter = new RateLimiter(1, 1000);

// https://us.api.battle.net/wow/achievement/2144?locale=en_US&apikey=kwptv272nvrashj83xtxcdysghbkw6ep

function main() {

	//var superCatsToFix = [10,11,12,13];
	var loops = 0;

	console.log("Total to fix: " + parsedJSON.supercats.length);
	for (var key in parsedJSON.supercats) {
		var supercat = parsedJSON.supercats[key];

		//if (superCatsToFix.indexOf(loops) >= 0)
		//{
			for (var k2 in supercat.cats) {
				var cat = supercat.cats[k2];

				for (var k3 in cat.zones) {
					var zone = cat.zones[k3];
				
					for (var k4 in zone.achs) {
						var ach = zone.achs[k4];

						if (ach.criteria && Object.keys(ach.criteria).length == 0) {
							wait.for(checkAch, ach);
						}						
					}
				}
			}
		//}
		//else {
		//	console.log("Ignoring: " + supercat.name);
		//}

		loops++;
	}  

	writeToFile();
};

// Main wait section
wait.launchFiber(main);

function writeToFile() {
	console.log();

	fs.writeFile(outputFilename, JSON.stringify(parsedJSON, null, 2), function(err) {
	    if(err) {
	      console.log(err);
	    } else {
	      console.log("JSON saved to " + outputFilename);
	    }
	}); 
}

function checkAch(ach, cb) {

	// limit the number of requests we're doing
	limiter.removeTokens(1, function() {

		console.log("Checking ach '" + ach.id + "'...");

	  	request('https://us.api.battle.net/wow/achievement/' + ach.id + '?locale=en_US&apikey=kwptv272nvrashj83xtxcdysghbkw6ep', function (error, response, body) {
	  		if (!error && response.statusCode == 200) {
	  	  		var fetchedAch = JSON.parse(body);
	  	    	if (fetchedAch.criteria && fetchedAch.criteria.length > 1) {

	  	    		// add criteria
	  	    		ach.criteria = {};

	  	    		var achObj = parsedWowheadJSON[ach.id];  	    		 	    			
    			    for(var wowheadId in achObj) {
    				    if(achObj.hasOwnProperty(wowheadId)) {
    				    	var wowArray = achObj[wowheadId];
    				   
    				        wowArray.forEach(function(blizArray) {
    				          var blizId = blizArray[1];
    				          ach.criteria[blizId] = wowheadId;
    				        });
    				    }
    				}

    				console.log("  updated " + ach.id);
	  	    	}
	  	  	}
	  	  	else {
	  	  		console.log("Trouble processing " + ach.id);
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