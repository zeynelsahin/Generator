using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.UI.WF
{
    internal static class StringManipulationExtension
    {
        public static List<string> NameConfigure(this List<string> resultList)
        {
            var configureName = new List<string>();
            for (var i = 0; i < resultList.Count; i++)
            {
                var st = resultList[i].ToLower();
                var yeniSt = "";
                for (var j = 0; j < st.Length; j++)
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

                        if (st[j] != Convert.ToChar("_")) yeniSt += st[j];
                    }

                configureName.Add(yeniSt);
                yeniSt = "";
            }

            return configureName;
        }

        public static string NameConfigure(this string result)
        {
            var st = result.ToLower();
            var yeniSt = "";
            for (var j = 0; j < st.Length; j++)
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

                    if (st[j] != Convert.ToChar("_")) yeniSt += st[j];
                }

            return yeniSt;
        }

        public static string TextConfigure(this string id)
        {
            var st = id.ToLower();
            var yeniSt = "";
            for (var j = 0; j < st.Length; j++)
                if (j == 0)
                {
                    yeniSt += st[0].ToString().ToUpper();
                }
                else
                {
                    if (st[j - 1] == Convert.ToChar("_"))
                        yeniSt += st[j].ToString().ToUpper();
                    else
                        yeniSt += st[j];
                }

            return yeniSt.Replace("_", " ");
        }

        public static string CamelCaseConfigure(this string result)
        {
            var st = result.ToLower();
            var yeniSt = "";
            for (var j = 0; j < st.Length; j++)
            {
                if (j == 0)
                {
                    yeniSt += st[0].ToString();
                }
                else
                {
                    if (st[j - 1] == Convert.ToChar("_"))
                    {
                        yeniSt += st[j].ToString().ToUpper();
                        continue;
                    }

                    if (st[j] != Convert.ToChar("_")) yeniSt += st[j];
                }
            }


            return yeniSt;
        }

        public static string SpaceCamelCaseConfigure(this string result)
        {
            var st = result;
            var yeniSt = "";
            for (var j = 0; j < st.Length; j++)
            {
                if (j == 0)
                {
                    yeniSt += st[0].ToString();
                }
                else
                {
                    if (st[j - 1] == Convert.ToChar(" "))
                    {
                        yeniSt += st[j].ToString().ToUpper();
                        continue;
                    }

                    yeniSt += st[j];
                }
            }


            return yeniSt;
        }
        public static string UnifiedCaseConfigure(this string result)
        {
            var st = result;
            var yeniSt = "";
            for (var j = 0; j < st.Length; j++)
            {
                if (j == 0)
                {
                    yeniSt += st[0].ToString().ToLower();
                }
                else
                {
                    yeniSt += st[j];
                }
            }

            return yeniSt;
        }
    }
}