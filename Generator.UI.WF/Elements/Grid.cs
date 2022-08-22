using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.UI.WF.Elements
{
    public class Grid
    {
        public string ShowStatus { get; set; }
        public string Height { get; set; }

        public List<Field> Fields { get; set; } = null;
        public List<Column> Columns { get; set; } = null;

        public override string ToString()
        {
            var grid = "";
            grid = $"<grid-view>";
            grid += $"\n<command-bar show-searchbox=\"true\" excel-export=\"true\"/>";
            if (Fields != null)
            {
                grid += "\n<model>";

                Fields.ForEach(field => { grid += field.ToString(); });
                grid += "\n</model>";
            }

            if (Columns != null)
            {
                grid += "\n<row-template>";

                Columns.ForEach(column => { grid += column.ToString(); });
                grid += "\n<row-template/>";
            }
            grid += "</grid-view>";
            return grid;
        }
    }
}