using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartKeyboard2
{
  public class SKeyInfo:EventArgs
  {
        public string Key;

        public string Value;

        public string Type;

        public string Text;

        public SKeyInfo(string key,string text,string value,string type)
        {
            Text = text;
            this.Key = key;
            Value = value;
            Type = type;
        }

        internal SKeyInfo()
        {
        }

  }
}
