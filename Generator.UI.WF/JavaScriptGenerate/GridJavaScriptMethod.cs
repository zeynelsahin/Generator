using System;

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
            return GetGridApiMethod.ToString()+CreateApiMethod.ToString()+UpdateApiMethod.ToString();
        }
    }
}