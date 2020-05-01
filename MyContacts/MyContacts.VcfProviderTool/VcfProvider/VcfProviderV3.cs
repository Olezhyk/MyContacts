using System.Collections.Generic;
using MyContacts.VcfProviderTool.Interfaces;
using MyContacts.VcfProviderTool.Models;

namespace MyContacts.VcfProviderTool.VcfProvider
{
    public class VcfProviderV3 : VcfProviderBase, IVcfProvider
    {
        protected override string BuildVcfContent(VcfData data, IDictionary<string, string> contentToAppend)
        {
            contentToAppend.Add("VERSION", "3.0");

            if (!string.IsNullOrEmpty(data.Mobile))
            {
                contentToAppend.Add("TEL;TYPE=CELL", $"{ data.Mobile}");
            }

            if (!string.IsNullOrEmpty(data.HomePhone))
            {
                contentToAppend.Add("TEL;TYPE=HOME,VOICE", $"{ data.HomePhone}");
            }

            if (!string.IsNullOrEmpty(data.WorkPhone))
            {
                contentToAppend.Add("TEL;TYPE=WORK,VOICE", $"{ data.WorkPhone}");
            }

            if (!string.IsNullOrEmpty(data.Fax))
            {
                contentToAppend.Add("TEL;TYPE=WORK,FAX", $"{ data.Fax}");
            }

            return base.BuildVcfContent(data, contentToAppend);
        }
    }
}