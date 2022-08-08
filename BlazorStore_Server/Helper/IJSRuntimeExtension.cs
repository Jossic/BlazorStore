using Microsoft.JSInterop;

namespace BlazorStore_Server.Helper;

public static class IJSRuntimeExtension
{
    public static async ValueTask ToastrSuccess(this IJSRuntime jSRuntime, string message)
    {
        await jSRuntime.InvokeVoidAsync("ShowToastr", "success", message);
    }

    public static async ValueTask ToastrError(this IJSRuntime jSRuntime, string message)
    {
        await jSRuntime.InvokeVoidAsync("ShowToastr", "error", message);
    }

    public static async ValueTask AlertSuccess(this IJSRuntime jSRuntime, string message)
    {
        await jSRuntime.InvokeVoidAsync("ShowAlert", "success", message);
    }

    public static async ValueTask AlertError(this IJSRuntime jSRuntime, string message)
    {
        await jSRuntime.InvokeVoidAsync("ShowAlert", "error", message);
    }
}
