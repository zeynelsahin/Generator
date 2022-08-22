using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.UI.WF.Elements
{
    public class DataEntry: BaseElement
    {
        public override string ToString()
        {
            return $"\n<data-entry id=\"{Id}\" text=\"{Text}\"/>";
        }
    }
}
