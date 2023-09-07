using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            method_93(0);
        }
        private void method_93(int row)
        {
            try
            {
                string cookie = (string)dataGridView1.Rows[0].Cells["clmCookie"].Value;
                if (cookie.Trim() == "")
                {
                    MessageBox.Show("Cookie trô\u0301ng!");
                    return;
                }
                string text5 = "";
                if (!smethod_3(cookie, "", "", row).StartsWith("1|"))
                {
                    text5 = "Cookie die";
                }
                else
                {
                    text5 = "Cookie live";
                }
                MessageBox.Show(text5);
            }
            catch
            {
                MessageBox.Show("Không check đươ\u0323c!");
            }
        }
        public static string smethod_3(string Cookie, string uagent, string proxy, int row)
        {
            string result = "0|0";
            string value = Regex.Match(Cookie, "c_user=(\\d+)").Groups[1].Value;
            if (value != "")
            {
                try
                {
                    RequestXNet requestCheck = new RequestXNet(Cookie, uagent, proxy, row);
                    if (value != "")
                    {
                        string responseCheck = requestCheck.RequestGet("https://m.facebook.com/home.php").ToString();
                        List<string> list_ = new List<string> { "/friends/", "/logout.php?button_location=settings&amp;button_name=logout" };
                        if (smethod_26(responseCheck, list_))
                        {
                            result = "1|1";
                        }
                    }
                }
                catch
                {
                }
            }
            return result;
        }
        public static bool smethod_26(string F01CBDB5, List<string> list_0)
        {
            int num = 0;
            while (true)
            {
                if (num < list_0.Count)
                {
                    if (Regex.IsMatch(F01CBDB5, list_0[num]))
                    {
                        break;
                    }
                    num++;
                    continue;
                }
                return false;
            }
            return true;
        }
    }
}
