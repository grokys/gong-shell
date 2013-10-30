namespace ShellExplorer {
    partial class ShellExplorer {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShellExplorer));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeView = new GongSolutions.Shell.ShellTreeView();
            this.shellView = new GongSolutions.Shell.ShellView();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.fileMenu = new System.Windows.Forms.MenuItem();
            this.dummyMenuItem = new System.Windows.Forms.MenuItem();
            this.viewMenu = new System.Windows.Forms.MenuItem();
            this.refreshMenu = new System.Windows.Forms.MenuItem();
            this.toolBar = new System.Windows.Forms.ToolBar();
            this.backButton = new System.Windows.Forms.ToolBarButton();
            this.backButtonMenu = new System.Windows.Forms.ContextMenu();
            this.forwardButton = new System.Windows.Forms.ToolBarButton();
            this.forwardButtonMenu = new System.Windows.Forms.ContextMenu();
            this.upButton = new System.Windows.Forms.ToolBarButton();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.shellComboBox1 = new GongSolutions.Shell.ShellComboBox();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 51);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.shellView);
            this.splitContainer.Size = new System.Drawing.Size(610, 224);
            this.splitContainer.SplitterDistance = 197;
            this.splitContainer.TabIndex = 1;
            // 
            // treeView
            // 
            this.treeView.AllowDrop = true;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.ShellView = this.shellView;
            this.treeView.Size = new System.Drawing.Size(197, 224);
            this.treeView.TabIndex = 0;
            this.treeView.Text = "shellTreeView1";
            // 
            // shellView
            // 
            this.shellView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shellView.Location = new System.Drawing.Point(0, 0);
            this.shellView.Name = "shellView";
            this.shellView.Size = new System.Drawing.Size(409, 224);
            this.shellView.StatusBar = this.statusBar;
            this.shellView.TabIndex = 0;
            this.shellView.Text = "shellView1";
            this.shellView.View = GongSolutions.Shell.ShellViewStyle.Details;
            this.shellView.Navigated += new System.EventHandler(this.shellView_Navigated);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 275);
            this.statusBar.Name = "statusBar";
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(610, 22);
            this.statusBar.TabIndex = 1;
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.fileMenu,
            this.viewMenu});
            // 
            // fileMenu
            // 
            this.fileMenu.Index = 0;
            this.fileMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.dummyMenuItem});
            this.fileMenu.Text = "&File";
            this.fileMenu.Popup += new System.EventHandler(this.fileMenu_Popup);
            // 
            // dummyMenuItem
            // 
            this.dummyMenuItem.Index = 0;
            this.dummyMenuItem.Text = "Dummy";
            this.dummyMenuItem.Visible = false;
            // 
            // viewMenu
            // 
            this.viewMenu.Index = 1;
            this.viewMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.refreshMenu});
            this.viewMenu.Text = "&View";
            // 
            // refreshMenu
            // 
            this.refreshMenu.Index = 0;
            this.refreshMenu.Shortcut = System.Windows.Forms.Shortcut.F5;
            this.refreshMenu.Text = "&Refresh";
            this.refreshMenu.Click += new System.EventHandler(this.refreshMenu_Click);
            // 
            // toolBar
            // 
            this.toolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.backButton,
            this.forwardButton,
            this.upButton});
            this.toolBar.DropDownArrows = true;
            this.toolBar.ImageList = this.imageList;
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.ShowToolTips = true;
            this.toolBar.Size = new System.Drawing.Size(610, 28);
            this.toolBar.TabIndex = 2;
            this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
            // 
            // backButton
            // 
            this.backButton.DropDownMenu = this.backButtonMenu;
            this.backButton.ImageIndex = 0;
            this.backButton.Name = "backButton";
            this.backButton.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            // 
            // backButtonMenu
            // 
            this.backButtonMenu.Popup += new System.EventHandler(this.backButton_Popup);
            // 
            // forwardButton
            // 
            this.forwardButton.DropDownMenu = this.forwardButtonMenu;
            this.forwardButton.ImageIndex = 1;
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            // 
            // forwardButtonMenu
            // 
            this.forwardButtonMenu.Popup += new System.EventHandler(this.forwardButton_Popup);
            // 
            // upButton
            // 
            this.upButton.ImageIndex = 2;
            this.upButton.Name = "upButton";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList.Images.SetKeyName(0, "Back.bmp");
            this.imageList.Images.SetKeyName(1, "Forward.bmp");
            this.imageList.Images.SetKeyName(2, "Up.bmp");
            // 
            // shellComboBox1
            // 
            this.shellComboBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.shellComboBox1.Editable = true;
            this.shellComboBox1.Location = new System.Drawing.Point(0, 28);
            this.shellComboBox1.Name = "shellComboBox1";
            this.shellComboBox1.ShellView = this.shellView;
            this.shellComboBox1.Size = new System.Drawing.Size(610, 23);
            this.shellComboBox1.TabIndex = 3;
            this.shellComboBox1.Text = "shellComboBox1";
            // 
            // ShellExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 297);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.shellComboBox1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.toolBar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(600, 200);
            this.Name = "ShellExplorer";
            this.Text = "Shell Explorer";
            this.ResizeEnd += new System.EventHandler(this.ShellExplorer_ResizeEnd);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GongSolutions.Shell.ShellTreeView treeView;
        private System.Windows.Forms.SplitContainer splitContainer;
        private GongSolutions.Shell.ShellView shellView;
        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem fileMenu;
        private System.Windows.Forms.ToolBar toolBar;
        private System.Windows.Forms.ToolBarButton backButton;
        private System.Windows.Forms.ToolBarButton forwardButton;
        private System.Windows.Forms.ToolBarButton upButton;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ContextMenu backButtonMenu;
        private System.Windows.Forms.ContextMenu forwardButtonMenu;
        private System.Windows.Forms.MenuItem dummyMenuItem;
        private System.Windows.Forms.MenuItem viewMenu;
        private System.Windows.Forms.MenuItem refreshMenu;
        private GongSolutions.Shell.ShellComboBox shellComboBox1;
    }
}

