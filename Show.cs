using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartKeyboard2
{
    public partial class Show : Form
    {
        public Show()
        {
            InitializeComponent();
        }

        public void RegisterBoard(SysKeyBoard board)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(board);
        }

        public void RegisterBoard(SysKeyBoard2 board)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(board);
        }

    }
}
