# Project Description 
这是一个很久以前写的测试框架了,已经很久没有更新了,很能很多东西已经不适用了.不过codeplex快要下线了，所以从codeplex迁移而来。

This is a key-word driver framework for selenium2. contains KDATFFS,KDATFFSRunner and KDATFFSRecorder. KDATFFSRunner allows user to ctreate automated tests using excel,Csv; KDATFFSRecorder allow user to record operation into excel,Csv.

# NEWS 

 KDATFFS v1.01  had released ,Download 
# Documentation

 KDATFFS Introduction  - Introduce the core of KDATFFS Framework.
 KDATFFSRecorder Introduction -  Introduce the usage of KDATFFSRecorder.
 KDATFFSRunner Introduction – Introduce the usage of KDATFDSRunner.
# Features

  KDATFFS

 ## Core for framework
Supports a majority of methods implemented in Selenium
  ## KDATFFSRecorder

* Record test step in embedded browser
*  Test steps be recorded to key words , not script, so more clear
*  Supports a majority of methods implemented in Selenium
*  Supports Add , Delete or Clear steps in recording
*   Supports Stop , Continue recording
*  Supports highlight selected element
*   Supports Add Verify point
* Supports Iframe , frame and popup windows
* Open-source freeware under GPL2, written in C#.NET 3.5
*  Import and Export excel , csv  files
## KDATFFSRunner

*  Run selected tests for your need
*  Stop running in safe
*  Supports ie and firefox browser,when in firefox ,can set proxy
*   Supports speed up or down
*   Check test execute status and log
*   Open-source freeware under GPL2, written in C#.NET 3.5
*    Import excel , csv  files
*   Supports Data Driver
## Example

  Create a test to search in codeplex

1.  You can record test steps in KDATFFSRecorder

1.   add a test name”Search” and Select it, Checked Record button,now begin recording

1.  Input Url, keydown ”Enter” or click Go button

1.   Click search input box,input “KDATFFS”, and click Search button.

1.  Finally,you can get follow test steps,export them.

You also create test steps in excel by yourself.

Detail of test step’s column, you can see User Guide.

2.       Run the test in KDATFFSRunner

1)       File->Open Excel File ,load tests ,checked tests that your need to test.

2)       Select browser type , speed ,click “Start “ button. Test beginning

3)       Finally , display test status  and test log.
