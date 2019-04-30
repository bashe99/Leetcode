const fs = require('fs');
let data = fs.readFile("two-sum.js", (err, data) => {
    if(err) {
        return;
    }

    console.log(data);
});

