using System.Collections.Generic;

namespace Generator.UI.WF.Elements
{
    public class RowTemplate
    {
        public List<Column> Columns { get; set; }
        public override string ToString()
        {
            string rowTemplate = "";
            Columns.ForEach(p =>
            {
                rowTemplate += p.ToString();
            });
            return "\n<row-template>"+rowTemplate+"<\n/row-template>";
        } 
    }
}