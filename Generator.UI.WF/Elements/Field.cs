using Generator.UI.WF.Enums;

namespace Generator.UI.WF.Elements
{
    public class Field : BaseElement //Grid Sütunlarının Veri Tipleri Ayarı
    {
        public Types Type { get; set; }
        public string DataSource { get; set; }

        public override string ToString()
        {
            return $"\n<field id=\"{Id}\" data-source=\"{DataSource}\" type=\"{Type}\"></field>";
        }
    }
}