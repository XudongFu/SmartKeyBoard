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


    /// <summary>
    /// 这个类应该实现IClient的接口才对
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SysKeyBoard keyboard = new SysKeyBoard();
        SysKeyBoard2 kb2 = new SysKeyBoard2();
        SysKeyBoard2 kb3 = new SysKeyBoard2();
        SysKeyBoard2 kb4 = new SysKeyBoard2();



        private void Form1_Load(object sender, EventArgs e)
        {
            keyboard.RenderFunbar(new KbIDesign.SmartKeyBoardFun());
            keyboard.RenderIOBar(new StandKeyBoard.StandIOBar());
            keyboard.RenderTaskBar(new KbIDesign.SmartKeyBoardTask());

            kb2.RenderTaskBar(new KbIDesign.SmartKeyBoardTask());
            kb2.RenderIOBar(new KbIDesign.SmartWindowsBoard());

            kb3.RenderTaskBar(new KbIDesign.SmartKeyBoardTask());
            kb3.RenderIOBar(new KbIDesign.SmartKeyBoardIO());

            kb4.RenderTaskBar(new KbIDesign.SmartKeyBoardTask());
            kb4.RenderIOBar(new KbIDesign.SmartAppBoard());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(keyboard);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(kb2);      
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(kb3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(kb4);

        }
    }
}
