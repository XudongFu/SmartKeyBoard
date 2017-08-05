using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartKeyboard2.KbIDesign
{
    class SmartKeyBoardFun : KeyUnit
    {

        string functionKeys = "Esc Fn F1 F2 F3 F4 F5 F6 F7 F8 F9 F10 F11 F12 Insert PrtSc Delete Home End PageUp PageDown";

        string auxiliaryFunctions = "Esc Fn 静音 音量减 音量加 关闭 刷新 NoToucher " +
                               "飞行模式 功能列表 息屏 分屏 亮度弱 亮度强 Insert PrtSc Delete Pause Break ScrLK SysRq";

        List<SKeyInfo> funKV = new List<SKeyInfo>();
        List<SKeyInfo> auKV = new List<SKeyInfo>();
        List<SKey> keys = new List<SKey>();

        private bool IsFunction = true;

        private void PreparParams()
        {
            var keys = functionKeys.Split(' ');
            var aux = auxiliaryFunctions.Split(' ');
            for (int i = 0; i < keys.Length; i++)
            {
                funKV.Add(new SKeyInfo(keys[i], keys[i], keys[i], "control"));

                auKV.Add(new SKeyInfo(aux[i], aux[i], aux[i], "control"));
            }
        }


        public SmartKeyBoardFun()
        {
            float left = 0;
            var keyString = functionKeys.Split(' ');
            float width = (float)(14.5 / 17.0);
            for (int i = 0; i < keyString.Length; i++)
            {
                string k = keyString[i];
                if (i < keyString.Length - 4)
                {
                    SKey key = new SKey(k, new System.Drawing.RectangleF(left, 0, width, 1))
                    {
                        Text = keyString[i],
                        type = "control",
                        value = keyString[i]
                    };
                    left += width;
                    key.Click += (m, n) => {
                        KeyClick(key.GetKey());
                    };
                    keys.Add(key);
                }
                else
                {
                    SKey key = new SKey(k, new System.Drawing.RectangleF(left, 0, 1, 1))
                    {
                        Text = keyString[i],
                        type = "control",
                        value = keyString[i]
                    };
                    left += 1;
                    key.Click += (m, n) => {
                        KeyClick(key.GetKey());
                    };
                    keys.Add(key);
                }
            }
            PreparParams();
        }

        public void FunctionToggle()
        {
            if (IsFunction)
            {
                for (int i = 0; i < keys.Count; i++)
                {
                    keys[i].SetFirstKey(auKV[i]);
                }

                IsFunction = false;

            }
            else
            {
                for (int i = 0; i < keys.Count; i++)
                {
                    keys[i].SetFirstKey(funKV[i]);
                }

                IsFunction = true;
            }
        }


        public override List<SKey> GetLayout()
        {
            return keys;
        }


        public override void KeyClick(string e)
        {

        }
    }
}
