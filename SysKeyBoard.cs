using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartKeyboard2.StandKeyBoard;
using SmartKeyboard2.laptop;
using SmartKeyboard2.model;

namespace SmartKeyboard2
{
    public class SysKeyBoard : UserControl,IClient
    {
        private Panel funPanel;
        private Panel IOPanel;
        private Panel taskPanel;
        private StandFunBar funBar;


        private string currentViewID = string.Empty;

        Dictionary<string, IView> dicFunView = new Dictionary<string, IView>();
        Dictionary<string, IView> dicIOView = new Dictionary<string, IView>();

        #region
        private float width = 18.5F;
        private float height = 7.0F;
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

        public SysKeyBoard()
        {
            InitializeComponent();
            widthDPI = this.Width;
            heightDPI = this.Height;
        }


        public void ToggleFunbar()
        {
            funBar.FunctionToggle();
        }

        public void RenderFunbar( KeyUnit unit)
        {
            ShowControl(ref funPanel,unit);
            unit.SetKeyBoard(this);
        }

        public void RenderIOBar( KeyUnit unit)
        {
            ShowControl(ref IOPanel, unit);
            unit.SetKeyBoard(this);
        }

        public void RenderTaskBar(KeyUnit unit)
        {
            ShowControl(ref taskPanel, unit);
            unit.SetKeyBoard(this);
        }


        private void ShowControl(ref Panel panel,KeyUnit unit)
        {
            var keys= unit.GetLayout();
            foreach (SKey key in keys)
            {
                key.Width =(int) ((key.GetScaleShape().Width / width) * widthDPI);
                key.Height=(int)((key.GetScaleShape().Height / height) * heightDPI);
                key.Left= (int)((key.GetScaleShape().Left / width) * widthDPI);
                key.Top = (int)((key.GetScaleShape().Top / height) * heightDPI);
                panel.Controls.Add(key);
            }
            
        }


        private void InitializeComponent()
        {
            this.funPanel = new System.Windows.Forms.Panel();
            this.taskPanel = new System.Windows.Forms.Panel();
            this.IOPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // funPanel
            // 
            this.funPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.funPanel.Location = new System.Drawing.Point(0, 0);
            this.funPanel.Name = "funPanel";
            this.funPanel.Size = new System.Drawing.Size(911, 50);
            this.funPanel.TabIndex = 0;
            // 
            // taskPanel
            // 
            this.taskPanel.BackColor = System.Drawing.Color.Tan;
            this.taskPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.taskPanel.Location = new System.Drawing.Point(0, 50);
            this.taskPanel.Name = "taskPanel";
            this.taskPanel.Size = new System.Drawing.Size(911, 50);
            this.taskPanel.TabIndex = 1;
            // 
            // IOPanel
            // 
            this.IOPanel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.IOPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.IOPanel.Location = new System.Drawing.Point(0, 100);
            this.IOPanel.Name = "IOPanel";
            this.IOPanel.Size = new System.Drawing.Size(911, 250);
            this.IOPanel.TabIndex = 2;
            // 
            // SysKeyBoard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.IOPanel);
            this.Controls.Add(this.taskPanel);
            this.Controls.Add(this.funPanel);
            this.Name = "SysKeyBoard";
            this.Size = new System.Drawing.Size(911, 350);
            this.ResumeLayout(false);

        }

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


    }
}