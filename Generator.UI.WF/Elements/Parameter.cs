using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.UI.WF.Elements
{
    public class Parameter
    {
        public string Key { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return $"<parameter key=\"{Key}\">{Text}</parameter> ";
        }
    }
}