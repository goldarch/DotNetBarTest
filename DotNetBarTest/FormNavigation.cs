using System;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace GoldArch.DotNetBar.Test
{
    public partial class FormNavigation : Office2007Form
    {
        public FormNavigation()
        {
            InitializeComponent();
        }

        private void metroTileItem4_Click(object sender, EventArgs e)
        {
            FormMain.FormMainInstance.OpenWindow(typeof(FormMainPlan),@"生产主计划");
        }

        private void metroTileItem1_Click(object sender, EventArgs e)
        {
            MessageBoxEx.Show("测试传参和对同一个表单使用不同的tab name");
            FormMain.FormMainInstance.OpenWindow(typeof(FormMainPlan), @"我不是生产主计划",true,new []{"我不是生产计划！！！！！"});
        }

        private void metroTileItem2_Click(object sender, EventArgs e)
        {
            MessageBoxEx.Show("错误的用了相同的关键字name，要与FormMainPlan进行对比测试");
            FormMain.FormMainInstance.OpenWindow(typeof(Form), @"生产主计划");
        }

        private void metroTileItem3_Click(object sender, EventArgs e)
        {
            var tabName= @"主动新建Form";
            if (FormMain.FormMainInstance.IsOpenTab(tabName))
            {
                return;
            }

            var frm = new Form();
            frm.Text = @"主动新建Form";

            FormMain.FormMainInstance.OpenWindow(frm,tabName,true);
        }

        private void metroTileItem5_Click(object sender, EventArgs e)
        {
            new FormAbout().ShowDialog(this);
        }
    }
}
