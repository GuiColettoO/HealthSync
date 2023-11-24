using HealthSync.DataBase;
using HealthSync.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;

namespace HealthSync.Controllers
{
    public class MedicController : Controller
    {
        private HealthSyncContext _context;
        public MedicController(HealthSyncContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Medic medic)
        {
            _context.Medics.Add(medic);
            _context.SaveChanges();
            TempData["msg"] = "Registered medic";
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var medic = _context.Medics.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (medic != null)
            {
                return RedirectToAction("Index", new { id = medic.Id });
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public IActionResult Index(string busca)
        {
            var user = _context.InfoUsers.ToList();
            return View(user);
        }

        [HttpGet]
        public IActionResult CreateMenu()
        {
            UploadMedic();
            return View();
        }

        [HttpPost]
        public IActionResult CreateMenu(int id, Menu menu)
        {
            _context.Menus.Add(menu);
            _context.SaveChanges();
            TempData["msg"] = "Registered medic";
            return RedirectToAction("Index" );
        }

        [HttpGet]
        public IActionResult Menus()
        {
            var menu = _context.Menus.Include(u => u.Medic).ToList();
            return View(menu);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            UploadMedic();
            //Pesquisar o filme pelo Id
            var menu = _context.Menus.Find(id);
            //Retorar a view com o objeto filme
            return View(menu);
        }

        [HttpPost]
        public IActionResult Edit(Menu menu)
        {
            //Atualizar o filme no banco de dados
            _context.Menus.Update(menu);
            _context.SaveChanges();
            //Enviar uma para a view
            TempData["msg"] = "Menu Update!";
            //Redirecionar para a listagem
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            //Pesquisar o filme
            var menu = _context.Menus.Find(id);
            //Remove o filme
            _context.Menus.Remove(menu);
            _context.SaveChanges();
            //Mensagem de sucesso
            TempData["msg"] = "Filme removido!";
            //Redireciona para a index
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Add(InfoMenu infoMenu)
        {
            //Cadastrar o FilmeAtor
            _context.InfosMenus.Add(infoMenu);
            //Commit
            _context.SaveChanges();
            //Mensagem
            TempData["msg"] = "Usuario adicionado";
            //Redirect
            return RedirectToAction("Add", new { id = infoMenu.MenuId });
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            //Recuperar todos os atores que não
            //estão no filme e enviar para a lista
            var infosMenus = _context.InfosMenus
                .Where(m => m.MenuId == id)
                .Select(m => m.InfoUser)
                .ToList();

            var allUser = _context.InfoUsers.ToList();

            //Tira uma lista da outra
            var lista = allUser.Where(f => !infosMenus.Contains(f));

            ViewBag.users = lista;
            //Recuperar o filme e enviar para a view
            var filme = _context.Menus.Include(f => f.Medic).First(f => f.Id == id);
            var menu = _context.Menus.Find(id);
            ViewBag.menu = menu;
            return View();
        }

        [HttpGet]
        public IActionResult Info(int id)
        {
            //pesquisar todos os atores do filme
            var user = _context.InfosMenus
                .Where(m => m.MenuId == id)
                .Select(u => u.InfoUser)
                .ToList();
            //enviar a lista atores com viewbag
            ViewBag.users = user;

            var menu = _context.Menus.Include(f => f.Medic).First(f => f.Id == id);
            //Retorna a página com o filme
            return View(menu);
        }



        private void UploadMedic()
        {
            //Recuperar todas as produtoas
            var lista = _context.Medics.ToList();
            //Enviar o objeto que preenche o select de produtoras
            ViewBag.medics = new SelectList(lista, "Id", "Name");
        }


    }
}
