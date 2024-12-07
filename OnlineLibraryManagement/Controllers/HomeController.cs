using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OnlineLibraryManagement.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace OnlineLibraryManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        QuanLyThuVienContext db = new QuanLyThuVienContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

        public async Task<IActionResult> loginMethodAsync(Taikhoan a)
        {
            Taikhoan tk = db.Taikhoan.Where(t => t.Tentk == a.Tentk).FirstOrDefault();
            if (tk != null)
            {
                if (tk.Matkhau == a.Matkhau)
                {
                    MySessions.Set(HttpContext.Session, "taikhoan", tk);
                    if (tk.Loaitk == false)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, "Admin"),
                            new Claim(ClaimTypes.Role, "Thuthu")
                        };
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
                        return View("~/Views/Thuthu/Index.cshtml");
                    }

                    else
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, "User"),
                            new Claim(ClaimTypes.Role, "Docgia")
                        };
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
                        Docgia dg = db.Docgia.Where(t => t.Matk == tk.Matk).FirstOrDefault();
                        dg.MatkNavigation = null;
                        MySessions.Set(HttpContext.Session, "madocgia", dg.Madocgia);
                        return View("~/Views/Docgia/Index.cshtml");
                    }
                }
                ModelState.AddModelError("Matkhau", "Sai tên hoặc mật khẩu.");
            }
            ModelState.AddModelError("Matkhau", "Sai tên hoặc mật khẩu.");
            return View("Login");
        }

        public IActionResult Signup()
        {
            return View();
        }

        public IActionResult signupMethod(Taikhoan tk)
        {
            ModelState.Clear();
            if (ModelState.IsValid)
            {
                if (!db.Taikhoan.Any(t => t.Tentk == tk.Tentk))
                {
                    if (!db.Taikhoan.Any(t => t.Email == tk.Email))
                    {
                        tk.Loaitk = true;
                        db.Taikhoan.Add(tk);
                        db.SaveChanges();

                        Docgia dg = new Docgia();
                        dg.Matk = tk.Matk;
                        db.Docgia.Add(dg);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "Email đã tồn tại.");
                    }
                }
                else
                {
                    ModelState.AddModelError("Tentk", "Tên tài khoản đã tồn tại.");
                }
            }
            return View("Signup");
        }

        public async Task<IActionResult> LogoutAsync()
        {
            MySessions.Set(HttpContext.Session, "dangLapPhieu", false);
            HttpContext.Session.Remove("lapPMS");
            HttpContext.Session.Remove("dsSach");
            HttpContext.Session.Remove("tk");
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
