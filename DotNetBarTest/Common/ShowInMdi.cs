using System;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace GoldArch.DotNetBar.Test.Common
{
    public static class ShowInMdi
    {
        //加入主界面
        //第一种方法，加控件
        //SetMdiForm("主界面", typeof(UserControl01));
        //===
        //var frm = new Form01();
        //OpenWindow(frm, "主界面");
        //===
        // ShowInMdi.SetTabShow(superTabControl1, "主界面", "Form01", false);

        //MDI 多文件介面（Multiple Document Interface

        #region 第一种方法测试

        /*
       *
      /// <summary>
      /// 创建或者显示一个多文档界面页面
      /// </summary>
      /// <param name="caption">窗体标题</param>
      /// <param name="formType">窗体类型</param>
      public void SetMdiForm(string caption, Type formType)
      {
          bool IsOpened = false;

          //遍历现有的Tab页面，如果存在，那么设置为选中即可
          foreach (SuperTabItem tabitem in superTabControl1.Tabs)
          {
              if (tabitem.Name == caption)
              {
                  superTabControl1.SelectedTab = tabitem;
                  IsOpened = true;
                  break;
              }
          }

          //如果在现有Tab页面中没有找到，那么就要初始化了Tab页面了
          if (!IsOpened)
          {
              //为了方便管理，调用LoadMdiForm函数来创建一个新的窗体，并作为MDI的子窗体
              //然后分配给SuperTab控件，创建一个SuperTabItem并显示
              UserControl form = Activator.CreateInstance(formType) as UserControl;
              //Form form = Activator.CreateInstance(formType) as Form;

              SuperTabItem tabItem = superTabControl1.CreateTab(caption);
              tabItem.Name = caption;
              tabItem.Text = caption;

              form.Visible = true;
              form.Dock = DockStyle.Fill;
              form.AutoScroll = true;
              //tabItem.Icon = form.Icon;
              tabItem.AttachedControl.Controls.Add(form);

              superTabControl1.SelectedTab = tabItem;
          }
      }

      /// <summary>
      /// 刷新界面页面
      /// </summary>
      /// <param name="caption">窗体标题</param>
      /// <param name="formType">窗体类型</param>
      public void updateMdiForm(string caption, Type formType)
      {
          bool IsOpened = false;

          //遍历现有的Tab页面，如果存在，那么设置为选中即可
          foreach (SuperTabItem tabitem in superTabControl1.Tabs)
          {
              if (tabitem.Name == caption)
              {
                  superTabControl1.SelectedTab = tabitem;
                  //tabitem.Dispose();
                  IsOpened = true;
                  UserControl form = Activator.CreateInstance(formType) as UserControl;
                  //Form form = Activator.CreateInstance(formType) as Form;

                  //form.Dispose();//控件使用完后Dispose。
                  tabitem.AttachedControl.Controls[0].Dispose();
                  tabitem.AttachedControl.Controls.Clear();

                  form.Visible = true;
                  form.Dock = DockStyle.Fill;
                  form.AutoScroll = true;
                  tabitem.AttachedControl.Controls.Add(form);

                  break;
              }
          }

          //如果在现有Tab页面中没有找到，那么就要初始化了Tab页面了
          if (!IsOpened)
          {
              //为了方便管理，调用LoadMdiForm函数来创建一个新的窗体，并作为MDI的子窗体
              //然后分配给SuperTab控件，创建一个SuperTabItem并显示
              UserControl form = Activator.CreateInstance(formType) as UserControl;
              //Form form = Activator.CreateInstance(formType) as Form;

              SuperTabItem tabItem = superTabControl1.CreateTab(caption);
              tabItem.Name = caption;
              tabItem.Text = caption;



              form.Visible = true;
              form.Dock = DockStyle.Fill;
              form.AutoScroll = true;
              //tabItem.Icon = form.Icon;
              tabItem.AttachedControl.Controls.Add(form);

              superTabControl1.SelectedTab = tabItem;
          }
       */

        #endregion

        #region 第二种方法测试

        //D:\DaxERP-Library\Dotnetbar\源码，示例\C#Winfrom旺旺收银管理系统源码_无密码\C#Winfrom旺旺收银管理系统源码_无密码\收银系统\AppCash\frmMain.cs
        //把原代码中的
        //DevComponents.DotNetBar.TabItem tp = new DevComponents.DotNetBar.TabItem();
        //DevComponents.DotNetBar.TabControlPanel tcp = new DevComponents.DotNetBar.TabControlPanel();
        //全部改成：
        //DevComponents.DotNetBar.SuperTabItem tp = new DevComponents.DotNetBar.SuperTabItem();
        //DevComponents.DotNetBar.SuperTabControlPanel tcp = new DevComponents.DotNetBar.SuperTabControlPanel();
        //其它的代码不用做任何更改！
        /// <summary>
        /// 检测要打开的tab
        /// </summary>
        /// <param name="superTabControl1"></param>
        /// <param name="pTabName"></param>
        /// <returns></returns>
        public static bool IsOpenTab(SuperTabControl superTabControl1, string pTabName)
        {
            bool isOpened = false;
            var tabName = GetUniquelyIdentifiesTabName(pTabName);

            foreach (SuperTabItem tab in superTabControl1.Tabs)
            {
                if (tab.Name == tabName.Trim())
                {
                    isOpened = true;
                    superTabControl1.SelectedTab = tab;
                    superTabControl1.Refresh();
                    break;
                }
            }

            return isOpened;
        }

        public static void OpenWindow(SuperTabControl superTabControl1, Type formType, string tabName, bool canClose = true,object[] args=null)
        {
            if (IsOpenTab(superTabControl1, tabName))
            {
                return;
            }

            DevComponents.DotNetBar.SuperTabItem tp = new DevComponents.DotNetBar.SuperTabItem();
            DevComponents.DotNetBar.SuperTabControlPanel tcp = new DevComponents.DotNetBar.SuperTabControlPanel();
            //tp.MouseDown += new MouseEventHandler(tp_MouseDown);

            tcp.Dock = System.Windows.Forms.DockStyle.Fill;
            tcp.Location = new System.Drawing.Point(0, 0);

            Form frm = Activator.CreateInstance(formType,args) as Form;

            frm.TopLevel = false;
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tcp.Controls.Add(frm);
            tp.Text = frm.Text;
            tp.Name = GetUniquelyIdentifiesTabName(tabName);
            if (!canClose)
            {
                tp.CloseButtonVisible = false;
            }

            tcp.TabItem = tp;
            tp.AttachedControl = tcp;
            superTabControl1.Controls.Add(tcp);
            superTabControl1.Tabs.Add(tp);
            superTabControl1.SelectedTab = tp;
        }

        /// <summary>
        /// 这个方法最灵活，调用前先检查是否存在tab，如果不存在，则主动新建frm，并加入tab!
        /// </summary>
        /// <param name="superTabControl1"></param>
        /// <param name="frm"></param>
        /// <param name="tabName"></param>
        /// <param name="canClose"></param>
        public static void OpenWindow(SuperTabControl superTabControl1, Form frm, string tabName, bool canClose)
        {
            if (IsOpenTab(superTabControl1, tabName))
            {
                MessageBoxEx.Show("不能新建Tab,已经存在唯一的关键标识.");
                return;
            }

            DevComponents.DotNetBar.SuperTabItem tp = new DevComponents.DotNetBar.SuperTabItem();
            DevComponents.DotNetBar.SuperTabControlPanel tcp = new DevComponents.DotNetBar.SuperTabControlPanel();
            //tp.MouseDown += new MouseEventHandler(tp_MouseDown);
            tcp.Dock = System.Windows.Forms.DockStyle.Fill;
            tcp.Location = new System.Drawing.Point(0, 0);

            frm.TopLevel = false;
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tcp.Controls.Add(frm);
            tp.Text = frm.Text;
            tp.Name = GetUniquelyIdentifiesTabName(tabName);
            if (!canClose)
            {
                tp.CloseButtonVisible = false;
            }

            tcp.TabItem = tp;
            tp.AttachedControl = tcp;
            superTabControl1.Controls.Add(tcp);
            superTabControl1.Tabs.Add(tp);
            superTabControl1.SelectedTab = tp;
        }

        public static string GetUniquelyIdentifiesTabName(string tabName)
        {
            return "superTabItem_" + tabName;
        }

        //private void tp_MouseDown(object sender, MouseEventArgs e)
        //{
        //    superTabControl1.SelectedTab = (SuperTabItem)sender;
        //    if (e.Button == MouseButtons.Right && superTabControl1.SelectedTab != null)
        //    {
        //        this.superTabControl1.Select();
        //        //cms.Show(this.tabMain, e.X, e.Y);
        //    }
        //}

        //this.superTabControl1.TabItemClose += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripTabItemCloseEventArgs>(this.superTabControl1_TabItemClose);
        //private void superTabControl1_TabItemClose(object sender, SuperTabStripTabItemCloseEventArgs e)
        //{
        //    SuperTabItem tb = superTabControl1.SelectedTab;
        //    superTabControl1.Tabs.Remove(tb);
        //}

        #endregion

        #region 第三种方法

        //public static void SetTabShow(SuperTabControl superTabControl1, string tabName, string sfrmName, bool canClose = true)
        //{
        //    bool isOpen = false;
        //    foreach (SuperTabItem item in superTabControl1.Tabs)
        //    {
        //        //已打开
        //        if (item.Name == tabName)
        //        {
        //            superTabControl1.SelectedTab = item;
        //            isOpen = true;
        //            break;
        //        }
        //    }

        //    if (!isOpen)
        //    {
        //        //反射取得子窗体对象。
        //        //object obj = Assembly.GetExecutingAssembly().CreateInstance("BarCodeSys.subWindows." + sfrmName, false);
        //        object obj = Assembly.GetExecutingAssembly().CreateInstance("SRSmartManufacturing." + sfrmName, false);
        //        //需要强转
        //        Form form = (Form)obj;
        //        //设置该子窗体不为顶级窗体，否则不能加入到别的控件中
        //        form.TopLevel = false;
        //        form.Visible = true;
        //        //布满父控件
        //        form.Dock = DockStyle.Fill;
        //        form.FormBorderStyle = FormBorderStyle.None;
        //        //创建一个tab
        //        SuperTabItem item = superTabControl1.CreateTab(tabName);
        //        //设置显示名和控件名
        //        item.Text = tabName;
        //        item.Name = tabName;

        //        if (!canClose)
        //        {
        //            item.CloseButtonVisible = false;
        //        }

        //        //将子窗体添加到Tab中
        //        item.AttachedControl.Controls.Add(form);
        //        //选择该子窗体。
        //        superTabControl1.SelectedTab = item;
        //    }
        //}

        #endregion
    }
}