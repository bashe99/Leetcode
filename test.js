import {renderToString} from 'react-dom/server';
import MyComponent form './MyComponent';

app.get('/show', (req, res)=> {
    res.write('<!DOCTYPE html><html><head><title>My Page</title></head><body>');
    res.write('<div id="content">');
    res.write(renderToString(<MyComponent/>));
    res.write('</div></body></html>');
    res.end();
});