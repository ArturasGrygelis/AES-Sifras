using System;
using System.Windows.Forms;
using System.IO;
namespace AES_final
{
    public partial class Form1 : Form
    {     
        File file = new File();       

        public Form1()
        {
            InitializeComponent();           
            label4.Text = file.ReadFile(textBox3.Text);
            textBox1.Text = "ow7dxys8glfor9tnc2ansdfo1etkfjcv";
        }

        //encrypt mygtukas - jei text'o laukelis yra tuscias, nuskaitomas faile esantis textas ir jis uzsifruojamas,
        //jei text'o laukelis nėra tuscias, sis textas yra uzsifruojamas ir įrašomas į failą
        private void btn_encrypt_Click(object sender, EventArgs e)
        {
            
            if (textBox2.Text == "")
            {
                file.WriteFile(Aes.Encrypt(file.ReadFile(textBox3.Text), textBox1.Text), textBox3.Text);
                ZinutesTxtB.Text = file.ReadFile(textBox3.Text);
                MessageBox.Show("Tekstas esantis faile sekmingai uzsifruotas!");

            }
            else
            {
                file.WriteFile(Aes.Encrypt(textBox2.Text, textBox1.Text), textBox3.Text);
                label4.Text = file.ReadFile(textBox3.Text);
                MessageBox.Show("Tekstas sekmingai uzsifruotas!");
            }
            
        }

        //decrypt mygtukas - desifruojamas faile esantis textas
        private void btn_decrypt_Click(object sender, EventArgs e)
        {
            string textas = file.ReadFile(textBox3.Text);
            file.WriteFile(Aes.Decrypt(textas, textBox1.Text), textBox3.Text);
            ZinutesTxtB.Text = file.ReadFile(textBox3.Text);
            MessageBox.Show("Tekstas sekmingai desifruotas!");
        }

        //failo atidarymo mygtukas
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Pasirinkite tekstini faila modifikavimui",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = openFileDialog1.FileName;
            }
        }
        
    }
}
