using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teclado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verificaParentesis();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();
                String s = richTextBox1.Text;
                s = s.Replace('á', 'a');
                s = s.Replace('é', 'e');
                s = s.Replace('í', 'i');
                s = s.Replace('ó', 'o');
                s = s.Replace('ú', 'u');
                System.Windows.Forms.SendKeys.Send(s);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
        private void verificaParentesis()
        {
            //verifica que los parentesis esten balanceados
            String s = richTextBox1.Text;
            string s2 = "";
            int max = s.Length;
            List<int> lista = new List<int>();
            List<int> eliminar = new List<int>();
            for (int i = 0; i < max; i++)
            {
                if (s[i] == '(')
                {
                    s2 = s2 + s[i];
                    lista.Add(s2.Length-1);//aqui se abre un parentesis
                }
                else if(s[i] == ')')
                {
                    if(lista.Count > 0)
                    {
                        // como esta valanceado el parentesis, lo quito de la lista
                        lista.RemoveAt(lista.Count - 1);
                        s2 = s2 + s[i];
                    }
                }
                else
                {
                    s2 = s2 + s[i];
                }
            }
            //ahora elimino los parentesis abiertos que no se han cerrado
            for(int i=lista.Count-1;i>=0;i--)
            {
                s2.Remove(lista[i]);
            }
            richTextBox1.Text=s2;
        }
    }
}

