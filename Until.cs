using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartKeyboard2
{
    class Until
    {

        public void SendInfo(char key)
        {

        }

        public void SendInfo(string key)
        {

        }

        public void SendControlKey()
        {

        }

        public static List<SKey> String2keys(string valuekey)
        {
            List<SKey> keys = new List<SKey>();
            List<string> characters = valuekey.Split('\r').ToList();
            int i = 0;
            foreach (var x in characters)
            {
                float _width = 0;
                foreach (var value in x.Split(' '))
                {
                    switch (value)
                    {
                        default:
                            {
                                SKey key;

                                if (value == ",")
                                {
                                    key = new SKey(value, new System.Drawing.RectangleF(_width++, i, 1, 1))
                                    {
                                        Text = value,
                                        value = value,
                                        type = "char",
                                    };
                                }
                                else
                                {
                                    string[] infor = value.Split(',');
                                    if (infor.Length == 3)
                                    {
                                        key = new SKey(infor[0], new System.Drawing.RectangleF(_width, i, float.Parse(infor[1]), float.Parse(infor[2])))
                                        {
                                            Text = infor[0],
                                            value = infor[0],
                                            type = "char",
                                        };
                                        _width += float.Parse(infor[1]);
                                    }
                                    else
                                    {
                                        key = new SKey(value, new System.Drawing.RectangleF(_width++, i, 1, 1))
                                        {
                                            Text = value,
                                            value = value,
                                            type = "char",
                                        };
                                    }
                                }
                                keys.Add(key);
                                break;
                            }
                    }
                }
                i++;
            }
            return keys;
        }

        public static List<SKey> String2keys(PointF f, string valuekey,float width=1)
        {
            List<SKey> keys = new List<SKey>();

            List<string> characters = valuekey.Split('\r').ToList();
            int i = (int)f.Y;
            foreach (var x in characters)
            {
                float _width = f.X;
                foreach (var value in x.Split(' '))
                {
                    switch (value)
                    {
                        default:
                            {
                                SKey key;

                                if (value == ",")
                                {
                                    key = new SKey(value, new System.Drawing.RectangleF(_width++, i, width, 1))
                                    {
                                        Text = value,
                                        value = value,
                                        type = "char",
                                    };
                                }
                                else
                                {
                                    string[] infor = value.Split(',');
                                    if (infor.Length == 3)
                                    {
                                        key = new SKey(infor[0], new System.Drawing.RectangleF(_width, i, float.Parse(infor[1]), float.Parse(infor[2])))
                                        {
                                            Text = infor[0],
                                            value = infor[0],
                                            type = "char",
                                        };
                                        _width += float.Parse(infor[1]);
                                    }
                                    else
                                    {
                                        key = new SKey(value, new System.Drawing.RectangleF(_width++, i, width, 1))
                                        {
                                            Text = value,
                                            value = value,
                                            type = "char",
                                        };
                                    }
                                }
                                keys.Add(key);
                                break;
                            }
                    }
                }
                i++;
            }
            return keys;
        }
       
    }
}
