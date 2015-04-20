using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Security.Cryptography;

using System.Text.RegularExpressions;

//P Esto se quita al final
using System.Diagnostics;

//@todo
//refactorizar los botones de encriptAR,Desentriptar
//drag & drop


namespace ESCryptoSecureMegaBox
{
    public partial class MW_Form_Ventana : Form
    {
        //P pssst salt
        private static byte[] _salt = Encoding.ASCII.GetBytes("123456789");
        private static int Aes_KeySize = /*aes.KeySize / 8 , 256 / 8*/32;

        private static string initialRoute = (@"C:\Test");
        private static string inputPath;
        //Pout este e el der dropbos
        private static string outputPath;

        private static string password;

        public MW_Form_Ventana()
        {
            InitializeComponent();
            PopulateTreeView();
        }

        private void MW_TextBox_Contraseña_TextChanged(object sender, EventArgs e)
        {
            password = MW_TextBox_Contraseña.Text;
        }

        private void MW_Button_Encriptar_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection inputCollection = MW_ListView_Archivos.SelectedItems;

            String inputFile = Regex.Match(initialRoute, "^[a-zA-Z]") + ":" + @"\" + sub + @"\";
            String outputFile;

            foreach (ListViewItem item in inputCollection)
            {
                inputFile += item.Text;
                outputFile = inputFile + ".aesed";

                Cifrar(inputFile, outputFile);
            }
        }

        private void MW_Button_Desencriptar_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection inputCollection = MW_ListView_Archivos.SelectedItems;

            String inputFile = Regex.Match(initialRoute, "^[a-zA-Z]") + ":" + @"\" + sub + @"\";
            //P extension
            String outputFile;

            foreach (ListViewItem item in inputCollection)
            {
                inputFile += item.Text;
                outputFile = System.IO.Path.ChangeExtension(inputFile, null) + "1";

                Descifrar(inputFile, outputFile);
            }
        }

        private void MW_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private static void Cifrar(string inputFile, string outputFile)
        {
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, _salt);

            using (Aes aes = Aes.Create())
            {
                byte[] file = File.ReadAllBytes(inputFile);
                //Tamaño de clave? 256 / 8 
                aes.Key = key.GetBytes(Aes_KeySize);
                //Tamaño de bytes
                //aes.IV = key.GetBytes(16);

                byte[] Cyphed = Cypher_Aes(file, aes.Key, aes.IV);
                //Array.Resize(Cyphed,)

                //Tamaño de IV, IV, Texto Cifrado
                //32 bits, IV.length, resto
                byte[] headIV = new byte[aes.IV.Length + Cyphed.Length + BitConverter.GetBytes(aes.IV.Length).Length];

                Array.Copy(BitConverter.GetBytes(aes.IV.Length), 0, headIV, 0, BitConverter.GetBytes(aes.IV.Length).Length);
                Array.Copy(aes.IV, 0, headIV, BitConverter.GetBytes(aes.IV.Length).Length, aes.IV.Length);
                Array.Copy(Cyphed, 0, headIV, BitConverter.GetBytes(aes.IV.Length).Length + aes.IV.Length, Cyphed.Length);

                File.WriteAllBytes(outputFile, headIV);
            }
        }

        private static void Descifrar(string inputFile, string outputFile)
        {
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, _salt);

            //byte[] file = File.ReadAllBytes(inputFile);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key.GetBytes(Aes_KeySize);
                using (BinaryReader bRead = new BinaryReader(File.OpenRead(inputFile)))
                {
                    int IVlength = bRead.ReadInt32();
                    aes.IV = bRead.ReadBytes(IVlength);
                    byte[] file;

                    const int bufferSize = 4096;
                    using (MemoryStream mStream = new MemoryStream())
                    {
                        byte[] buffer = new byte[bufferSize];
                        int count;
                        while ((count = bRead.Read(buffer, 0, buffer.Length)) != 0)
                            mStream.Write(buffer, 0, count);
                        file = mStream.ToArray();
                    }
                    File.WriteAllBytes(outputFile, DeCypher_Aes(file, aes.Key, aes.IV));
                }
            }
        }

        private static byte[] Cypher_Aes(byte[] inputFile, byte[] Key, byte[] IV)
        {
            byte[] cyphed;
            // Create an Aes object
            // with the specified key and IV.
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;

                ICryptoTransform cypher = aes.CreateEncryptor(aes.Key, aes.IV);
                
                using (MemoryStream msCyphe = new MemoryStream())
                {
                    using (CryptoStream csCyphe = new CryptoStream(msCyphe, cypher, CryptoStreamMode.Write))
                    {
                        using (BinaryWriter swEncrypt = new BinaryWriter(csCyphe))
                        {
                            swEncrypt.Write(inputFile);
                        }
                        cyphed = msCyphe.ToArray();
                    }
                }
            }

            return cyphed;

        }

        private static byte[] DeCypher_Aes(byte[] cyphedText, byte[] Key, byte[] IV)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;

                ICryptoTransform decypher = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream msDecyphe = new MemoryStream(cyphedText))
                {
                    using (CryptoStream csDecyphe = new CryptoStream(msDecyphe, decypher, CryptoStreamMode.Read))
                    {
                        using (BinaryReader srDecyphe = new BinaryReader(csDecyphe)) 
                        {
                            using (MemoryStream outputFile = new MemoryStream())
                            {

                                const int buffsize = 4096;
                                byte[] buffer = new byte[buffsize];
                                int count;

                                while ((count = srDecyphe.Read(buffer, 0, buffer.Length)) != 0)
                                    outputFile.Write(buffer, 0, count);

                                return outputFile.ToArray();
                            }
                        }
                    }
                }
            }
        }

        private string uplevel; // parent path
        private static string sub;

        private string CheckParent(TreeNode child)
        {
            if (child.Parent != null)
            {
                TreeNode temp = child.Parent;
                uplevel = this.CheckParent(temp) + @"\" + child.Text;
            }
            else
            {
                uplevel = child.Text;
            }
            return uplevel;
        }



        //Ptreessss
        private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
        {
            TreeNode curNode = addInMe.Add(directoryInfo.Name);

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                curNode.Nodes.Add(file.FullName, file.Name);
            }
            foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
            {
                BuildTree(subdir, curNode.Nodes);
            }
        }

        void MW_TreeView_Directorios_NodeMouseClick(object sender,
            TreeNodeMouseClickEventArgs e)
        {
            TreeNode newSelected = e.Node;

            uplevel = "";
            sub = this.CheckParent(newSelected);
            inputPath = sub;

            MW_ListView_Archivos.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;

            foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
            {
                item = new ListViewItem(dir.Name, 0);
                subItems = new ListViewItem.ListViewSubItem[]
                    {new ListViewItem.ListViewSubItem(item, "Directory"), 
                     new ListViewItem.ListViewSubItem(item, 
						dir.LastAccessTime.ToShortDateString())};
                item.SubItems.AddRange(subItems);
                MW_ListView_Archivos.Items.Add(item);
            }
            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                item = new ListViewItem(file.Name, 1);
                subItems = new ListViewItem.ListViewSubItem[]
                    { new ListViewItem.ListViewSubItem(item, "File"), 
                     new ListViewItem.ListViewSubItem(item, 
						file.LastAccessTime.ToShortDateString())};

                item.SubItems.AddRange(subItems);
                MW_ListView_Archivos.Items.Add(item);
            }

            MW_ListView_Archivos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        
        private void PopulateTreeView()
        {
            TreeNode rootNode;

            try
            {
                DirectoryInfo info = new DirectoryInfo(initialRoute);
                if (info.Exists)
                {
                    rootNode = new TreeNode(info.Name);
                    rootNode.Tag = info;
                    GetDirectories(info.GetDirectories(), rootNode);
                    MW_TreeView_Directorios.Nodes.Add(rootNode);
                }

            }
            catch (UnauthorizedAccessException excepcion)
            {
                MessageBox.Show(excepcion.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void GetDirectories(DirectoryInfo[] subDirs,
            TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {
                aNode = new TreeNode(subDir.Name, 0, 0);
                aNode.Tag = subDir;
                aNode.ImageKey = "folder";
                subSubDirs = subDir.GetDirectories();
                if (subSubDirs.Length != 0)
                {
                    GetDirectories(subSubDirs, aNode);
                }
                nodeToAddTo.Nodes.Add(aNode);
            }
        }
    }
}
