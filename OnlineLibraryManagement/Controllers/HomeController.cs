using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineLibraryManagement.Models;
using System.Diagnostics;

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

        public IActionResult loginMethod(Taikhoan a)
        {
            Taikhoan tk = db.Taikhoan.Where(t => t.Tentk == a.Tentk).FirstOrDefault();
            if (tk != null)
            {
                if (tk.Matkhau == a.Matkhau)
                {               
                    MySessions.Set<Taikhoan>(HttpContext.Session, "taikhoan",tk);
                    if (tk.Loaitk == false) return View("~/Views/Thuthu/Index.cshtml");
                    else return View("~/Views/Docgia/Index.cshtml");
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

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("tk");
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
