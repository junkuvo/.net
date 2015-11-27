
using System;

using System.Net;
using System.Collections;
using Microsoft.Web.Services2;
using Microsoft.Web.Services2.Addressing;

namespace WindowsFormsApplication1
{
    public class SendEnvelope
    {
        public const int MAX_BUF_SIZE = (128 * 1024);
        public const String ADDRESSING_TO = "soap://to";

        public SendEnvelope()
        {
        }

        public SoapEnvelope Send(String Url, Form1 Frm, ref Boolean Status)
        {

            Status = false;

            SoapWebRequest Req = null;
            HttpWebResponse WebRes = null;

            System.IO.Stream Out = null;
            System.IO.Stream Ins = null;
            SoapEnvelope EnvOut = null;
            Byte[] InBytes = null;
            int Ind = 0;

            try
            {

                Frm.CreateEnv();

                // soap リクエストクエリの作成
                Req = new SoapWebRequest(Url);
                HttpWebRequest HttpR = (HttpWebRequest)Req.Request;
                Req.SoapContext.Envelope = Frm.EnvIn;
                Req.Method = "POST";
                Req.ContentType = "text/xml;charset=\"utf-8\"";
                Req.SoapContext.Addressing.Destination = new EndpointReference(new Uri(ADDRESSING_TO));

                //Req.SoapContext.Addressing.Action = new Microsoft.Web.Services2.Addressing.Action(Frm.SoapAction.Text);
                Req.SoapContext.Addressing.To = new To(new Uri(ADDRESSING_TO));

                System.Net.WebHeaderCollection Hdrs;
                Out = Req.Request.GetRequestStream();
                Req.SoapContext.Envelope.Save(Out);
                Out.Close();

                Hdrs = Req.Headers;
                try
                {
                    WebRes = (HttpWebResponse)Req.Request.GetResponse();
                }
                catch (WebException wex)
                {
                    Frm.RichOut.Text = Form1.FormatXml(System.Text.Encoding.Default.GetString(InBytes, 0, Ind))
                         + wex.Message;
                    EnvOut = null;
                }

                if (WebRes != null)
                {
                    Ins = WebRes.GetResponseStream();
                    Hdrs = WebRes.Headers;

                    EnvOut = new SoapEnvelope();
                    ArrayList DynArray = new ArrayList();
                    int b = Ins.ReadByte();
                    while (b != -1 && Ind < MAX_BUF_SIZE)
                    {
                        DynArray.Add((Byte)b);
                        Ind += 1;
                        b = Ins.ReadByte();
                    }
                    Ins.Close();
                    InBytes = (Byte[])DynArray.ToArray(typeof(Byte));

                    if (Ind >= MAX_BUF_SIZE)
                    {
                        Frm.RichOut.Text = "Response too long";
                    }
                    else
                    {
                        EnvOut.LoadXml(System.Text.Encoding.Default.GetString(InBytes, 0, Ind));
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                if (Ind > 0)
                {
                    Frm.RichOut.Text = Form1.FormatXml(System.Text.Encoding.Default.GetString(InBytes, 0, Ind))
                         + ex.Message;
                    EnvOut = null;
                }
                return null;
            }
            finally
            {
            }

            Frm.RichIn.Text = Form1.FormatXml(Req.SoapContext.Envelope);
            if (WebRes.StatusCode == HttpStatusCode.OK)
            {
                Status = true;
            }

            return EnvOut;
        }
    }
}
