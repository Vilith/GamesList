using GamesList.web.Models;
using GamesList.web.Services;
using GamesList.web.ViewModels;
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

        #region[Home]
        [HttpGet("")]        
        public IActionResult Index()
        {
            var model = _genreService.GetAllGenres();
            return View(model);
        }
        #endregion

        #region[Create]
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(CreateVM viewModel)
        {
            if (ModelState.IsValid)
            {  
                var genre = new Genre
                {
                    Name = viewModel.Name,
                    Description = viewModel.Description
                };

                _genreService.AddGenre(genre);
                return RedirectToAction("Index");
            }      
            
            return View(viewModel);
        }
        #endregion

        #region[Edit]
        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var genre = _genreService.GetGenreById(id);
            if (genre == null) return NotFound();

            var viewModel = new EditVM
            {
                Id = genre.Id,
                Name = genre.Name,
                Description = genre.Description
            };

            return View(viewModel);
        }

        [HttpPost("edit/{id}")]
        public IActionResult Edit(EditVM viewModel)
        {
            if (ModelState.IsValid)
            {
                var genre = new Genre
                {
                    Id = viewModel.Id,
                    Name = viewModel.Name,
                    Description = viewModel.Description
                };

                _genreService.UpdateGenre(genre);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        #endregion

        #region[Delete]
        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _genreService.RemoveGenreById(id);
            return RedirectToAction("Index");
        }
        #endregion

        #region[Details]
        [HttpGet("details/{id}")]
        public IActionResult Details(int id)
        {
            var genre = _genreService.GetGenreById(id);
            if (genre == null) return NotFound();

            var viewModel = new DetailsVM
            {
                Id = genre.Id,
                Name = genre.Name,
                Description = genre.Description,
                GameImages = genre.GameImages ?? new List<string>()
            };

            return View(viewModel);
        }
        #endregion
    }
}
