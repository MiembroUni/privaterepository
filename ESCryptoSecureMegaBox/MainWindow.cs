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

//P Esto se quita al final
using System.Diagnostics;

namespace ESCryptoSecureMegaBox
{
    public partial class MW_Form_Ventana : Form
    {
        //P pssst salt
        private static byte[] _salt = Encoding.ASCII.GetBytes("123456789");
        private static int Aes_KeySize = /*aes.KeySize / 8 */32;

        public MW_Form_Ventana()
        {
            InitializeComponent();
        }

        private void MW_TextBox_Directorio_TextChanged(object sender, EventArgs e)
        {   
            MW_Button_Refresh_Click(this, new EventArgs());
        }

        private void MW_Button_Encriptar_Click(object sender, EventArgs e)
        {
            String inputFile = MW_TreeView_Directorios.SelectedNode.Name;
            String outputFile = inputFile + ".aesed";            

            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(MW_TextBox_Contraseña.Text, _salt);

            using (Aes aes= Aes.Create())
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
                byte[] headIV = new byte[aes.IV.Length+Cyphed.Length+BitConverter.GetBytes(aes.IV.Length).Length];
                
                Array.Copy(BitConverter.GetBytes(aes.IV.Length),0,headIV,0,BitConverter.GetBytes(aes.IV.Length).Length);
                Array.Copy(aes.IV,0,headIV,BitConverter.GetBytes(aes.IV.Length).Length,aes.IV.Length);
                Array.Copy(Cyphed,0,headIV,BitConverter.GetBytes(aes.IV.Length).Length+aes.IV.Length,Cyphed.Length);

                File.WriteAllBytes(outputFile, headIV);
            }

            /*
            //P CUIDAO CON LOS DIRECTORIOS ESTO ES PROVISIONAL
            String inputFile = MW_TreeView_Directorios.SelectedNode.Name;
            String outputFile = inputFile + ".aesed";

            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(MW_TextBox_Contraseña.Text,_salt);
            byte[] file = File.ReadAllBytes(inputFile);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key.GetBytes(aes.KeySize/8);
                ICryptoTransform cypher = aes.CreateEncryptor(aes.Key, aes.IV);


                // Create the streams used for encryption. 
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, cypher, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(file);
                        }
                        File.WriteAllBytes(outputFile, msEncrypt.ToArray());
                    }
                }                
            }
            */
        }

        private void MW_Button_Desencriptar_Click(object sender, EventArgs e)
        {
            String inputFile = MW_TreeView_Directorios.SelectedNode.Name;
            //P extension
            String outputFile = System.IO.Path.ChangeExtension(inputFile, null) + "1";

            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(MW_TextBox_Contraseña.Text, _salt);

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
                        file= mStream.ToArray();
                    }
                    File.WriteAllBytes(outputFile, DeCypher_Aes(file, aes.Key, aes.IV));
                }
            }
            /*
            //P CUIDAO CON LOS DIRECTORIOS ESTO ES PROVISIONAL
            String inputFile = MW_TreeView_Directorios.SelectedNode.Name;
            String outputFile = inputFile + ".deaesed";

            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(MW_TextBox_Contraseña.Text, _salt);
            byte[] file = File.ReadAllBytes(inputFile);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key.GetBytes(aes.KeySize / 8);
                ICryptoTransform decypher = aes.CreateDecryptor(aes.Key, aes.IV);

                // Create the streams used for encryption. 
                using (MemoryStream msDecrypt = new MemoryStream(file))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decypher, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            File.WriteAllText(outputFile, srDecrypt.ReadToEnd());
                        }
                    }
                }
            }   
            */
        }

        private void MW_Button_Refresh_Click(object sender, EventArgs e)
        {
            MW_TreeView_Directorios.Nodes.Clear();
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(@MW_TextBox_Directorio.Text);
                if (directoryInfo.Exists)
                {
                    BuildTree(directoryInfo, MW_TreeView_Directorios.Nodes);
                }
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
    }
}
