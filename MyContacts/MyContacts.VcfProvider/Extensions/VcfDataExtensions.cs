//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using MyContacts.VcfProvider.Models;

//namespace MyContacts.VcfProvider.Extensions
//{
//    public static class VcfDataExtensions
//    {
//        public static string GetVcfAddress(this VcfData data)
//        {
//            var sb = new StringBuilder();

//            if (!string.IsNullOrEmpty(data.FullName))
//            {
//                sb.AppendLine(data.FullName);
//            }
//            if (!string.IsNullOrEmpty(data.Title))
//            {
//                sb.AppendLine(data.Title);
//            }
//            if (!string.IsNullOrEmpty(data.CompanyName))
//            {
//                sb.AppendLine(data.CompanyName);
//            }
//            if (!string.IsNullOrEmpty(data.Address1))
//            {
//                sb.AppendLine(data.Address1);
//            }
//            if (!string.IsNullOrEmpty(data.Address2))
//            {
//                sb.AppendLine(data.Address2);
//            }

//            var addressParts = new List<string>();

//            if (!string.IsNullOrEmpty(data.City)) addressParts.Add(data.City);
//            var stateZipParts = new List<string>();

//            if (!string.IsNullOrEmpty(data.State)) stateZipParts.Add(data.State);
//            if (!string.IsNullOrEmpty(data.ZipCode)) stateZipParts.Add(data.ZipCode);

//            if (stateZipParts.Any())
//            {
//                addressParts.Add(string.Join(" ", stateZipParts));
//            }

//            if (addressParts.Any())
//            {
//                sb.AppendLine(string.Join(", ", addressParts));
//            }

//            var phoneParts = new List<string>();

//            if (!string.IsNullOrEmpty(data.WorkPhone)) phoneParts.Add($"Work: { data.WorkPhone}");
//            if (!string.IsNullOrEmpty(data.Fax)) phoneParts.Add($"Fax: { data.Fax}");
//            if (!string.IsNullOrEmpty(data.Mobile)) phoneParts.Add($"Mobile: { data.Mobile}");
//            if (!string.IsNullOrEmpty(data.HomePhone)) phoneParts.Add($"Home: { data.HomePhone}");
//            if (!string.IsNullOrEmpty(data.Email)) phoneParts.Add($"Email: { data.Email}");
//            if (!string.IsNullOrEmpty(data.WebSite)) phoneParts.Add($"WebSite: { data.WebSite}");

//            if (phoneParts.Any())
//            {
//                sb.AppendLine();
//                foreach (var item in phoneParts)
//                {
//                    sb.AppendLine(item);
//                }
//            }

//            var retString = sb.ToString();

//            return retString;
//        }
//    }
//}