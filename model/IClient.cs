using SmartKeyboard2.model;
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
        /// 向键盘界面发送键盘的布局
        /// </summary>
       void SendView(IView view);

        /// <summary>
        /// 键盘切换到相应的布局
        /// </summary>
        /// <param name="ViewID"></param>
       void SwitchView(object ViewID);


        void RenderIOBar(String VIewID);

        void RenderTaskBar(String VIewID);


        /// <summary>
        /// 键盘按键被点击时触发
        /// </summary>
        EventHandler KeyPress { get; set; }

        string GetCurentViewID();

        /// <summary>
        /// 接口初始化函数
        /// </summary>
        void Initlize();

    }
}
