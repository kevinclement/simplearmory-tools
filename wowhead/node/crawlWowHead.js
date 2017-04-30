var request = require('request');
var fs = require('fs');

var outputFilename = './tmp.json';

var URLs = 
[
  { name: "general",            url: "general?filter=17;1;60203" },
  { name: "reputation: top",    url: "reputation?filter=17;1;60203" },
  { name: "reputation: legion", url: "reputation/legion?filter=17;1;60203" }
];

console.log("Crawling wowhead for achievements...\n");
for (let url of URLs) 
{
  console.log("Crawling " + url.name + "...");

  // http://www.wowhead.com/achievements/character-achievements/general?filter=17;1;60203
  request('http://www.wowhead.com/achievements/character-achievements/' + url.url, function (error, response, body) {
    if (!error && response.statusCode == 200) {

        // criteria mapping
        var myRegexp = /id: 'achievements', data: (\[.*\])/g;
        var match = myRegexp.exec(body);

        var data = JSON.parse(match[1]);

        // You should end up with a json like
        // [{
        //    "category": 15258,
        //    "description": "Earn Revered with all of the Broken Isles reputations listed below.",
        //    "id": 10672,
        //    "name": "Broken Isles Diplomat",
        //    "parentcat": 201,
        //    "points": 10,
        //    "side": 3,
        //    "type": 1
        // }]       

        console.log("");
        console.log(url.name + "[" + data.length + "]");
        for(let achievement of data) {
          
          console.log("  id: " + achievement.id);
          console.log(JSON.stringify(achievement), null, 2); 
        }

        // 	fs.writeFile(outputFilename, JSON.stringify(criteriaJSON, null, 2), function(err) {
        // 	     if(err) {
        // 	       console.log(err);
        // 	     } else {
        // 	       console.log("JSON saved to " + outputFilename);
        // 	     }
        // 	}); 
      
      }
      else {
        console.log("Trouble getting javascript. code: " + response.statusCode);
        console.log("  " + response.body);
      }
  });
}


