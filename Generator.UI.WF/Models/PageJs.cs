using System.Collections.Generic;
using System.Linq;
using Generator.UI.WF.JavaScriptGenerate;

namespace Generator.UI.WF.Models
{
    public class PageJs
    {
        public List<ApiRequestMethod> ApiRequestMethods { get; set; }
        public GetGridApiMethod GetGridApiMethod { get; set; } = new GetGridApiMethod();
        public CreateApiMethod CreateApiMethod { get; set; }
        public UpdateApiMethod UpdateApiMethod { get; set; }
        public PageXml PageXml { get; set; } = null;
        public string PageName { get; set; }

        public override string ToString()
        {
            var javaScript = "(function () {";

            javaScript += $"\n   \"use strict\";\n";
            javaScript += $"$$.{PageName}Controller = class {PageName}Controller extends $$.Controller";
            javaScript += "{\n   constructor(view,page,context,prop);\n";
            javaScript += "\nLoad() {\n";
            if (PageXml != null)
            {
                javaScript += "this.$Prop.Update.Disable();\n";
                javaScript += "this.$Prop.Add.Enable();\n";
                javaScript += "this.$Prop.ValidFlag.SetValue(true)\n";
            }

            if (GetGridApiMethod != null)
            {
                javaScript += $"this.{GetGridApiMethod.MethodName}();";
            }

            if (ApiRequestMethods.Count > 1)
            {
                javaScript += "this.FillCombos();\n}\n";
                javaScript += "FillCombos() {\n";
                javaScript = ApiRequestMethods.Aggregate(javaScript, (current, requestMethod) => current + $"this.{requestMethod.MethodName}();\n");
                javaScript += "}\n";
            }
            else
            {
                javaScript += "\n}\n";
            }

            javaScript = ApiRequestMethods.Aggregate(javaScript, (current, requestMethod) => current + requestMethod.ToString());
            if (GetGridApiMethod != null) javaScript += GetGridApiMethod.ToString();
            if (CreateApiMethod != null) javaScript += CreateApiMethod.ToString();
            if (UpdateApiMethod != null) javaScript += UpdateApiMethod.ToString();

            javaScript += "\nEventHandler(eventName, arg1) {\n";
            javaScript += "var recordInfo = arg1;\n";
            javaScript += "switch (eventName) {\n";
            javaScript += "  case 'Clear':\n";
            javaScript += "this.$Page.Clear();\n";
            javaScript += "this.$Prop.Add.Enable();\n";
            javaScript += "this.$Prop.Update.Disable();\n";
            javaScript += "this.$Prop.ValidFlag.SetValue(true);\n";
            if (GetGridApiMethod != null) javaScript += $"this.{GetGridApiMethod.MethodName}();\n";
            javaScript += "break;\n";
            javaScript += "";
            javaScript += "  case 'Close':\n";
            javaScript += "this.$View.Close();\n";
            javaScript += "break;\n";
            if (GetGridApiMethod != null)
            {
                javaScript += "  case 'List':\n";
                javaScript += $"this.{GetGridApiMethod.MethodName}();\n";
                javaScript += "break;\n";
            }
            if (CreateApiMethod != null)
            {
                javaScript += "  case 'Add':\n";
                javaScript += $"this.{CreateApiMethod.MethodName}();\n";
                javaScript += "break;\n";
            }
            if (UpdateApiMethod != null)
            {
                javaScript += "  case 'Update':\n";
                javaScript += $"this.{UpdateApiMethod.MethodName}();\n";
                javaScript += "break;\n";
            }
            javaScript+="}\n}\n}\n})();";
            return javaScript;
        }
    }
}