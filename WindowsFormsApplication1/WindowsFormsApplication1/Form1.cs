using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using xNet.Net;
using xNet.Text;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //this.Text += String.Format(" [%s]", s);
        }

        //Кол-во страниц
        private int GetCountPages()
        {
            int countPages = 0;
            string SourcePage;

            try
            {
                using (var Request = new HttpRequest())
                {
                    SourcePage = Request.Get("http://vegetarian.ru/forum/users/").ToString();
                    MessageBox.Show(SourcePage);
                    countPages = Convert.ToInt32(SourcePage.Substrings("/forum/users/?PAGEN_1=", "\">", 0)[4]);
                }
            } catch {}

            return countPages;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = Convert.ToString(GetCountPages());

            MessageBox.Show(s);
        }
    }
}
