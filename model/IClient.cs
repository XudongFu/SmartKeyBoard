using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartKeyboard2.laptop
{
    interface IClient
    {

        /// <summary>
        /// 做成单例模式
        /// </summary>
        /// <returns></returns>
        IClient GetInstance();

        /// <summary>
        /// 向键盘界面发送键盘的布局
        /// </summary>
       void SendView(object view);

        /// <summary>
        /// 键盘切换到相应的布局
        /// </summary>
        /// <param name="ViewID"></param>
       void SwitchView(object ViewID);

        /// <summary>
        /// 键盘按键被点击时触发
        /// </summary>
         EventHandler KeyPress { get; set; }

         object GetCurentViewID();


    }
}
