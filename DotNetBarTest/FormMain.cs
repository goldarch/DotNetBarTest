using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using GoldArch.DotNetBar.Test.Common;
using SRSmartManufacturing;

namespace GoldArch.DotNetBar.Test
{
    public partial class FormMain : OfficeForm
    {
        public static FormMain FormMainInstance { get; set; }
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
            var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            string productVersion = versionInfo.ProductVersion;
            var companyName = versionInfo.CompanyName;

            Text = $@"{companyName}(版本号:V{productVersion})";

            labelXCompanyName.Text = companyName;

            OpenWindow( typeof(FormNavigation), "Form01",false,null);
        }

        public void OpenWindow(Type formType, string frmId)
        {
            ShowInMdi.OpenWindow(superTabControl1,formType,frmId,true,null);
        }

        public void OpenWindow(Type formType, string frmId, bool canClose,object[] args)
        {
            ShowInMdi.OpenWindow(superTabControl1, formType, frmId, canClose,args);
        }

        public void OpenWindow(Form form, string frmId, bool canClose)
        {
            ShowInMdi.OpenWindow(superTabControl1, form, frmId, canClose);
        }

        public bool IsOpenTab(string pTabName)
        {
            return ShowInMdi.IsOpenTab(superTabControl1, pTabName);
        }
    }
}