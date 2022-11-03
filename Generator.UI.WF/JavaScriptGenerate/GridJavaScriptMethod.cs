namespace Generator.UI.WF.JavaScriptGenerate
{
    public class GridJavaScriptMethod
    {
        public GetGridApiMethod GetGridApiMethod { get; set; } 
        public UpdateApiMethod UpdateApiMethod { get; set; }
        public CreateApiMethod CreateApiMethod { get; set; }
        public DeleteApiMethod DeleteApiMethod { get; set; }

        public override string ToString()
        {
            var javaScript = "";
            if (GetGridApiMethod != null) javaScript += GetGridApiMethod.ToString();
            if (UpdateApiMethod != null) javaScript += UpdateApiMethod.ToString();
            if (CreateApiMethod != null) javaScript += CreateApiMethod.ToString();
            return javaScript;
        }
    }
}