using Generator.UI.WF.Enums;

namespace Generator.UI.WF.Elements
{
    public class Field : BaseElement //Grid Sütunlarının Veri Tipleri Ayarı
    {
        public Types? Type { get; set; }
        public string DataSource { get; set; }

        public override string ToString()
        {
            var xml = "\n";
            if (Type != null)
                xml += $"<field id=\"{Id}\" data-source=\"{DataSource}\" type=\"{Type}\"></field>".Tab(6);
            else
                xml += $"<field id=\"{Id}\" data-source=\"{DataSource}\"></field>".Tab(6);
            return xml;
        }
    }
}