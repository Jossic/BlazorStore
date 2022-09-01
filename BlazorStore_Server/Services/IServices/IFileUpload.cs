using Microsoft.AspNetCore.Components.Forms;

namespace BlazorStore_Server.Services.IServices
{
    public interface IFileUpload
    {
        Task<string> UploadFile(IBrowserFile file);
        bool DeleteFile(string filePath);
    }
}
