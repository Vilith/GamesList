using GamesList.web.Models;
using GamesList.web.Services;
using Microsoft.AspNetCore.Mvc;

namespace GamesList.web.Controllers
{
    public class GenreController : Controller
    {
        GenreService genreService = new GenreService();


        [HttpGet("")]
        public IActionResult Index()
        {
            var model = genreService.GetAllGenres();
            return View(model);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Genre genre)
        {
            if (!ModelState.IsValid)
            {                
                return View(genre);
            }

            genreService.AddGenre(genre);
            return RedirectToAction("Index");
        }

        [HttpPost("remove/{id}")]
        public IActionResult RemoveGenre(int id)
        {
            genreService.RemoveGenre(id);
            return RedirectToAction("Index");
        }


    }
}
