const express = require("express");
const app = express();
const port = 2302;


var Products =require('./Products');

var databaseOperation = require('./databaseOperation');

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
    console.log(`Example app listening at http://localhost:${port}`);
  });