using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class Form1 : Form
    {
        WPF_UserControls.Customer customer = new WPF_UserControls.Customer();
        public Form1()
        {
            InitializeComponent();
            elementHost.Child = customer;
        }
    }
}
