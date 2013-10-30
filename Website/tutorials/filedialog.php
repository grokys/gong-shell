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
       
        <h1>Creating a Simple File Dialog</h1>

        <p>This tutorial will guide you through creating a simple custom
        file dialog in Visual Studio 2005 using the Gong Solutions Shell 
        Library.</p>
        
        <h2>Step 1: Create a new project</h2>
        <p>Create a new Windows Application in Visual Studio and add a 
        reference to the Gong Solutions Shell Library to your project.
        For more details, <a href="installing.php">click here</a>.</p>

        <h2>Step 2: Add some controls</h2>
        <ul>
            <li>Add a <span class="component">FileDialogToolbar</span> control 
            to your form. It will automatically dock itself to the top of the 
            form.</li>
            <li>Add a <span class="component">ShellView</span> control to your 
            form. Set its <span class="code">Dock</span> property to 
            <span class="code">Fill.</span></li>
        </ul>
        
        <p>You form should look like this:</p>
        <img src="images/filedialog1.png" alt="screenshot" />

        <h2>Step 3: Link the Controls</h2>
        
        <p>Set the <span class="code">ShellView</span> property of 
        the <span class="component">FileDialogToolbar</span> to reference the 
        <span class="component">ShellView</span> control on the form.</p>

        <h2>Step 4: Run the Program</h2>
        
        <p>Press F5 to run the program, and you will be able to 
        browse your computer's files from your newly created 
        application, as simple as that!</p>

        <h2>Step 5: Add a File Name Text Box and a File Filter List</h2>
        
        <ul>
            <li>Add a new Panel to your form, and set its <span class="code">
            Dock</span> property to <span class="code">Bottom</span>. You may 
            need to right-click it and select "Send to Back" to make sure it 
            doesn't overlap your <span class="component">ShellView</span></li>
            <li>Add a <span class="component">FileNameComboBox</span> and a 
            <span class="component">FileFilterComboBox</span> to the 
            Panel</li>
            <li>Set the <span class="code">ShellView</span> property of 
            both these controls to reference the <span class="component">
            ShellView</span> control on the form.</li>
            <li>Set the <span class="code">FilterItems</span> property of 
            the <span class="component">FileFilterComboBox</span> to <span class="code">Text Files 
            (*.txt)|*.txt|All Files (*.*)|*.*</span></li>
            <li>Add some labels to make things look nicer.</li>
        </ul>

        <p>You form should now look something like this:</p>
        <img src="images/filedialog2.png" alt="screenshot" />

        <h2>Step 6: Run the Program</h2>
        
        <p>Press F5 to run the program again. You will now be able to 
        navigate folders by typing their name into the 
        <span class="component">FileNameComboBox</span> and filter the items 
        in the ShellView using the <span class="component">FileFilterComboBox
        </span>. The <span class="component">FileNameComboBox</span> will 
        even autocomplete filenames as you type!</p>

        <h2>Step 7: Add the Open button</h2>
        
        <ul>
            <li>Add a new Button to your form, and set its <span class="code">
            Text</span> property to <span class="code">Open</span>.
            <li>In the button's <span class="code">Clicked</span> event
            handler put the following code:
            <div class="codeblock">
private void button1_Click(object sender, EventArgs e) {
    if ((shellView1.SelectedItems.Length > 0) &&
        (!shellView1.NavigateSelectedFolder())) {
        MessageBox.Show(shellView1.SelectedItems[0].FileSystemPath);
    }
}
            </div>
            </li>
        </ul>
        
        <h2>That's All For Now</h2>
        
        <p>You've come to the end of this tutorial. If you want to learn
        more, then take a look at the FileDialog example that comes with
        the Gong Solutions Shell Library.</p>
    </div>
</body>
</html>
