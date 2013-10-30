// GongSolutions.Shell - A Windows Shell library for .Net.
// Copyright (C) 2007-2009 Steven J. Kirk
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either 
// version 2 of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public 
// License along with this program; if not, write to the Free 
// Software Foundation, Inc., 51 Franklin Street, Fifth Floor,  
// Boston, MA 2110-1301, USA.
//
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using GongSolutions.Shell;
using GongSolutions.Shell.Interop;
using NUnit.Framework;

namespace ShellTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            RunTests();
        }

        static void RunTests()
        {
            ShellItemTest test = new ShellItemTest();

            test.SetUp();

            try
            {
                test.Names();
                test.EnumerateChildren();
                test.SpecialFolders();
                test.Attributes();
                test.Compare();
                test.Uri();
                test.Pidl();
            }
            finally
            {
                test.TearDown();
            }
        }
    }

    [TestFixture]
    public class ShellItemTest
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            Directory.CreateDirectory(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "GongShellTestFolder"));
            Directory.CreateDirectory(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "GongShellTestFolder\\Nested"));
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            Directory.Delete(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "GongShellTestFolder"),
                true);
        }

        [Test]
        public void Names()
        {
            string location = @"C:\Program Files";
            string displayName = @"Program Files";
            ShellItem item = new ShellItem(location);
            Assert.AreEqual(displayName, item.DisplayName);
            Assert.AreEqual(location, item.FileSystemPath);
            Assert.AreEqual(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                ShellItem.Desktop.FileSystemPath);
        }

        [Test]
        public void EnumerateChildren()
        {
            string location = @"C:\Program Files";
            ShellItem item = new ShellItem(location);
            List<string> children = new List<string>();

            children.AddRange(Directory.GetFiles(location));
            children.AddRange(Directory.GetDirectories(location));

            // The shell does not include desktop.ini in its enumeration.
            children.Remove(Path.Combine(location, "desktop.ini"));

            foreach (ShellItem child in item)
            {
                children.Remove(child.FileSystemPath);
            }

            Assert.IsEmpty(children);
        }

        [Test]
        public void SpecialFolders()
        {
            Environment.SpecialFolder myComputerFolder =
                Environment.SpecialFolder.MyComputer;
            Environment.SpecialFolder myPicturesFolder =
                Environment.SpecialFolder.MyPictures;
            ShellItem myComputer = new ShellItem(myComputerFolder);
            ShellItem myComputer2 = new ShellItem(myComputer.ToUri());
            ShellItem myPictures = new ShellItem(myPicturesFolder);
            ShellItem myPictures2 = new ShellItem(myPictures.ToUri());

            Assert.IsTrue(myComputer.Equals(myComputer2));
            Assert.AreEqual(Environment.GetFolderPath(myPicturesFolder), myPictures.FileSystemPath);
            Assert.AreEqual(myPictures, myPictures2);

            try
            {
                string path = myComputer.FileSystemPath;
                Assert.Fail("FileSystemPath from virtual folder should throw exception");
            }
            catch (ArgumentException)
            {
            }
            catch (Exception)
            {
                Assert.Fail("FileSystemPath from virtual folder should throw ArgumentException");
            }
        }

        [Test]
        public void Attributes()
        {
            ShellItem cDrive = new ShellItem(@"C:\");
            ShellItem myComputer =
                new ShellItem(Environment.SpecialFolder.MyComputer);
            ShellItem file = new ShellItem(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.System),
                "kernel32.dll"));

            Assert.IsTrue(cDrive.IsFolder);
            Assert.IsTrue(myComputer.IsFolder);
            Assert.IsFalse(file.IsFolder);
        }

        [Test]
        public void Compare()
        {
            ShellItem desktop1 = ShellItem.Desktop;
            ShellItem desktop2 = new ShellItem("shell:///Desktop");
            ShellItem item1 = new ShellItem(@"C:\Program Files");
            ShellItem item2 = item1.Parent[@"Program Files"];

            Assert.IsTrue(desktop1.Equals(desktop2));
            Assert.AreEqual(item1.FileSystemPath, item2.FileSystemPath);
            Assert.IsTrue(item1 == item2);
            Assert.IsFalse(item1 != item2);
        }

        [Test]
        public void Uri()
        {
            string desktopExpected = "shell:///Desktop";
            string myComputerExpected = "shell:///MyComputerFolder";
            string myDocumentsExpected = "shell:///Personal";
            ShellItem desktop1 = ShellItem.Desktop;
            ShellItem desktop2 = new ShellItem(desktopExpected);
            ShellItem myComputer = new ShellItem(myComputerExpected);
            ShellItem myDocuments = new ShellItem(Environment.SpecialFolder.MyDocuments);
            ShellItem myDocumentsChild = myDocuments["GongShellTestFolder"];
            ShellItem myDocumentsChild2 = new ShellItem(myDocumentsExpected + "/GongShellTestFolder");
            ShellItem myDocumentsChild3 = new ShellItem(myDocumentsExpected + "/GongShellTestFolder/Nested");
            ShellItem cDrive = new ShellItem(@"C:\");
            ShellItem controlPanel = new ShellItem((Environment.SpecialFolder)CSIDL.CONTROLS);

            Assert.AreEqual(desktopExpected, desktop1.ToString());
            Assert.AreEqual(desktopExpected, desktop2.ToString());
            Assert.AreEqual(myComputerExpected, myComputer.ToString());
            Assert.AreEqual(myDocumentsExpected, myDocuments.ToString());
            Assert.AreEqual(myDocumentsExpected + "/GongShellTestFolder",
                myDocumentsChild.ToString());
            Assert.AreEqual("file:///C:/", cDrive.ToString());
            Assert.IsTrue(myDocumentsChild.Equals(myDocumentsChild2));
            Assert.AreEqual(myDocumentsExpected + "/GongShellTestFolder/Nested",
                myDocumentsChild3.ToString());
        }

        [Test]
        public void Pidl()
        {
            ShellItem myDocuments = new ShellItem(Environment.SpecialFolder.MyDocuments);
            IntPtr pidl = myDocuments.Pidl;
        }
    }
}
