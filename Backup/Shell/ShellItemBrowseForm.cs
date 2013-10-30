using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GongSolutions.Shell
{
    partial class ShellItemBrowseForm : Form
    {
        public ShellItemBrowseForm()
        {
            InitializeComponent();

            KnownFolderManager manager = new KnownFolderManager();

            SystemImageList.UseSystemImageList(knownFolderList);
            foreach (KnownFolder knownFolder in manager)
            {
                try
                {
                    ShellItem shellItem = knownFolder.CreateShellItem();
                    ListViewItem item = knownFolderList.Items.Add(knownFolder.Name,
                        shellItem.GetSystemImageListIndex(ShellIconType.LargeIcon, 0));

                    item.Tag = knownFolder;

                    if (item.Text == "Personal")
                    {
                        item.Text = "Personal (My Documents)";
                        item.Group = knownFolderList.Groups["common"];
                    }
                    else if ((item.Text == "Desktop") ||
                               (item.Text == "Downloads") ||
                               (item.Text == "MyComputerFolder"))
                    {
                        item.Group = knownFolderList.Groups["common"];
                    }
                    else
                    {
                        item.Group = knownFolderList.Groups["all"];
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        public ShellItem SelectedItem
        {
            get { return m_SelectedItem; }
        }

        void SaveSelection()
        {
            if (tabControl.SelectedTab == knownFoldersPage)
            {
                m_SelectedItem = ((KnownFolder)knownFolderList.SelectedItems[0].Tag)
                    .CreateShellItem();
            }
            else
            {
                m_SelectedItem = allFilesView.SelectedItems[0];
            }
        }

        void knownFolderList_DoubleClick(object sender, EventArgs e)
        {
            if (knownFolderList.SelectedItems.Count > 0)
            {
                SaveSelection();
                DialogResult = DialogResult.OK;
            }
        }

        void knownFolderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            okButton.Enabled = knownFolderList.SelectedItems.Count > 0;
        }

        void fileBrowseView_SelectionChanged(object sender, EventArgs e)
        {
            okButton.Enabled = allFilesView.SelectedItems.Length > 0;
        }

        void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == knownFoldersPage)
            {
                okButton.Enabled = knownFolderList.SelectedItems.Count > 0;
            }
            else if (e.TabPage == allFilesPage)
            {
                okButton.Enabled = allFilesView.SelectedItems.Length > 0;
            }
        }

        void okButton_Click(object sender, EventArgs e)
        {
            SaveSelection();
            DialogResult = DialogResult.OK;
        }

        ShellItem m_SelectedItem;
    }
}