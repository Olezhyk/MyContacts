using System.Collections.Generic;

namespace MyContacts.VcfProviderTool.VcfProvider
{
    internal static class DictionaryExtensions
    {
        public static void AddDataRow(this IDictionary<string, string> targetDictionary, string key, string value,
            IDictionary<string, string> sourceDictionary)
        {
            var dataValue = sourceDictionary.ContainsKey(key)
                ? sourceDictionary[key]
                : value;

            if (sourceDictionary.ContainsKey(key))
            {
                sourceDictionary.Remove(key);
            }

            targetDictionary.Add(key, dataValue);
        }
    }
}