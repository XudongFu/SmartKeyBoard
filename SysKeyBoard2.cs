using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartKeyboard2
{
    class SysKeyBoard2:UserControl
    {
        private Panel taskPanel;
        private Panel IOPanel;



        #region
        private float width = 18.5F;
        private float height = 6.0F;
        private float widthDPI;
        private float heightDPI;

        #endregion


        public  SysKeyBoard2()
        {
            InitializeComponent();
            widthDPI = this.Width;
            heightDPI = this.Height;
        }


        public void RenderIOBar(KeyUnit unit)
        {
            ShowControl(ref IOPanel, unit);
        }

        public void RenderTaskBar(KeyUnit unit)
        {
            ShowControl(ref taskPanel, unit);
        }



        private void ShowControl(ref Panel panel, KeyUnit unit)
        {
            var keys = unit.GetLayout();
            foreach (SKey key in keys)
            {
                key.Width = (int)((key.GetScaleShape().Width / width) * widthDPI);
                key.Height = (int)((key.GetScaleShape().Height / height) * heightDPI);
                key.Left = (int)((key.GetScaleShape().Left / width) * widthDPI);
                key.Top = (int)((key.GetScaleShape().Top / height) * heightDPI);
                panel.Controls.Add(key);
            }

        }
        
        private void InitializeComponent()
        {
            this.taskPanel = new System.Windows.Forms.Panel();
            this.IOPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // taskPanel
            // 
            this.taskPanel.BackColor = System.Drawing.Color.SandyBrown;
            this.taskPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.taskPanel.Location = new System.Drawing.Point(0, 0);
            this.taskPanel.Name = "taskPanel";
            this.taskPanel.Size = new System.Drawing.Size(802, 60);
            this.taskPanel.TabIndex = 0;
            // 
            // IOPanel
            // 
            this.IOPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.IOPanel.Location = new System.Drawing.Point(0, 59);
            this.IOPanel.Name = "IOPanel";
            this.IOPanel.Size = new System.Drawing.Size(802, 300);
            this.IOPanel.TabIndex = 1;
            // 
            // SysKeyBoard2
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.IOPanel);
            this.Controls.Add(this.taskPanel);
            this.Name = "SysKeyBoard2";
            this.Size = new System.Drawing.Size(802, 359);
            this.ResumeLayout(false);

        }
    }
}
