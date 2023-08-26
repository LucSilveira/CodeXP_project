import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

var container = Container( // grey box
  child: Center(
    child: Container( // red box
      child: Text(
        "Lorem ipsum",
        // style: bold24Roboto,
      ),
      decoration: BoxDecoration(
        color: Colors.red[400],
      ),
      padding: EdgeInsets.all(16),
      width: 240, //max-width is 240
    ),
  ),
  width: 320, 
  height: 240,
  color: Colors.grey[300],
);