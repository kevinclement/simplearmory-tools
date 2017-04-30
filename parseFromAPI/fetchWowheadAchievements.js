var request = require('request');
var fs = require('fs');

var outputFilename = './output/criteria.json';

console.log("Getting Achievements javascript from wowhead...");

request('http://www.wowhead.com/data=achievements', function (error, response, body) {
	if (!error && response.statusCode == 200) {

  		// criteria mapping
  		var myRegexp = /g_achievement_criteria = (.*);/g;
  		var match = myRegexp.exec(body);

      // You should end up with a json like
      // { 
      //   "achievementId" : 
      //   {
      //      "wowheadId": 
      //        [
      //          [
      //            count,
      //            criteriaId
      //          ]
      //        ]
      //   }
      // }
      var criteriaJSON = JSON.parse(match[1]);
    
      for(var achId in criteriaJSON) {
        if(criteriaJSON.hasOwnProperty(achId)) {

          var achObj = criteriaJSON[achId];

          // console.log("found: " + achId);
          for(var wowheadId in achObj) {
            if(achObj.hasOwnProperty(wowheadId)) {

              var wowArray = achObj[wowheadId];
           
              // if (wowArray.length !== 1) {
              //   console.log("ERROR: found criteria '" + wowheadId + "'' for achievement '" + achId + "' had wrong size " + wowArray.length);
              // }

              wowArray.forEach(function(blizArray) {
                if (blizArray.length > 2) {
                  console.log("ERROR: unexpected blizzard array size " + blizArray.length + " for achievement " + achId);
                }

                wowArray.forEach(function(blizArray) {
                  var blizId = blizArray[1];
                  console.log(blizId + " => " + wowheadId);                  
                });
              });

              // console.log("  wowhead: " + wowheadId + " : " + wowArray.length);
            }
          }         
        }
      }

  		fs.writeFile(outputFilename, JSON.stringify(criteriaJSON, null, 2), function(err) {
  		     if(err) {
  		       console.log(err);
  		     } else {
  		       console.log("JSON saved to " + outputFilename);
  		     }
  		}); 
		
  	}
  	else {
  		console.log("Trouble getting javascript. code: " + response.statusCode);
  		console.log("  " + response.body);
  	}
});