using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.UI.WF.Elements
{
    public class TextBox: BaseElement
    {
        public override string ToString()
        {
            return $"\n<textbox id={Id}\" text=\"{Text}\" />";
        }
    }
}
