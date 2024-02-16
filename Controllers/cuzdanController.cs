using cdeneme.Models;
using cdeneme.utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;



namespace cdeneme.Controllers
{
    public class cuzdanController : Controller
    {

        private readonly cuzdanDbContext _cuzdanDbContext;

        public cuzdanController(cuzdanDbContext context)
        {
            _cuzdanDbContext = context;
        }
        public IActionResult Index()

        { return View(); }
        public IActionResult cuzdansayfa()
        {
            var cuzdanlar = _cuzdanDbContext.cuzdan.ToList();
            return View(cuzdanlar);
        }

        public IActionResult Ekle()
        { return View(); }

        [HttpPost]
        public IActionResult Ekle(Cuzdana cuzdanek)
        {
            if (ModelState.IsValid)
            {
                _cuzdanDbContext.cuzdan.Add(cuzdanek);
                _cuzdanDbContext.SaveChanges();

                return RedirectToAction("cuzdansayfa");
            }
            return RedirectToAction();

        }
        [HttpPost]
        public IActionResult Cuzdansil(int? Id)
        {
            var cuzdan = _cuzdanDbContext.cuzdan.Find(Id);
            if (cuzdan != null)
            {
                _cuzdanDbContext.cuzdan.Remove(cuzdan);
                _cuzdanDbContext.SaveChanges();
            }
            return RedirectToAction("cuzdansayfa");
        }
        public IActionResult Parayatir()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Parayatir(decimal yatirilan, int Id)
        {
            var cuzdan = _cuzdanDbContext.cuzdan.Find(Id);
            if (cuzdan != null)
            {
                cuzdan.bakiye += yatirilan;
                _cuzdanDbContext.SaveChanges();
                return RedirectToAction("cuzdansayfa");
            }
            return RedirectToAction("Parayatir");
        }
        public IActionResult Paracek()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Paracek(decimal cekilen, int Id)
        {
            var cuzdan = _cuzdanDbContext.cuzdan.Find(Id);
            if (cuzdan != null)
            {
                if (cuzdan.bakiye < @cekilen)
                {
                    ViewData["hatamesaj"] = "Yetersiz Bakiye, Lütfen Tekrar Deneyin";
                    return View("Paracek");
                }
                cuzdan.bakiye -= cekilen;
                _cuzdanDbContext.SaveChanges();
                return RedirectToAction("cuzdansayfa");
            }
            return RedirectToAction("Paracek");

        }
        public IActionResult Transfer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Transfer(decimal Tmiktar, int Id, int AliciId)
        {
            var cuzdan = _cuzdanDbContext.cuzdan.Find(Id);
            var alici = _cuzdanDbContext.cuzdan.Find(AliciId);


            if (cuzdan == null || alici == null) 
            {
                ViewData["hatamesaj1"] = "Bu ID'ye sahip bir cüzdan sistemde mevcut değil.";

                return RedirectToAction("Transfer");
            }
            if ( cuzdan.bakiye < Tmiktar)
            {
                ViewData["hatamesaj"] = "Yetersiz Bakiye, Lütfen Tekrar Deneyin.";
                return View("Transfer");
            }
            cuzdan.bakiye -= Tmiktar;
            alici.bakiye += Tmiktar;
            _cuzdanDbContext.SaveChanges();


            return RedirectToAction("cuzdansayfa");

        }
    }
}
        

    



