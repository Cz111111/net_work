using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace week4
{
    public partial class Form1 : Form
    {

        private ImageList treeViewImageList;
        public Form1()
        {
            InitializeComponent();
            InitializeTreeView();
            InitializeListView();

        }
        private void InitializeTreeView()
        {
            // 创建ImageList
            treeViewImageList = new ImageList();
            treeViewImageList.Images.Add("Drive", Properties.Resources.drive);
            treeViewImageList.Images.Add("Folder", Properties.Resources.folder);
            treeViewImageList.Images.Add("File", Properties.Resources.file);
            treeView1.ImageList = treeViewImageList;

           
            var driveInfo = new DriveInfo(@"D:\");
            TreeNode rootNode = treeView1.Nodes.Add(driveInfo.Name, driveInfo.Name, "Drive"); // 使用图标的键
            rootNode.SelectedImageIndex = 0;
            rootNode.Tag = driveInfo.RootDirectory.FullName;
            

            

            // 递归添加所有子目录
            AddDirectories(treeView1.Nodes[0], driveInfo.RootDirectory);
        }

        private void AddDirectories(TreeNode rootNode, DirectoryInfo dirInfo)
        {
            try
            {
                foreach (DirectoryInfo subDir in dirInfo.GetDirectories())
                {
                    TreeNode node = rootNode.Nodes.Add(subDir.Name, subDir.Name, "Folder"); // 使用图标的键
                    node.SelectedImageIndex = 1;
                    node.Tag = subDir.FullName; // 存储完整路径
                    AddDirectories(node, subDir);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // 忽略没有权限访问的目录
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // 确保选中的节点不为空
            if (e.Node != null)
            {
                // 获取选中的目录
                DirectoryInfo selectedDir = new DirectoryInfo(e.Node.Tag.ToString());
                // 清空ListView
                listView1.Items.Clear();

                // 获取目录中的文件和子目录
                foreach (FileSystemInfo fsi in selectedDir.GetFileSystemInfos())
                {
                    ListViewItem item = null;
                    if (fsi is DirectoryInfo)
                    {
                        // 添加文件夹
                        item = listView1.Items.Add(fsi.Name, 0); // 第二个参数是图标索引
                    }
                    else if (fsi is FileInfo)
                    {
                        // 添加文件
                        item = listView1.Items.Add(fsi.Name, 1); // 第二个参数是图标索引
                        item.SubItems.Add(((FileInfo)fsi).Length.ToString());
                    }

                    if (item != null)
                    {
                        item.SubItems.Add(fsi.FullName);
                        item.Tag = fsi.FullName;
                    }
                }
            }
        }

        private void InitializeListView()
        {
            listView1.View = View.LargeIcon; // 设置为大图标模式
            listView1.SmallImageList = new ImageList();
            listView1.LargeImageList = new ImageList();

            // 设置图标大小
            listView1.SmallImageList.ImageSize = new Size(16, 16);
            listView1.LargeImageList.ImageSize = new Size(32, 32);

            // 添加文件夹和文件的图标
            listView1.LargeImageList.Images.Add("Folder", Properties.Resources.folder); 
            listView1.LargeImageList.Images.Add("File", Properties.Resources.file); 

            // 设置列
            listView1.Columns.Add("Name", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Size", 100, HorizontalAlignment.Right);
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string path = (string)listView1.SelectedItems[0].Tag;
                if (File.Exists(path))
                {
                    // 根据文件类型打开文件
                    if (Path.GetExtension(path).ToLower() == ".exe")
                    {
                        Process.Start(path);
                    }
                    else if (Path.GetExtension(path).ToLower() == ".txt")
                    {
                        Process.Start("notepad.exe", path);
                    }
                }
            }
        }
    }
}
