using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace SmartKeyboard2
{
    public class SKey:Button
    {
        #region

        public string Key
        {
            set { if (isSecond && hasSecond) secondkeyinfo.Key = value; else firstkeyinfo.Key = value; }
            get { if (isSecond && hasSecond) return secondkeyinfo.Key; else return firstkeyinfo.Key; }
        }

        public string value
        {
            set { if (isSecond && hasSecond) secondkeyinfo.Value = value; else firstkeyinfo.Value = value; }
            get { if (isSecond && hasSecond) return secondkeyinfo.Value; else return firstkeyinfo.Value; }
        }

        public string type
        {
            set { if (isSecond && hasSecond) secondkeyinfo.Type = value; else firstkeyinfo.Type = value; }
            get { if (isSecond && hasSecond) return secondkeyinfo.Type; else return firstkeyinfo.Type; }
        }

        public override string Text
        {
            set { if (isSecond && hasSecond) secondkeyinfo.Text = value; else firstkeyinfo.Text = value; }
            get { if (isSecond && hasSecond) return secondkeyinfo.Text; else return firstkeyinfo.Text; }
        }
    #endregion


        public RectangleF shape;

        private SKeyInfo firstkeyinfo=new SKeyInfo();
        private SKeyInfo secondkeyinfo=new SKeyInfo();
        private bool isSecond = false;
        private bool hasSecond = false;

        public SKey(string key,RectangleF shape)
        {
            this.Key = key;
            this.shape = shape;
        }

        public SKey(RectangleF shape)
        {
           
            this.shape = shape;
        }


        public void SetSecondKey(SKeyInfo info)
        {
            hasSecond = true;
            secondkeyinfo = info;
        }




        public SKey()
        {

        }

        public  void InvokeFirst()
        {
            isSecond = false;
            base.Text = firstkeyinfo.Text;
        }
        public void InvokeSecond()
        {
            if (hasSecond)
            {
                isSecond = true;
                base.Text = secondkeyinfo.Text;
            }
           
        }

        public void ToggleKey()
        {
            if (isSecond)
            {
                InvokeFirst();
            }
            else
            {
                InvokeSecond();
            }
        }

        public void SetFirstKey(SKeyInfo info)
        {
            Text = info.Text;
            this.Key = info.Key;
            this.value = info.Value;
            this.type = info.Type;
        }


        public RectangleF GetScaleShape()
        {
            return shape;
        }


        public string GetKey()
        {
            return  Key;
        }



    }
}