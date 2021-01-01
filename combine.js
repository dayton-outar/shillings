const fs = require('fs');
// ---
var wget = require('wget');
var file = 'pages-1609516736.json';

const src = file[0].url;
var output = '/tmp/data.json';
var options = {
    proxy: 'http://host:port'
};


var req = wget.request(options, function(res) {
    var content = '';
    if (res.statusCode === 200) {
        res.on('error', function(err) {
            console.log(err);
        });
        res.on('data', function(chunk) {
            content += chunk;
        });
        res.on('end', function() {
            console.log(content);
        });
    } else {
        console.log('Server respond ' + res.statusCode);
    }
});