<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Gong Solutions Shell Library</title>
    <link href="../default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <?php include '../navigation.html';?>
    
    <div id="content">
        <center><img src="../images/gong-logo.png" alt="Gong Solutions Logo" /></center>
        <br />
       
        <h1>Installing the Gong Solutions Shell Library</h1>
        <p>The Gong Solutions Shell library does not currently install itself
        into the GAC - that will come with version 1.0. For the moment, 
        follow these steps to use the library in your code from Visual Studio
        2005:</p>
        
        <ul>
            <li>Download the binary distribution.</li>
            <li>Extract the GongShell.dll and GongShell.xml files to a folder 
            on your computer.</li>
            <li>Create a new Windows or Console Application.</li>
            <li>Right-click on the application's References node in the
            Solution Explorer and select Add Reference.</li>
            <li>Select the Browse tab and browse to the GongShell.dll file
            you extracted earlier.</li>
        </ul>
    </div>
</body>
</html>
