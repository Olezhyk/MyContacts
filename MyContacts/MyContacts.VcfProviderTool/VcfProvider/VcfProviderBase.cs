using System.Collections.Generic;
using System.Text;
using MyContacts.VcfProviderTool.Models;

namespace MyContacts.VcfProviderTool.VcfProvider
{
    public class VcfProviderBase
    {
        public byte[] CreateByteArray(VcfData data)
        {
            var str = BuildVcfContent(data, new Dictionary<string, string>());

            return Encoding.ASCII.GetBytes(str);
        }

        public string CreateString(VcfData data)
        {
            return BuildVcfContent(data, new Dictionary<string, string>());
        }

        protected virtual string BuildVcfContent(VcfData data, IDictionary<string, string> contentToAppend)
        {
            var vCardData = new Dictionary<string, string>();

            var isNameExist = data.LastName != null || data.FirstName != null;
            var name = isNameExist ? $"{data.LastName}; {data.FirstName};" : $"{data.CompanyName}";
            var fullName = isNameExist ? $"{data.FirstName} {data.LastName}" : $"{data.CompanyName}";

            vCardData.Add("BEGIN", "VCARD");
            vCardData.AddDataRow("VERSION", "2.1", contentToAppend);
            vCardData.AddDataRow("N", name, contentToAppend);
            vCardData.AddDataRow("FN", fullName, contentToAppend);
            if (!string.IsNullOrEmpty(data.Title))
            {
                vCardData.Add("TITLE", $"{data.Title}");
            }
            if (!string.IsNullOrEmpty(data.WebSite))
            {
                vCardData.Add("URL", $"{data.WebSite}");
            }
            if (!string.IsNullOrEmpty(data.Email))
            {
                vCardData.Add("EMAIL", $"{data.Email}");
            }
            if (!string.IsNullOrEmpty(data.CompanyName))
            {
                vCardData.Add("ORG", $"{data.CompanyName};");
            }

            vCardData.Add("ADR", $";;{data.Address1} {data.Address2}; {data.City}; {data.State}; {data.ZipCode}; {data.CountryName}");

            foreach (var itemToAdd in contentToAppend)
            {
                vCardData.Add(itemToAdd.Key, itemToAdd.Value);
            }

            vCardData.Add("END", "VCARD");

            var vCard = new StringBuilder();

            foreach (var vCardRow in vCardData)
            {
                vCard.AppendLine($"{vCardRow.Key}:{vCardRow.Value}");
            }

            return vCard.ToString();
        }
    }
}