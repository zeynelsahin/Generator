﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;

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

        public static char ConvertChar(this object value)
        {
            if ((bool)value)
            {
                return '1';
            }
            else
            {
                return '0';
            }
        }

        public static string RemoveGet(this string result)
        {
            var index = result.ToLower().IndexOf("get");
            if (index != -1)
            {
                result = result.Substring(3);
            }

            return result;
        }

        public static string Tab(this string javaScript, int tabCount)
        {
            var javaSrciptNew = "";
            for (int i = 0; i < tabCount; i++)
            {
                javaSrciptNew += "    ";
            }
            return javaSrciptNew + javaScript;
        }

        public static string GridNameConfig(this string name)
        {
            if (name.IndexOf("Get") != -1)
                name = name.Substring(3);
            else if (name.IndexOf("Modify") != -1)
                name = name.Substring(6);
            else if (name.IndexOf("Create") != -1)
                name = name.Substring(6);
            var index = name.IndexOf("ByCustom");
            if (index != -1)
                name = name.Substring(0,index);
            return name;
        }

    }
}