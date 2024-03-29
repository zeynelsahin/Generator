﻿namespace Generator.UI.WF.Elements
{
    public class Column : BaseElement //Grid Sütunu
    {
        public string FieldId { get; set; }
        public string Witdh { get; set; }
        public LinkButton LinkButton { get; set; }

        public override string ToString()
        {
            var xml = "";
            if (LinkButton == null)
            {
                xml += "\n";
                xml += $"<col id=\"{Id}\" field-id=\"{FieldId}\" text=\"{Text}\" width=\"{Witdh}\"".Tab(6); ;
                if (Alignment != null)
                    xml += $" alignment=\"{Alignment}\"/>";
                else
                    xml += "/>";
                return xml;
            }

            xml += "\n";
            xml += $"<col id=\"{Id}\" field-id=\"{FieldId}\" text=\"{Text}\" width=\"{Witdh}\"".Tab(6); ;
            if (Alignment != null)
                xml += $" alignment=\"{Alignment}\">";
            else
                xml += "/>";
            xml += LinkButton.ToString();
            xml += "\n";
            xml += "</col>".Tab(6);
            return xml;
        }
    }
}