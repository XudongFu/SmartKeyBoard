using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartKeyboard2.KbIDesign
{
    class SmartKeyBoardTask : KeyUnit
    {

        string key = "SKB,1.5,1 已打开及候选App,9,1 Min Max Close Esc 关闭应用栈,4,1 ";

        List<SKey> keys = new List<SKey>();


        public  SmartKeyBoardTask()
        {
            keys = Until.String2keys(key);

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
