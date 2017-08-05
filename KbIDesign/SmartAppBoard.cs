using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartKeyboard2.KbIDesign
{
    class SmartAppBoard :KeyUnit
    {
        string valuekey2 = "Tab,1.5,1 Q W E R T Y U I O P () [] {}\r" +
                             "CapsLk,1.7,1 A S D F G H J K L ; ' Enter,1.8,1\r" +
                             "Shift,2.25,1 Z X C V B N M , . / Symbol,1.25,1\r" +
                             "Ctrl,1.4,1 Fn Win Alt Space,5,1 Alt Content Ctrl,1.1,1";

        //这里存在一个问题，为了在0左边空开一个位置，动用了一个空格
        string smallKeyBoard = "NumLock / * -\r7 8 9 +,1,2\r4 5 6\r1 2 3 Enter,1,2\r 0 .";

        string directions = "↑\r← ↓ →";

        string numbers = "SpecialAppKeyList,13,1 BackSpace,1.5,1";

        List<SKey> keys = new List<SKey>();

        List<SKey> smallKeyBoardKeys = new List<SKey>();

        List<SKey> firstLine;

        private void Inite()
        {
            firstLine = Until.String2keys(numbers);
            smallKeyBoardKeys = Until.String2keys(new PointF(14.5F, 0), smallKeyBoard);
            var direction = Until.String2keys(new PointF(12.5F, 3), directions);
            direction[0].shape.X += 1;
            keys.AddRange(direction);
        }


        public SmartAppBoard()
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
