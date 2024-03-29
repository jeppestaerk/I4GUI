﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace DirectoryTreeView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BuildTree();
        }

        private void BuildTree()
        {
            treeFileSystem.Items.Clear();

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                TreeViewItem item = new TreeViewItem();
                item.Tag = drive;
                item.Header = drive.ToString();

                // This placeholder string is never shown,
                // because the node begins in collapsed state.
                item.Items.Add("*");
                treeFileSystem.Items.Add(item);
            }
        }

        private void item_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)e.OriginalSource;

            // Perform a refresh every time item is expanded.
            // Optionally, you could perform this only the first
            // time, when the placeholder is found (less refreshes),
            // every time an item is selected (more refreshes)
            // or when a message is received by the FileSystemWatcher
            // (intelligent refreshes, requiring the most overhead).
            item.Items.Clear();

            DirectoryInfo dir;
            if (item.Tag is DriveInfo)
            {
                DriveInfo drive = (DriveInfo)item.Tag;
                dir = drive.RootDirectory;
            }
            else
            {
                dir = (DirectoryInfo)item.Tag;
            }

            try
            {
                foreach (DirectoryInfo subDir in dir.GetDirectories())
                {
                    TreeViewItem newItem = new TreeViewItem();
                    newItem.Tag = subDir;
                    newItem.Header = subDir.ToString();
                    newItem.Items.Add("*");
                    item.Items.Add(newItem);
                }
                foreach (var fileInfo in dir.GetFiles())
                {
                    TreeViewItem newItem = new TreeViewItem();
                    newItem.Tag = fileInfo;
                    newItem.Header = fileInfo.ToString();
                    item.Items.Add(newItem);
                }
            }
            catch (Exception ex)
            {
                // An exception could be thrown in this code if you don't
                // have sufficient security permissions for a file or directory.
                MessageBox.Show(ex.Message, ex.GetType().Name);
            }
        }
    }
}
