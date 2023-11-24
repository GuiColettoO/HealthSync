using HealthSync.DataBase;
using HealthSync.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HealthSync.Controllers
{
    public class TrainnerController : Controller
    {
        private HealthSyncContext _context;
        public TrainnerController(HealthSyncContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Trainner trainner)
        {
            _context.Trainners.Add(trainner);
            _context.SaveChanges();
            TempData["msg"] = "Registered Trainner";
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
            var trainner = _context.Trainners.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (trainner != null)
            {
                return RedirectToAction("Index", new { id = trainner.Id });
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public IActionResult Index(string termoBusca)
        {
            var lista = _context.InfoUsers
            .Where(f => f.Name.Contains(termoBusca) || termoBusca == null)
            .ToList();
            var user = _context.InfoUsers.ToList();
            return View(user);
        }

        [HttpGet]
        public IActionResult CreateWorkout()
        {
            UploadTrainner();
            return View();
        }

        [HttpPost]
        public IActionResult CreateWorkout(Workout workout)
        {
            _context.Workouts.Add(workout);
            _context.SaveChanges();
            TempData["msg"] = "Registered workout";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Workouts()
        {
            var workout = _context.Workouts.Include(u => u.Trainner).ToList();
            return View(workout);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            UploadTrainner();
            var workout = _context.Workouts.Find(id);
            return View(workout);
        }

        [HttpPost]
        public IActionResult Edit(Workout workout)
        {
            _context.Workouts.Update(workout);
            _context.SaveChanges();
            TempData["msg"] = "Workout Update!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var workout = _context.Workouts.Find(id);
            _context.Workouts.Remove(workout);
            _context.SaveChanges();
            TempData["msg"] = "Workout removed!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Add(InfoTrainner infoTrainner)
        {
            _context.InfosTrainners.Add(infoTrainner);
            _context.SaveChanges();
            TempData["msg"] = "Workout add";
            return RedirectToAction("Add", new { id = infoTrainner.TrainnerId });
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            var infosTrainners = _context.InfosTrainners
                .Where(m => m.TrainnerId == id)
                .Select(m => m.InfoUser)
                .ToList();

            var allUser = _context.InfoUsers.ToList();

            var lista = allUser.Where(f => !infosTrainners.Contains(f));

            ViewBag.users = lista;
            var trainner = _context.Workouts.Include(f => f.Trainner).First(f => f.Id == id);
            var workout = _context.Trainners.Find(id);
            ViewBag.workout = workout;
            return View();
        }

        [HttpGet]
        public IActionResult Info(int id)
        {
            var user = _context.InfosTrainners
                .Where(m => m.TrainnerId == id)
                .Select(u => u.InfoUser)
                .ToList();

            ViewBag.users = user;

            var workout = _context.Workouts.Include(f => f.Trainner).First(f => f.Id == id);

            return View(workout);
        }

        private void UploadTrainner()
        {
            var lista = _context.Trainners.ToList();
            ViewBag.trainners = new SelectList(lista, "Id", "Name");
        }

    }
}

