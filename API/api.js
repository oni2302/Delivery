const express = require("express");
var bodyParser = require('body-parser');
const app = express();
const port = 2302;
app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json())
var Products = require('./Products');
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

  app.post("/nvgh/dangnhap", (request,response) =>{
    console.log(request.body)
    databaseOperation.dangnhapshiper(request.body.username,request.body.password).then(result=>{
      response.json(result);
    })
  });

  app.listen(port, () => {
    console.log(`Example app listening at http://localhost:${port}`);
  });