using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartKeyboard2.model
{

    /// <summary>
    /// 键盘布局需要实现的函数，定义统一的调用结构。
    /// 即使是xml文件，也需要转换为这种结构的实例再进行调用。
    /// </summary>
   public  abstract class  IView
    {
        /// <summary>
        /// 获取要响应的程序的名称。
        /// </summary>
        /// <returns></returns>
        public abstract String GetApplicationName();


        /// <summary>
        /// 指定View被渲染的位置。
        /// </summary>
        public ViewType type;

        /// <summary>
        /// 获取布局的按键信息
        /// </summary>
        /// <returns></returns>
        public abstract KeyUnit GetKeysUnit();


        EventHandler KeyPress;
        

    }


   public  enum ViewType
    {
        FunctionBar,
        IOBar

    }








}
