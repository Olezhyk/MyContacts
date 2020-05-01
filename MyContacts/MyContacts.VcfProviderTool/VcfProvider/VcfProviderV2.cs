using System.Collections.Generic;
using MyContacts.VcfProvider.VcfProvider;
using MyContacts.VcfProvider.Interfaces;
using MyContacts.VcfProvider.Models;

namespace MyContacts.VcfProvider.VcfProvider
{
    public class VcfProviderV2 : VcfProviderBase, IVcfProvider
    {
        protected override string BuildVcfContent(VcfData data, IDictionary<string, string> contentToAppend)
        {
            contentToAppend.Add("VERSION", "2.1");

            if (!string.IsNullOrEmpty(data.Mobile))
            {
                contentToAppend.Add("TEL;CELL", $"{ data.Mobile}");
            }

            if (!string.IsNullOrEmpty(data.HomePhone))
            {
                contentToAppend.Add("TEL;HOME;VOICE", $"{ data.HomePhone}");
            }

            if (!string.IsNullOrEmpty(data.WorkPhone))
            {
                contentToAppend.Add("TEL;WORK;VOICE", $"{ data.WorkPhone}");
            }

            if (!string.IsNullOrEmpty(data.Fax))
            {
                contentToAppend.Add("TEL;WORK;FAX", $"{ data.Fax}");
            }

            return base.BuildVcfContent(data, contentToAppend);
        }
    }
}