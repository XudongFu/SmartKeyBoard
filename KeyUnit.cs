using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartKeyboard2
{
    public abstract class KeyUnit
    {

        private SysKeyBoard keyboard;

        public abstract void KeyClick(string e);


        public abstract List<SKey> GetLayout();


        internal void SetKeyBoard(SysKeyBoard board)
        {
            this.keyboard = board;
        }

        public void FuntionToggle()
        {
            keyboard.ToggleFunbar();

        }

        public KeyUnit()
        {
           
        }

      
    }
}