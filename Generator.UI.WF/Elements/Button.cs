using System;
using System.Collections.Generic;
using System.Text;
using Generator.UI.WF.Models;

namespace Generator.UI.WF.Elements
{
    public class Button: BaseElement
    {
        public string ActionCode { get; set; }
        public string TypeCss { get; set; }
        public string IconCss { get; set; }
        public override string ToString()
        {
            return $"\n<button id=\"{Id}\" text=\"{Text}\" action-code=\"{ActionCode}\" type-css=\"{TypeCss}\" alignment=\"{Alignment}\" icon-css=\"{IconCss}\"/> " ;
        }
    }
}
