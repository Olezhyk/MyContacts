using MyContacts.VcfProviderTool.Models;

namespace MyContacts.VcfProviderTool.Interfaces
{
    public interface IVcfProvider
    {
        byte[] CreateByteArray(VcfData data);

        string CreateString(VcfData data);
    }
}