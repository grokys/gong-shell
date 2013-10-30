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
       
        <h1>Creating a Simple Windows Explorer Clone</h1>

        <p>This tutorial will guide you through creating a simple clone
        of Windows Explorer in Visual Studio 2005 using the Gong Solutions 
        Shell Library.</p>
        
        <h2>Step 1: Create a new project</h2>
        <p>Create a new Windows Application in Visual Studio and add a 
        reference to the Gong Solutions Shell Library to your project.
        For more details, <a href="installing.php">click here</a>.</p>

        <h2>Step 2: Add some controls</h2>
        <ul>
            <li>Add a Windows Forms <span class="component">SplitContainer
            </span>control.</li>
            <li>Add a <span class="component">ShellTreeView</span> control 
            to the left-hand pane of the <span class="component">
            SplitContainer</span> and set its <span class="code">Dock</span> 
            property to <span class="code">Fill.</span></li>
            <li>Add a <span class="component">ShellView</span> control 
            to the left-hand pane of the <span class="component">
            SplitContainer</span> and set its <span class="code">Dock</span> 
            property to <span class="code">Fill.</span></li>
        </ul>
        
        <p>You form should look like this:</p>
        <img src="images/explorer1.png" alt="screenshot" />

        <h2>Step 3: Link the Controls</h2>
        
        <p>Set the <span class="code">ShellView</span> property of 
        the <span class="component">ShellTreeView</span> to reference the 
        <span class="component">ShellView</span> control on the form.</p>

        <h2>Step 4: Run the Program</h2>
        
        <p>Press F5 to run the program, and you will be able to 
        browse your computer's files from your newly created 
        application, as simple as that!</p>
        
        <h2>That's All For Now</h2>
        
        <p>You've come to the end of this tutorial. If you want to learn
        more, then take a look at the ShellExplorer example that comes with
        the Gong Solutions Shell Library.</p>
    </div>
</body>
</html>
