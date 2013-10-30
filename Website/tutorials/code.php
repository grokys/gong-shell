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
       
        <h1>Accessing the Windows Shell Namespace from Code</h1>

        <p>This tutorial will show you how to carry out some common operations
        on the windows namespace in Visual Studio 2005 using the Gong Solutions 
        Shell Library.</p>
        
        <h2>Creating a new project</h2>
        <p>Create a new Console Application in Visual Studio and add a 
        reference to the Gong Solutions Shell Library to your project.
        For more details, <a href="installing.php">click here</a>.</p>

        <h2>Iterating over the items in a Shell Folder</h2>
        <div class="codeblock">
using System;
using GongSolutions.Shell;

namespace ConsoleApplication1 {
    class Program {
        static void Main(string[] args) {
            ShellItem folder = new ShellItem(
                Environment.SpecialFolder.MyDocuments);

            foreach (ShellItem item in folder) {
                Console.WriteLine(item.FileSystemPath);
            } 
        } 
    } 
}        </div>
    </div>
</body>
</html>
