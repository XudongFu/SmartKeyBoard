using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartKeyboard2.KbIDesign
{
    class SmartWindowsBoard : KeyUnit
    {

        string auxiliaryFunctions = "Fn 静音 音量减 音量加 关闭 刷新 NoToucher 飞行模式,1.5,1 功能列表 息屏 分屏 亮度弱 亮度强 PrtSc 触摸板与方向控制按钮结合体,4,5";

        string secondLine = "QQ,1.5,1 kugou SougouExplore,2.5,1 office,1.5,1 lol,1.5,1 WebSiteLinks,6.5,1";

        string thirdLine = "财经 新闻 邮箱 FileExplore,2,1 天气 qq空间 微博 任务栏,2,1 关机,1.5,1 重启 睡眠 锁屏";

        string firthLine = "翻译,2,1 小娜,2,1 本地搜索,2,1 网络搜索,3,1 桌面,1.5,1 CloseAll,1.5,1 andSoOn,2.5,1";

        string fifthLine = "键盘切换条,14.5,1";


        List<SKey> keys = new List<SKey>();

        public SmartWindowsBoard()
        {

            keys.AddRange(Until.String2keys(auxiliaryFunctions));
            keys.AddRange(Until.String2keys(new Point(0,1) ,secondLine));
            keys.AddRange(Until.String2keys(new Point(0, 2), thirdLine));
            keys.AddRange(Until.String2keys(new Point(0, 3), firthLine));
            keys.AddRange(Until.String2keys(new Point(0, 4), fifthLine));
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
