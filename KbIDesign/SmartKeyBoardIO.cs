using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartKeyboard2.KbIDesign
{
    class SmartKeyBoardIO : KeyUnit
    {

        string valuekey2 = "Tab,1.5,1 Q W E R T Y U I O P () [] {}\r" +
                              "CapsLk,1.7,1 A S D F G H J K L ; ' Enter,1.8,1\r" +
                              "Shift,2.25,1 Z X C V B N M , . / Shift,1.25,1\r" +
                              "Ctrl,1.4,1 Fn Win Alt Space,5,1 Alt Content Ctrl,1.1,1";


        //这里存在一个问题，为了在0左边空开一个位置，动用了一个空格
        string smallKeyBoard = "NumLock / * -\r7 8 9 +,1,2\r4 5 6\r1 2 3 Enter,1,2\r 0 .";

        string directions = "↑\r← ↓ →";

        string numbers = "` 1 2 3 4 5 6 7 8 9 0 - = BackSpace,1.5,1";

        string operate = "~ ! @ # $ % ^ & * \\ | _ + BackSpace";

        List<SKey> keys = new List<SKey>();

        List<SKey> smallKeyBoardKeys = new List<SKey>();

        List<SKey> firstLine;

        private void Inite()
        {
            var sign = operate.Split(' ');
            List<SKeyInfo> info = new List<SKeyInfo>();
            foreach (string p in sign)
            {
                SKeyInfo temp = new SKeyInfo(p, p, p, "char");
                info.Add(temp);
            }
            firstLine = Until.String2keys(numbers);
            int i = 0;
            firstLine.ForEach(x => {
                x.SetSecondKey(info[i++]);
            });
            smallKeyBoardKeys = Until.String2keys(new PointF(14.5F, 0), smallKeyBoard);

            var direction = Until.String2keys(new PointF(12.5F, 3), directions);
            direction[0].shape.X += 1;

            keys.AddRange(direction);
        }


        public SmartKeyBoardIO()
        {
            Inite();
            var x = Until.String2keys(new Point(0, 1), valuekey2);
            keys.AddRange(x);
        }

        public override List<SKey> GetLayout()
        {
            List<SKey> x = new List<SKey>();
            x.AddRange(keys);
            x.AddRange(smallKeyBoardKeys);
            x.AddRange(firstLine);
            return x;
        }


        public override void KeyClick(string e)
        {
            switch (e)
            {
                case "Fn":
                    FuntionToggle();
                    break;
                case "CapsLk":

                    break;
                case "Shift":
                    firstLine.ForEach(x => {
                        x.ToggleKey();
                    });
                    break;
            }

        }
    }
}
