using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoldArch.DotNetBar.Test
{
    public partial class FormMainPlan : Form
    {
        public FormMainPlan()
        {
            InitializeComponent();
        }

        public FormMainPlan(string text)
        {
            InitializeComponent();

            labelX1.Text = text;
        }
    }
}
