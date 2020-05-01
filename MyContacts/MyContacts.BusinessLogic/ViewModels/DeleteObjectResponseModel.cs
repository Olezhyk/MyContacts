using System.Collections.Generic;

namespace MyContacts.BusinessLogic.ViewModels
{
    public class DeleteObjectResponseModel
    {
        public bool IsSuccess { get; set; }
        
        public string Message { get; set; }

        public List<string> ValidationErrors { get; set; }
    }
}