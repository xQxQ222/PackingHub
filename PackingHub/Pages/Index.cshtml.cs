using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

public class IndexModel : PageModel
{
    [BindProperty]
    public string Username { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public IActionResult OnPost()
    {
        if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
        {
            return new JsonResult(new { success = false, message = "Логин и пароль не могут быть пустыми" });
        }

        if (Username == "admin" && Password == "password")
        {
            return new JsonResult(new { success = true });
        }

        return new JsonResult(new { success = false, message = "Неправильный логин или пароль" });
    }
}
