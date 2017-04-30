var request = require('request');
var fs = require('fs');

var srcFileName = '../../SimpleArmory/app/data/achievements.json';
var outputFilename = srcFileName;

// Parse in achievement from current json
console.log("Parsing achievements.json...");
var parsedJSON = require(srcFileName);

// Process ids that need info
var requests = 0;
var superCats = parsedJSON.supercats;
for(let supercat of superCats) {
  console.log(supercat.name);
  for(let cat of supercat.cats) {
    for(let zone of cat.zones) {
      for(let ach of zone.achs) {
        if (ach.newid) {
          console.log("  filling in data for " + ach.newid);

          // query for data
          requests++;
          request('https://us.api.battle.net/wow/achievement/' + ach.newid + '?locale=en_US&apikey=kwptv272nvrashj83xtxcdysghbkw6ep', function (error, response, body) {            
            if (!error && response.statusCode == 200) {

              var blizz = JSON.parse(body);
              
              ach.id = blizz.id.toString();
              ach.icon = blizz.icon;
              ach.obtainable = true;
	            ach.points = blizz.points;

              if (blizz.factionId === 0) {
                ach.side = "A";
              }
              else if (blizz.factionId === 1) {
                ach.side = "H";
              }
              else {
                ach.side = "";
              }
               
              // Mark as to be filled in later
              if (blizz.criteria && blizz.criteria.length > 0) {
                ach.criteriaNeeded = true;
              }
            }
            else {
            	console.log("Trouble getting from blizzard. code: " + response.statusCode);
              console.log("  " + response.body);
            }

            requests--;
            if (requests === 0) {
              writeFile();
            }
          });

          // once done, delete the old placeholder
	        delete ach.newid;
        }        
      }
    }
  }  
}

function writeFile() {
  // Write results back out
  console.log("Writing achievements.json...");
  fs.writeFile(outputFilename, JSON.stringify(parsedJSON, null, 2), function(err) {
    if(err) {
      console.log(err);
    }
  }); 
}
