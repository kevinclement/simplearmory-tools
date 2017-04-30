var request = require('request');
var fs = require('fs');

var srcFileName = '../../SimpleArmory/app/data/achievements.json';
var outputFilename = srcFileName;

var blizzardLegionDung = {
  "10780":false,
  "10783":false,
  "10786":false,
  "10795":false,
  "10798":false,
  "10801":false,
  "10804":false,
  "10807":false,
  "10813":false,
  "10816":false,
  "11183":false,
  "11181":false,
  "10456":false,
  "10457":false,
  "10458":false,
  "10766":false,
  "10769":false,
  "10996":false,
  "10875":false,
  "10544":false,
  "10542":false,
  "10543":false,
  "10554":false,
  "10553":false,
  "10679":false,
  "10680":false,
  "10707":false,
  "10709":false,
  "10710":false,
  "10711":false,
  "10413":false,
  "10411":false,
  "10412":false,
  "10776":false,
  "10775":false,
  "10773":false,
  "10610":false,
  "10611":false
}

// Parse in achievement from current json
console.log("Parsing achievements.json...");
var parsedJSON = require(srcFileName);

var myLegionDung = 0;
var cmCount = 0;
var superCats = parsedJSON.supercats;
for(let supercat of superCats) {  

  if (supercat.name === "Dungeons & Raids") {

    for(let cat of supercat.cats) {

      if (cat.name === "Legion Dungeon") {
        for(let zone of cat.zones) {

          for(let ach of zone.achs) {
            console.log("ld: " + ach.id);
            myLegionDung++

            blizzardLegionDung[ach.id] = true;
          }
        }
      }      
    }  
  }    

  if (supercat.name === "Legacy") {

    for(let cat of supercat.cats) {

      if (cat.name === "Legacy") {
        for(let zone of cat.zones) {

          if (zone.name === "Challenge Mode")
          for(let ach of zone.achs) {
            console.log("cm: " + ach.id);
            cmCount++;

            //blizzardLegionDung[ach.id] = true;
          }
        }
      }      
    }  
  }
}

console.log("Legion Dungeon: " + myLegionDung);
console.log("CM: " + cmCount);
console.log(blizzardLegionDung);
