using System;
using MyContacts.VcfProviderTool.Interfaces;

namespace MyContacts.VcfProviderTool.VcfProvider
{
    public static class VcfProviderFactory
    {
        public static IVcfProvider GetVcfInstance(string vcfVersion = "3.0")
        {

            switch (vcfVersion)
            {
                case "2.1":
                    return new VcfProviderV2();
                case "3.0":
                    return new VcfProviderV3();
                case "4.0":
                    return new VcfProviderV4();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}