using System.Collections.Generic;
using Generator.UI.WF.Models;

namespace Generator.UI.WF.Elements
{
    public class Row
    {
        public List<IElement> Elements { get; set; }//Şuanlık col list
        public override string ToString()
        {
            string xml = "";
            
            Elements.ForEach(element =>
            {
                xml+=element.ToString();
            });
            return xml;
        }
    }
}