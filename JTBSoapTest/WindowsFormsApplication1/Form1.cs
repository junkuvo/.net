using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Configuration;
using Microsoft.Web.Services2;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public SoapEnvelope EnvIn;

        public Form1()
        {
            InitializeComponent();

            List<string> URLs = new List<string>(ConfigurationManager.AppSettings["URLs"]
                .Replace("\r", "").Replace("\n", "").Replace("\t", "").Split(new char[] { ';' }));

            foreach (string url in URLs)
            {
                Url.Items.Add(url.Trim());
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            SendEnvelope Srv = new SendEnvelope();
            SoapEnvelope EnvOut = null;
            Boolean Status = false;

            StsBar.Clear();
            RichOut.Clear();

            EnvOut = Srv.Send(Url.Text, this, ref Status);
            if (Status)
            {
                StsBar.Text = "Success!";
                if (EnvOut != null)
                {
                    RichOut.Text = FormatXml(EnvOut);
                }
            }
            else
            {
                StsBar.Text = "Failed.";
            }
        }

        public void CreateEnv(String text)
        {
            try
            {
                this.EnvIn = new SoapEnvelope();
                this.EnvIn.DocumentElement.OwnerDocument.PreserveWhitespace = false;
                //this.EnvIn.LoadXml(this.RichIn.Text().Replace("<wsa:Action></wsa:Action>", ""))
                this.EnvIn.LoadXml(text);
            }
            catch (Exception ex)
            {
                StsBar.Text = ex.Message;
            }

        }

        // soap envelope読込
        public void CreateEnv()
        {
            CreateEnv(this.RichIn.Text);
        }

        public static String FormatXml(String xml)
        {
            String ret = xml;
            try
            {
                SoapEnvelope env = new SoapEnvelope();
                env.LoadXml(xml);
                return FormatXml(env);
            }
            catch (Exception)
            {
            }
            return ret;
        }

        public static String FormatXml(XmlNode node)
        {
            MemoryStream mem = new MemoryStream();
            if (node == null || node.InnerXml == null) return "";

            String ret = node.InnerXml;
            try
            {
                XmlTextWriter w = new XmlTextWriter(new StreamWriter(mem));
                w.Formatting = Formatting.Indented;
                w.Indentation = 3;
                w.IndentChar = ' ';
                node.WriteTo(w);
                w.Close();
                mem.Close();
                ret = System.Text.Encoding.Default.GetString(mem.ToArray());
            }
            catch (Exception)
            {
            }
            ret = ret.Replace("\t", "   ");
            return ret;
        }

    }
}
