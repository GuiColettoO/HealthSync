using HealthSync.DataBase;
using HealthSync.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthSync.Controllers
{
    public class UserController : Controller
    {
        private HealthSyncContext _context;
        public UserController(HealthSyncContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register() {
            return View();
        }

        [HttpPost]
        public IActionResult Register(InfoUser infoUser)
        {
            _context.InfoUsers.Add(infoUser);
            _context.SaveChanges();
            TempData["msg"] = "Registered user";
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
            // Buscando o InfoUser com base no e-mail e senha do usuário associado
            var infoUser = _context.InfoUsers
                               .FirstOrDefault(u => u.Email == email && u.Password == password);

            if (infoUser != null)
            {
                // Redirecionar para a ação 'Index' com o Id do InfoUser como parâmetro
                return RedirectToAction("Index", new { id = infoUser.Id });
            }
            else
            {
                // Se nenhum usuário for encontrado, redirecionar de volta para a ação de Login com uma mensagem de erro
                TempData["error"] = "Invalid email or password";
                return RedirectToAction("Login");
            }
        }

        public IActionResult Index(int id)
        {
            var infoUser = _context.InfoUsers.Find(id);

            if (infoUser == null)
            {
                // Tratar o caso de InfoUser não ser encontrado
                return RedirectToAction("Error"); // Ou outra ação apropriada
            }

            return View(infoUser);
        }

        [HttpGet]
        public IActionResult Info(int id)
        {
            var infoUser = _context.InfoUsers.Find(id);
            if (infoUser != null)
            {
                return View(infoUser);
            }

            // Tratamento para quando InfoUser não é encontrado
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Pesquisar o InfoUser pelo Id
            var infoUser = _context.InfoUsers
                                   .FirstOrDefault(iu => iu.Id == id);

            return View(infoUser);
        }


        [HttpPost]
        public IActionResult Edit(InfoUser infoUser)
        {
            //Atualizar o filme no banco de dados
            _context.InfoUsers.Update(infoUser);
            _context.SaveChanges();
            //Enviar uma para a view
            TempData["msg"] = "User atualizado!";
            //Redirecionar para a listagem
            return RedirectToAction("Index", new { id = infoUser.Id });
        }
        [HttpGet]
        public IActionResult Menus(int id)
        {
            var menusForUser = _context.Menus.Find(id);

            return View(menusForUser);
        }

        [HttpGet]
        public IActionResult Workouts(int id)
        {
            var workoutForUser = _context.Workouts.Find(id);
            if (workoutForUser == null)
            {
                // Redirecione para uma página de erro ou retorne uma view diferente
                return NotFound(); // Exemplo
            }

            return View(workoutForUser);
        }



    }
}
