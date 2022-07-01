using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using GoldArch.ControlBase.FormHelpers;

namespace SRSmartManufacturing
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, System.EventArgs e)
        {
            /*
265
There are three versions: assembly, file, and product. They are used by different features and take on different default values if you don't explicit specify them.

string assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString(); 
string assemblyVersion = Assembly.LoadFile("your assembly file").GetName().Version.ToString(); 
string fileVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion; 
string productVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;
             */

            var formMouseMove = new FormMouseMove(this);
            MouseDown += formMouseMove.Form_MouseDown;
            pictureBox1.MouseDown += formMouseMove.Form_MouseDown;
            panelEx1.MouseDown += formMouseMove.Form_MouseDown;

            //默认为form，则背景透明会体现form颜色
            labelXCompanyName.Parent = pictureBox1;
            labelX2.Parent = pictureBox1;
            labelX3.Parent = pictureBox1;
            buttonXClose.Parent = panelEx1;

            var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            string productVersion = versionInfo.ProductVersion;
            var companyName = versionInfo.CompanyName;

            labelXCompanyName.Text = companyName;
            labelX2.Text = @"V"+productVersion;
        }

        private void buttonXClose_Click(object sender, System.EventArgs e)
        {
            Dispose();
        }

        private void labelX3_Click(object sender, System.EventArgs e)
        {

        }

        private void buttonX登录_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
