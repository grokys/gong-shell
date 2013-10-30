using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GongSolutions.Shell;

namespace ShellExplorer
{
    public partial class ShellExplorer : Form
    {
        public ShellExplorer()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            if ((m_ContextMenu == null) || (!m_ContextMenu.HandleMenuMessage(ref m)))
            {
                base.WndProc(ref m);
            }
        }

        void shellView_Navigated(object sender, EventArgs e)
        {
            backButton.Enabled = shellView.CanNavigateBack;
            forwardButton.Enabled = shellView.CanNavigateForward;
            upButton.Enabled = shellView.CanNavigateParent;
        }

        void fileMenu_Popup(object sender, EventArgs e)
        {
            ShellItem[] selectedItems = shellView.SelectedItems;

            if (selectedItems.Length > 0)
            {
                m_ContextMenu = new ShellContextMenu(selectedItems);
            }
            else
            {
                m_ContextMenu = new ShellContextMenu(treeView.SelectedFolder);
            }

            m_ContextMenu.Populate(fileMenu);
        }

        void refreshMenu_Click(object sender, EventArgs e)
        {
            shellView.RefreshContents();
            treeView.RefreshContents();
        }

        void toolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button == backButton)
            {
                shellView.NavigateBack();
            }
            else if (e.Button == forwardButton)
            {
                shellView.NavigateForward();
            }
            else if (e.Button == upButton)
            {
                shellView.NavigateParent();
            }
        }

        void backButton_Popup(object sender, EventArgs e)
        {
            List<MenuItem> items = new List<MenuItem>();

            backButtonMenu.MenuItems.Clear();
            foreach (ShellItem f in shellView.History.HistoryBack)
            {
                MenuItem item = new MenuItem(f.DisplayName);
                item.Tag = f;
                item.Click += new EventHandler(backButtonMenuItem_Click);
                items.Insert(0, item);
            }

            backButtonMenu.MenuItems.AddRange(items.ToArray());
        }

        void forwardButton_Popup(object sender, EventArgs e)
        {
            forwardButtonMenu.MenuItems.Clear();
            foreach (ShellItem f in shellView.History.HistoryForward)
            {
                MenuItem item = new MenuItem(f.DisplayName);
                item.Tag = f;
                item.Click += new EventHandler(forwardButtonMenuItem_Click);
                forwardButtonMenu.MenuItems.Add(item);
            }
        }

        void backButtonMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            ShellItem folder = (ShellItem)item.Tag;
            shellView.NavigateBack(folder);
        }

        void forwardButtonMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            ShellItem folder = (ShellItem)item.Tag;
            shellView.NavigateForward(folder);
        }

        void ShellExplorer_ResizeEnd(object sender, EventArgs e)
        {
            int calculatedWidth = shellView.Width - shellView.GetColumnWidth(1)
                - shellView.GetColumnWidth(2) - shellView.GetColumnWidth(3) - 25;
            shellView.SetColumnWidth(0, calculatedWidth);
        }

        ShellContextMenu m_ContextMenu;
    }
}