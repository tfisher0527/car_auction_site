using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace IdentityService.Pages.Diagnostics;

[SecurityHeaders]
[Authorize]
public class Index : PageModel
{
    public ViewModel View { get; set; }
        
    public async Task<IActionResult> OnGet()
    {
        var localAddresses = new string[] { "::ffff:192.168.65.1", "::1", HttpContext.Connection.LocalIpAddress.ToString() };
        var remoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        Console.WriteLine($"Remote IP Address: {remoteIpAddress}");
        if (!localAddresses.Contains(HttpContext.Connection.RemoteIpAddress.ToString()))
        {
            return NotFound();
        }

        View = new ViewModel(await HttpContext.AuthenticateAsync());
            
        return Page();
    }
}