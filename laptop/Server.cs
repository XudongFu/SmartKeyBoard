using SmartKeyboard2.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartKeyboard2.laptop
{
    abstract class Server
    {



        Dictionary<string, IView> AppViews = new Dictionary<string, IView>();


        IClient client;


        Dictionary<string, bool> sent = new Dictionary<string, bool>();
       
        
        /// <summary>
        /// 
        /// </summary>
        EventHandler AppChanged;
        /// <summary>
        /// 需要做的事情，获取实现Iclient接口的类，
        /// 获取当前获得焦点的程序，
        /// 获取viewmanager的实例，去获取相应的实例
        /// 检查是否含有该界面的view，含有的话，切换到那个view，
        /// 解析那个view的数据，向IClient挂载相应的处理函数。
        /// </summary>
        void Main()
        {
            ViewManager manager = ViewManager.GetInstance();
            var views = manager.GetAllViews();
            views.ForEach(x =>
            {
                AppViews.Add(x.GetApplicationName(),x);
            });

            AppChanged += (sender,info)=>{
                AppChangedInfo changeInfo=(AppChangedInfo)info;
                string appName = changeInfo.AppChangedName;
                if (sent.ContainsKey(appName) && sent[appName])
                {
                    client.SwitchView(appName);
                }
                else
                {
                    client.SendView(AppViews[appName]);
                    client.SwitchView(appName);
                }
            };
        }       
    }


    class AppChangedInfo:EventArgs
    {
        public string AppChangedName;

       public  AppChangedInfo(string name)
        {
            AppChangedName = name;
        }
    }








}
