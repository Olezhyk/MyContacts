//using System.Collections.Generic;
//using MyContacts.VcfProvider.Interfaces;
//using MyContacts.VcfProvider.Models;

//namespace MyContacts.VcfProvider.VcfProvider
//{
//    public class VcfProviderV4 : VcfProviderBase, IVcfProvider
//    {
//        protected override string BuildVcfContent(VcfData data, IDictionary<string, string> contentToAppend)
//        {
//            contentToAppend.Add("VERSION", "4.0");

//            if (!string.IsNullOrEmpty(data.Mobile))
//            {
//                contentToAppend.Add("TEL;VALUE=uri;TYPE=cell", $"{ data.Mobile}");
//            }

//            if (!string.IsNullOrEmpty(data.HomePhone))
//            {
//                contentToAppend.Add("TEL;VALUE=uri;TYPE=home,voice", $"{ data.HomePhone}");
//            }

//            if (!string.IsNullOrEmpty(data.WorkPhone))
//            {
//                contentToAppend.Add("TEL;VALUE=uri;TYPE=home,voice", $"{ data.WorkPhone}");
//            }

//            if (!string.IsNullOrEmpty(data.Fax))
//            {
//                contentToAppend.Add("TEL;VALUE=uri;TYPE=WORK,FAX", $"{ data.Fax}");
//            }

//            return base.BuildVcfContent(data, contentToAppend);
//        }
//    }
//}