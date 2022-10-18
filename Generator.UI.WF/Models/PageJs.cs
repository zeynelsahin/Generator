using System.Collections.Generic;
using System.Linq;
using Generator.Entities;
using Generator.UI.WF.Elements;
using Generator.UI.WF.JavaScriptGenerate;

namespace Generator.UI.WF.Models
{
    public class PageJs
    {
        public List<StaticMethod> StaticMethods { get; set; } = new List<StaticMethod>();
        public List<ApiRequestMethod> ApiRequestMethods { get; set; } = new List<ApiRequestMethod>();
        public GetGridApiMethod GetGridApiMethod { get; set; } = new GetGridApiMethod();
        public CreateApiMethod CreateApiMethod { get; set; }
        public UpdateApiMethod UpdateApiMethod { get; set; }
        public PageXml PageXml { get; set; } = null;
        public string PageName { get; set; }

        public override string ToString()
        {
            var javaScript = "(function () {\n";
            javaScript += ($"\"use strict\";\n").Tab(1);
            javaScript += ($"$$.{PageName}Controller = class {PageName}Controller extends $$.Controller").Tab(1);
            javaScript += " {\n";
            javaScript += ("constructor(view, page, context, prop);\n").Tab(2);
            javaScript += "\n";
            javaScript += ("Load() {\n").Tab(2);
            if (PageXml != null)
            {
                javaScript += ("this.$Prop.Update.Disable();\n").Tab(3);
                javaScript += ("this.$Prop.Add.Enable();\n").Tab(3);
                javaScript += ("this.$Prop.ValidFlag.SetValue(true)\n").Tab(3);

                var dateEntryCount = 1;
                var javaScriptDateSet = new List<string>();
                var rows = ((ContentBlock)(PageXml.Content)).Rows;
                foreach (var row in rows)
                {
                    var rowCount = row.Elements.Count - 1;
                    for (int i = rowCount; i >= 0; i--)
                    {
                        var col = row.Elements[i];
                        if (col.GetType() == typeof(DateEntry))
                        {
                            var propName = ((DateEntry)col).Id;
                            javaScriptDateSet.Add($"this.${propName}.SetValue(d.setMonth(d.getMonth() - {dateEntryCount}));");
                            dateEntryCount++;
                        }
                        else if (col.GetType() == typeof(DateTimeEntry))
                        {
                            var propName = ((DateTimeEntry)col).Id;
                            javaScriptDateSet.Add($"this.${propName}.SetValue(d.setMonth(d.getMonth() - {dateEntryCount}));");
                            dateEntryCount++;
                        }
                    }
                }

                const string dateFunc = "const d = new Date()";
                if (javaScriptDateSet.Count > 1)
                {
                    javaScript += "\n";
                    javaScript += "this.SetDateValue();";
                    var staticMethod = new StringStaticMethod();
                    javaScript += dateFunc.Tab(3);
                    javaScriptDateSet.ForEach(p =>
                    {
                        staticMethod.StaticMethod += "\n";
                        staticMethod.StaticMethod += p.Tab(3);
                    });
                    StaticMethods.Insert(0, staticMethod);
                }
                else if (javaScriptDateSet.Count == 1)
                {
                    javaScript += "\n";
                    javaScript += dateFunc.Tab(3);
                    javaScript += "\n";
                    javaScript += javaScriptDateSet[0].Tab(3);
                }
            }

            javaScript += "\n";
            if (GetGridApiMethod != null)
            {
                javaScript += ($"this.{GetGridApiMethod.MethodName}();").Tab(3);
            }

            if (ApiRequestMethods.Count > 1)
            {
                javaScript += "\n";
                javaScript += "this.FillCombos();".Tab(3);
                javaScript+="\n";
                javaScript+="}\n".Tab(2);
                javaScript += ("FillCombos() {\n").Tab(2);
                javaScript = ApiRequestMethods.Aggregate(javaScript, (current, requestMethod) => current + ($"this.{requestMethod.MethodName}();\n").Tab(3));
                javaScript += "}".Tab(2);
            }
            else
            {
                javaScript += "\n";
                javaScript += ("}\n").Tab(2);
            }

            if (StaticMethods.Count > 0) javaScript = StaticMethods.Aggregate(javaScript, (current, staticMethod) => current + staticMethod.ToString());
            javaScript = ApiRequestMethods.Aggregate(javaScript, (current, requestMethod) => current + requestMethod.ToString());
            if (GetGridApiMethod != null) javaScript += GetGridApiMethod.ToString();
            if (CreateApiMethod != null) javaScript += CreateApiMethod.ToString();
            if (UpdateApiMethod != null) javaScript += UpdateApiMethod.ToString();
            javaScript += "\n";
            javaScript += "EventHandler(eventName, arg1) {\n".Tab(2);
            javaScript += "var recordInfo = arg1;\n".Tab(3);
            javaScript += "switch (eventName) {\n".Tab(3);
            javaScript += "case 'Clear':\n".Tab(4);
            javaScript += "this.$Page.Clear();\n".Tab(5);
            javaScript += "this.$Prop.Add.Enable();\n".Tab(5);
            javaScript += "this.$Prop.Update.Disable();\n".Tab(5);
            javaScript += "this.$Prop.ValidFlag.SetValue(true);\n".Tab(5);
            if (GetGridApiMethod != null) javaScript += $"this.{GetGridApiMethod.MethodName}();\n".Tab(5);
            javaScript += "break;\n".Tab(5);

            javaScript += "case 'Close':\n".Tab(4);
            javaScript += "this.$View.Close();\n".Tab(5);
            javaScript += "break;\n".Tab(5);
            if (GetGridApiMethod != null)
            {
                javaScript += "case 'List':\n".Tab(4);
                javaScript += $"this.{GetGridApiMethod.MethodName}();\n".Tab(5);
                javaScript += "break;\n".Tab(5);
            }

            if (CreateApiMethod != null)
            {
                javaScript += "case 'Add':\n".Tab(4);
                javaScript += $"this.{CreateApiMethod.MethodName}();\n".Tab(5);
                javaScript += "break;\n".Tab(5);
            }

            if (UpdateApiMethod != null)
            {
                javaScript += "case 'Update':\n".Tab(4);
                javaScript += $"this.{UpdateApiMethod.MethodName}();\n".Tab(5);
                javaScript += "break;\n".Tab(5);
            }

            javaScript += "}\n".Tab(3);
            javaScript += "}\n".Tab(2);
            javaScript += "}\n".Tab(1);
            javaScript += "})();";
            return javaScript;
        }
    }
}