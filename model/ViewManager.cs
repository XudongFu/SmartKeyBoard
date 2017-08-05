using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartKeyboard2.model
{

    /// <summary>
    /// server通过这个类区获取相应的实现IView的实例。
    /// </summary>
    class ViewManager
    {
        private static  ViewManager _view;

        public static ViewManager GetInstance()
        {
            if (_view == null)
                _view = new ViewManager();
            return _view;
        }


        public List<IView> GetAllViews()
        {
            return new List<IView>();
        }

    }
}
