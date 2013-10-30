using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using GongSolutions.Shell;

namespace FileDialog
{
    public partial class FileDialog : Form
    {
        public FileDialog()
        {
            InitializeComponent();
            shellView.CurrentFolder = new ShellItem(Properties.Settings.Default.CurrentFolder);
            shellView.History.Clear();
        }

        void OnFileSelected(string filename)
        {
            MessageBox.Show(filename);
        }

        void UpdateOpenButtonState()
        {
            openButton.Enabled = (shellView.SelectedItems.Length > 0) ||
                                 (fileNameCombo.Text.Length > 0);
        }

        void fileNameCombo_TextChanged(object sender, EventArgs e)
        {
            UpdateOpenButtonState();
        }

        void shellView_DoubleClick(object sender, EventArgs e)
        {
            OnFileSelected(shellView.SelectedItems[0].FileSystemPath);
        }

        void shellView_SelectionChanged(object sender, EventArgs e)
        {
            UpdateOpenButtonState();
        }

        void fileNameCombo_FilenameEntered(object sender, EventArgs e)
        {
            OnFileSelected(fileNameCombo.Text);
        }

        void openButton_Click(object sender, EventArgs e)
        {
            if (!shellView.NavigateSelectedFolder())
            {
                ShellItem[] selected = shellView.SelectedItems;

                if (selected.Length > 0)
                {
                    OnFileSelected(selected[0].FileSystemPath);
                }
                else if (File.Exists(fileNameCombo.Text))
                {
                    OnFileSelected(fileNameCombo.Text);
                }
            }
        }

        void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        void FileDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.CurrentFolder = shellView.CurrentFolder.ToString();
            Properties.Settings.Default.Save();
        }
    }
}
