using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Print_Stories
{
    public partial class frmAuth : Form
    {
        private string url;
        private string sessionid;

        public string SSO_URL
        {
            get { return url; }
            set { this.url = value; }
        }

        private string sessionID;

        public string Session_ID
        {
            get { return sessionID; }
            set { sessionID = value; }
        }

        public frmAuth()
        {
            InitializeComponent();
        }

        private void frmAuth_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate(url);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlDocument doc = webBrowser1.Document;

            string body = doc.Body.InnerText;

            if (body.IndexOf("ZSESSIONID") > 0)
            {
                HtmlElementCollection elements = doc.Body.GetElementsByTagName("P");

                foreach (HtmlElement element in elements)
                {
                    if (element.InnerText.IndexOf("cookie value:") > 0)
                        sessionID = element.Name.Split(':')[1];
                }
            }
        }
    }
}
