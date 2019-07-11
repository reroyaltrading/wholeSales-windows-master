using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WholeSalesWarehousing.Model;

namespace WholeSalesWarehousing.Views
{
    public partial class FormMain : Form
    {
        private Login login;
        /*
         * Need to write a group of cookies on each request for the Laravel
         * autenticate the request, not sending them results on error 403
         */
        private CookieCollection cookies { get { return this.login.Container; } }

        public FormMain(Login login)
        {
            InitializeComponent();
            this.login = login;
            this.Text = String.Format("WholeSales Warehousing - {0}", login.username);
        }
    }
}
