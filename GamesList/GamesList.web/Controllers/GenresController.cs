using GamesList.web.Models;
using GamesList.web.Services;
using Microsoft.AspNetCore.Mvc;

namespace GamesList.web.Controllers
{
    public class GenreController : Controller
    {
        static GenresService genreService = new GenresService();


        [HttpGet("")]
        public IActionResult Index()
        {
            var model = genreService.GetAllGenres();
            return View(model);
        }

        [HttpGet("/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("/create")]
        public IActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {    
                genreService.AddGenre(genre);
                return RedirectToAction("Index");
            }            
            return View(genre);
        }

        //[HttpPost]
        //public IActionResult RemoveGenre(int id)
        //{
            //genreService.RemoveGenre(id);
            //return RedirectToAction("Index");
        //}


    }
}
