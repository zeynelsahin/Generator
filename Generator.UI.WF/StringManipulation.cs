using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.UI.WF
{
    static class StringManipulationExtension
    {
        static public List<string> NameConfigure(this List<string> resultList)
        {
            List<string> configureName = new List<string>();
            for (int i = 0; i < resultList.Count; i++)
            {
                var st = resultList[i].ToLower();
                string yeniSt = "";
                for (var j = 0; j < st.Length; j++)
                {
                    if (j == 0)
                    {
                        yeniSt += st[0].ToString().ToUpper();
                    }
                    else
                    {
                        if (st[j - 1] == Convert.ToChar("_"))
                        {
                            yeniSt += st[j].ToString().ToUpper();
                            continue;
                        }
                        if (st[j] != Convert.ToChar("_"))
                        {
                            yeniSt += st[j];
                        }
                    }

                }

                configureName.Add(yeniSt);
                yeniSt = "";
            }
            return configureName;
        }
        static public string NameConfigure(this string result)
        {
            var st = result.ToLower();
            string yeniSt = "";
            for (var j = 0; j < st.Length; j++)
            {
                if (j == 0)
                {
                    yeniSt += st[0].ToString().ToUpper();
                }
                else
                {
                    if (st[j - 1] == Convert.ToChar("_"))
                    {
                        yeniSt += st[j].ToString().ToUpper();
                        continue;
                    }
                    if (st[j] != Convert.ToChar("_"))
                    {
                        yeniSt += st[j];
                    }
                }

            }

            return st;
        }
    }
}
