using SmartKeyboard2.laptop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartKeyboard2.model;

namespace SmartKeyboard2
{
    public  class SysKeyBoard2:UserControl,IClient
    {
        private Panel taskPanel;
        private Panel IOPanel;

        #region
        private float width = 18.5F;
        private float height = 6.0F;
        private float widthDPI;
        private float heightDPI;

        EventHandler IClient.KeyPress
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        private string currentViewID = string.Empty;

        Dictionary<string, IView> dicFunView = new Dictionary<string, IView>();
        Dictionary<string, IView> dicIOView = new Dictionary<string, IView>();


        #region
        public void SendView(IView view)
        {
            if (view.type == ViewType.FunctionBar)
            {
                dicFunView.Add(view.GetApplicationName(), view);
            }
            else
            {
                dicIOView.Add(view.GetApplicationName(), view);
            }
        }
        void IClient.Initlize()
        {

        }


        public void RenderIOBar(string id)
        {
            if (dicIOView.ContainsKey(id))
            {
                currentViewID = id;
                RenderIOBar(dicIOView[id].GetKeysUnit());
            }
        }

        public void RenderTaskBar(string id)
        {
            if (dicFunView.ContainsKey(id))
            {
                RenderTaskBar(dicFunView[id].GetKeysUnit());
            }
        }

        public void SwitchView(object ViewID)
        {
            throw new NotImplementedException();
        }

        public string GetCurentViewID()
        {
            return currentViewID;
        }

        #endregion


        public SysKeyBoard2()
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
