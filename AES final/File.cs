using System.IO;
using System;
using System.Windows.Forms;
namespace AES_final
{
    class File
    {
        private string text;
        
        //rasymas i faila
        public void WriteFile(string text, string path)
        {           
                if (!System.IO.File.Exists(path))
                {
                    System.IO.File.Create(path);
                    TextWriter tw = new StreamWriter(path);
                    tw.WriteLine(text);
                    tw.Close();


                }
                else if (System.IO.File.Exists(path))
                {
                    TextWriter tw = new StreamWriter(path);
                    tw.WriteLine(text);
                    tw.Close();
                }            
        }

        //failo nuskaitymas
        public string ReadFile(string path)
        {          
                if (System.IO.File.Exists(path))
                {
                    string textas = "";
                    using (StreamReader sr = System.IO.File.OpenText(path))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            textas += s;
                        }
                    }
                    this.text = textas;
                }

            return text;
        }
    }
}
