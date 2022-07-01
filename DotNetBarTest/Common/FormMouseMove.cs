using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace GoldArch.ControlBase.FormHelpers
{
    public class FormMouseMove
    {
        [DllImport("user32.dll")]//拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;



        private Form _frm;
        public FormMouseMove(Form pForm)
        {
            _frm = pForm;
        }

        #region 使用传递消息的方法

        //[C#]使用Label标签控件模拟窗体标题的移动及窗体颜色不断变换

        public void Form_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();

            //发送消息 让系统误以为在标题栏上按下鼠标【骗子!!】
            SendMessage(_frm.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);

        }       

        #endregion



        //#region 实现无边框鼠标移动(dx 代码可用)

        //private Point _mousePoint;

        //public void Form_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        Point mouseSet = Control.MousePosition;

        //        //_frm.Top = MousePosition.Y - _mousePoint.Y;
        //        //_frm.Left = MousePosition.X - _mousePoint.X;

        //        _frm.Top = mouseSet.Y - _mousePoint.Y;
        //        _frm.Left = mouseSet.X - _mousePoint.X;
        //    }
        //}

        //public void Form_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        _mousePoint.X = e.X;
        //        _mousePoint.Y = e.Y;
        //    }
        //}

        //#endregion


    }
}
