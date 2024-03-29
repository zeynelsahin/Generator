﻿using System;
using System.Collections.Generic;
using System.Linq;

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

                        if (st[j] != Convert.ToChar("_")) yeniSt += st[j].EnglishConfigure();
                    }

                configureName.Add(yeniSt.UpperCaseEnglish());
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

                    if (st[j] != Convert.ToChar("_")) yeniSt += st[j].EnglishConfigure();
                }

            return yeniSt.UpperCaseEnglish();
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
                        yeniSt += st[j].EnglishConfigure();
                }

            return yeniSt.Replace("_", " ").UpperCaseEnglish();
        }

        public static string CamelCaseConfigure(this string result)
        {
            var st = result.ToLower();
            var yeniSt = "";
            for (var j = 0; j < st.Length; j++)
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

                    if (st[j] != Convert.ToChar("_")) yeniSt += st[j].EnglishConfigure();
                }

            return yeniSt.UpperCaseEnglish();
        }

        public static string SpaceCamelCaseConfigure(this string result)
        {
            var st = result;
            var yeniSt = "";
            for (var j = 0; j < st.Length; j++)
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

                    yeniSt += st[j].EnglishConfigure();
                }

            return yeniSt.UpperCaseEnglish();
        }

        public static string UnifiedCaseConfigure(this string result)
        {
            var st = result;
            var yeniSt = "";
            for (var j = 0; j < st.Length; j++)
                if (j == 0)
                    yeniSt += st[0].ToString().ToLower();
                else
                    yeniSt += st[j];

            return yeniSt;
        }

        public static char ConvertChar(this object value)
        {
            if ((bool)value)
                return '1';
            return '0';
        }

        public static string RemoveGet(this string result)
        {
            var index = result.ToLower().IndexOf("get");
            if (index != -1) result = result[3..];
            return result;
        }

        public static string RemoveCreate(this string result)
        {
            var index = result.ToLower().IndexOf("create");
            if (index != -1) result = result[6..];
            return result;
        }

        public static string RemoveUpdate(this string result)
        {
            var index = result.ToLower().IndexOf("update");
            if (index != -1) result = result[6..];
            return result;
        }

        public static string RemoveBy(this string result)
        {
            var index = result.ToLower().IndexOf("by");
            if (index != -1) result = result[..index];
            var asd = "sdf";
            return result;
        }

        public static string Tab(this string javaScript, int tabCount)
        {
            var javaSrciptNew = "";
            for (var i = 0; i < tabCount; i++) javaSrciptNew += "\t";

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
                name = name.Substring(0, index);
            return name;
        }

        public static string ConvertUtf8(this string json)
        {
            json = json.Replace("\\u011F", "ğ");
            json = json.Replace("\\u011E", "Ğ");
            json = json.Replace("\\u00E7", "ç");
            json = json.Replace("\\u00C7", "Ç");
            json = json.Replace("\\u00f6", "ö");
            json = json.Replace("\\u00D6", "Ö");
            json = json.Replace("\\u015F", "ş");
            json = json.Replace("\\u0131", "ı");
            json = json.Replace("\\u00FC", "ü");
            json = json.Replace("\\u00DC", "ü");
            return json;
        }

        public static string TitleConfig(this string text)
        {
            var textNew = "";
            var first = true;
            foreach (var c in text)
            {
                if (first && c.ToString() != " ")
                {
                    first = false;
                    textNew += c;
                }
                else
                {
                    if (c.ToString() == c.ToString().ToUpper() && c.ToString() != " ") textNew += " ";
                    textNew += c;
                }
            }

            return textNew;
        }

        public static List<string> DarkListRemove(this List<string> list)
        {
            var dartList = new List<string>(){ "InsertDate","InsertUserId","InsertTokenId","UpdateDate","UpdateUserId","UpdateTokenId" };
            return list.Where(p => !dartList.Contains(p)).ToList();
        }

        public static char EnglishConfigure(this char text)
        {
            if (text =='ı' || text=='I')
            {
                return 'i';
            }
            return text;
        }
        public static string UpperCaseEnglish(this string text)
        {
            return text.Replace("İ", "I");
        }
    }
}