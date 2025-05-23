using GamesList.web.Models;
using GamesList.web.Services;
using Microsoft.AspNetCore.Mvc;

namespace GamesList.web.Controllers
{
    public class GenreController : Controller
    {
        private readonly GenresService _genreService;

        public GenreController(GenresService genreService)
        {
            _genreService = genreService;
        }
        
        [HttpGet("")]        
        public IActionResult Index()
        {
            var model = _genreService.GetAllGenres();
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
            if (ModelState.IsValid)
            {    
                _genreService.AddGenre(genre);
                return RedirectToAction("Index");
            }            
            return View();
        }
        
        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var genre = _genreService.GetGenreById(id);
            if (genre == null) return NotFound();
            return View(genre);
        }

        [HttpPost("edit/{id}")]
        public IActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _genreService.UpdateGenre(genre);
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _genreService.RemoveGenreById(id);
            return RedirectToAction("Index");
        }

        [HttpGet("details/{id}")]
        public IActionResult Details(int id)
        {
            var genre = _genreService.GetGenreById(id);
            if (genre == null)
                return NotFound();

            return View(genre);
        }

    }
}
