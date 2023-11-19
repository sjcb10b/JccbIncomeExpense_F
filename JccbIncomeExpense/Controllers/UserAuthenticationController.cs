using JccbIncomeExpense.Models;
using JccbIncomeExpense.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JccbIncomeExpense.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private readonly IUserAuthenticationService authenticationService;

        public UserAuthenticationController(IUserAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }



        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await authenticationService.LoginAsync(model);

            if (result.StatusCode == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }
        }



        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await this.authenticationService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }

        //[AllowAnonymous]
        //public async Task<IActionResult> RegisterAdmin()
        //{
        //    RegistrationModel model = new RegistrationModel
        //    {
        //        Username = "admin",
        //        Email = "admin@admin.com",
        //        FirstName = "John",
        //        LastName = "Doe",
        //        Password = "Admin12345#"
        //    };
        //    model.Role = "admin";
        //    var result = await this.authenticationService.RegisterAsync(model);
        //    return Ok(result);
        //}









    }
}
