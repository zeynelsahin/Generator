using System.Collections.Generic;
using System.Linq;
using Generator.UI.WF.Elements;
using Generator.UI.WF.JavaScriptGenerate;

namespace Generator.UI.WF.Models
{
    public class PageJs
    {
        public List<StaticMethod> StaticMethods { get; set; } = new List<StaticMethod>();
        private List<StaticMethod> DateTimeMethod { get; } = new List<StaticMethod>();
        public List<ApiRequestMethod> ApiRequestMethods { get; set; } = new List<ApiRequestMethod>();
        public GetGridApiMethod GetGridApiMethod { get; set; } = new GetGridApiMethod();
        public CreateApiMethod CreateApiMethod { get; set; }
        public UpdateApiMethod UpdateApiMethod { get; set; }
        public PageXml PageXml { get; set; } = null;
        public string PageName { get; set; }
        private EventHandler EventHandler { get; set; } = new EventHandler();

        public override string ToString()
        {
            var javaScript = "(function () {\n";
            javaScript += "\"use strict\";\n".Tab(1);
            javaScript += $"$$.{PageName}Controller = class {PageName}Controller extends $$.Controller".Tab(1);
            javaScript += " {\n";
            javaScript += "constructor(view, page, context, prop) {\n".Tab(2);
            javaScript += "super(view, page, context, prop);".Tab(3);
            javaScript += "\n";
            javaScript += "}".Tab(2);
            javaScript += "\n";
            javaScript += "Load() {\n".Tab(2);

            if (PageXml != null)
            {
                if (((PageHeader)PageXml.Header).Buttons.Any(p => p.Id == "Update"))
                    javaScript += "this.$Prop.Update.Disable();\n".Tab(3);
                if (((PageHeader)PageXml.Header).Buttons.Any(p => p.Id == "Add"))
                    javaScript += "this.$Prop.Add.Enable();\n".Tab(3);
                if (((ContentBlock)PageXml.Content).Rows.ToString().Contains("ValidFlag"))
                    javaScript += "this.$Prop.ValidFlag.SetValue(true)\n".Tab(3);

                var dateEntryCount = 1;
                var javaScriptDateSet = new List<string>();
                var rows = ((ContentBlock)PageXml.Content).Rows;

                foreach (var row in rows)
                {
                    var rowCount = row.Elements.Count - 1;
                    for (var i = rowCount; i >= 0; i--)
                    {
                        var col = row.Elements[i];
                        var colType = ((Col)col).Element.GetType();
                        if (colType == typeof(DateEntry))
                        {
                            var propName = ((DateEntry)((Col)col).Element).Id;

                            javaScriptDateSet.Add(
                                $"this.${propName}.SetValue(d.setMonth(d.getMonth() - {dateEntryCount}));");
                            dateEntryCount++;
                        }
                        else if (colType == typeof(DateTimeEntry))
                        {
                            var propName = ((DateTimeEntry)((Col)col).Element).Id;
                            javaScriptDateSet.Add(
                                $"this.${propName}.SetValue(d.setMonth(d.getMonth() - {dateEntryCount}));");
                            dateEntryCount++;
                        }
                    }
                }

                if (javaScriptDateSet.Count > 0)
                {
                    javaScript += "this.SetDateValue();".Tab(3);
                    javaScript += "\n";
                    const string dateFunc = "const d = new Date()";
                    var staticMethod = new StringStaticMethod
                    {
                        MethodName = "SetDateValue"
                    };

                    staticMethod.StaticMethod += dateFunc.Tab(3);
                    javaScriptDateSet.ForEach(p =>
                    {
                        staticMethod.StaticMethod += "\n";
                        staticMethod.StaticMethod += p.Tab(3);
                    });
                    DateTimeMethod.Add(staticMethod);
                }
            }

            if (ApiRequestMethods.Count > 0)
            {
                javaScript += "this.FillCombos();".Tab(3);
                javaScript += "\n";
            }

            if (GetGridApiMethod != null) javaScript += $"this.{GetGridApiMethod.MethodName}();".Tab(3);

            javaScript += "\n";
            javaScript += "}".Tab(2);
            if (ApiRequestMethods.Count > 0)
            {
                javaScript += "\n";
                javaScript += "FillCombos() {\n".Tab(2);
                javaScript = ApiRequestMethods.Aggregate(javaScript,
                    (current, requestMethod) => current + $"this.{requestMethod.MethodName}();\n".Tab(3));
                javaScript = StaticMethods.Aggregate(javaScript,
                    (current, requestMethod) => current + $"this.{requestMethod.MethodName}();\n".Tab(3));
                javaScript += "}".Tab(2);
                javaScript += "\n";
            }

            if (DateTimeMethod.Count > 0)
                javaScript = DateTimeMethod.Aggregate(javaScript, (current, method) => current + method);

            if (StaticMethods.Count > 0)
                javaScript = StaticMethods.Aggregate(javaScript,
                    (current, staticMethod) => current + ("\n" + staticMethod));
            javaScript = ApiRequestMethods.Aggregate(javaScript,
                (current, requestMethod) => current + requestMethod);
            if (GetGridApiMethod != null) javaScript += GetGridApiMethod.ToString();
            if (CreateApiMethod != null) javaScript += CreateApiMethod.ToString();
            if (UpdateApiMethod != null) javaScript += UpdateApiMethod.ToString();
            javaScript += "\n";

            //Events
            // javaScript += "case 'Clear':\n".Tab(4);
            // javaScript += "this.$Page.Clear();\n".Tab(5);
            // javaScript += "this.$Prop.Add.Enable();\n".Tab(5);
            // javaScript += "this.$Prop.Update.Disable();\n".Tab(5);
            // javaScript += "this.$Prop.ValidFlag.SetValue(true);\n".Tab(5);
            var clearEvent = new Event { EventName = "Clear" };
            clearEvent.Content += "this.$Page.Clear();\n".Tab(5);
            clearEvent.Content += "this.$Prop.Add.Enable();\n".Tab(5);
            clearEvent.Content += "this.$Prop.Update.Disable();\n".Tab(5);
            if (((ContentBlock)PageXml.Content).Rows.ToString().Contains("ValidFlag"))
                clearEvent.Content += "this.$Prop.ValidFlag.SetValue(true);\n".Tab(5);
            EventHandler.Events.Add(clearEvent);


            EventHandler.Events.Add(new Event
            {
                EventName = "Close",
                Content = "this.$View.Close();\n".Tab(5)
            });

            if (GetGridApiMethod != null)
                EventHandler.Events.Add(new Event
                {
                    EventName = "List",
                    Content = $"this.{GetGridApiMethod.MethodName}();\n".Tab(5)
                });

            if (CreateApiMethod != null)
                EventHandler.Events.Add(new Event
                {
                    EventName = "Add",
                    Content = $"this.{CreateApiMethod.MethodName}();\n".Tab(5)
                });

            if (UpdateApiMethod != null)
                EventHandler.Events.Add(new Event
                {
                    EventName = "Update",
                    Content = $"this.{UpdateApiMethod.MethodName}();\n".Tab(5)
                });
            javaScript += EventHandler.ToString();
            javaScript += "}\n".Tab(3);
            javaScript += "}\n".Tab(2);
            javaScript += "}\n".Tab(1);
            javaScript += "})();";
            return javaScript;
        }
    }
}