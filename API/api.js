const express = require("express");
const app = express();
const port = 2302;

var Products = require('./Products');
var extenalip = require('externalip').getip;
var databaseOperation = require('./databaseOperation');

extenalip(function (err, ip) {
  console.log(ip); // => 8.8.8.8
});

app.get("/alo", (req, res) => {
    databaseOperation.getOrders().then(result =>{
        res.json(result);
        console.log("a");
    })
  });
  app.get("/dangnhap/", (req, res) => {
    databaseOperation.dangnhap(req.query.user,req.query.pass).then(result =>{
        res.json(result);
    })
  });

  app.listen(port, () => {
    console.log(`Example app listening at http://${IP}:${port}`);
  });