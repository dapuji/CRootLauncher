using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRootLauncher.Properties;

namespace CRootLauncher
{
    public partial class ConfigurationControl : UserControl
    {
        public ConfigurationControl()
        {
            InitializeComponent();

            this.btnAuthorize.Click += BtnAuthorize_Click;
            this.btnReset.Click += BtnReset_Click;

            LoadConfig();
        }

        private void BtnAuthorize_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            LoadConfig();
        }

        /// <summary>
        /// https://adfs.contoso.com/adfs
        /// </summary>
        string Authority
        {
            get { return txtAuthority.Text; }
            set { txtAuthority.Text = value; }
        }

        /// <summary>
        /// https://adfs-srv.croot.com/WebApi/
        /// </summary>
        string ResourceUri
        {
            get { return txtResourceUri.Text; }
            set { txtResourceUri.Text = value; }
        }

        /// <summary>
        /// 5071e284-f5b5-45e6-995f-53ee33cd3e27
        /// </summary>
        string ClientId
        {
            get { return txtClientId.Text; }
            set { txtClientId.Text = value; }
        }

        /// <summary>
        /// http://adfs-srv.croot.com/
        /// </summary>
        string RedirectUri
        {
            get { return txtRedirectUri.Text; }
            set { txtRedirectUri.Text = value; }
        }

        private void LoadConfig()
        {
            Authority = Settings.Default.Authority;
            ResourceUri = Settings.Default.ResourceUri;
            ClientId = Settings.Default.ClientId;
            RedirectUri = Settings.Default.RedirectUri;
        }

        private void SaveConfig()
        {
            Settings.Default.Authority = Authority;
            Settings.Default.ResourceUri = ResourceUri;
            Settings.Default.ClientId = ClientId;
            Settings.Default.RedirectUri = RedirectUri;
            Settings.Default.Save();
        }
    }
}
