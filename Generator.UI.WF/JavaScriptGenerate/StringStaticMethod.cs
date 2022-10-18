namespace Generator.UI.WF.JavaScriptGenerate
{
    public class StringStaticMethod: StaticMethod
    {
        public string StaticMethod { get; set; }
        public override string ToString()
        {
            return StaticMethod;
        }
    }
    
}