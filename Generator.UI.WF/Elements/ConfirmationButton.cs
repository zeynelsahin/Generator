using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Generator.UI.WF.Elements
{
    public class ConfirmationButton : BaseElement
    {
        public string ActionCode { get; set; }

        public string Message { get; set; }

        public string IconCss { get; set; }

        public string TypeCss { get; set; }

        public string Alignment { get; set; }

        public List<ConfirmationItem> ConfirmationItems { get; set; }

        public override string ToString()
        {
            string xml =
                $"\n<confirmation-button id=\"BtnBatchFix\" action-code=\"BtnBatchFix\" message=\"Are you sure you want to update?\" icon-css=\"save\" text=\"Toplu Düzelt\" type-css=\"Success\" alignment=\"Right\">";
            ConfirmationItems.ForEach(item =>
            {
                xml += $"<confirmation-item confirmation-button=\"{item.ConfirmationButton}\"";
                if (item.ActionCode != null)
                {
                    xml += $" action-code=\"{ActionCode}\"/>";
                }
            });

            xml += "</confirmation-button>";
            return xml;
        }
    }
}