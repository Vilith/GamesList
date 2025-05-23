using GamesList.web.Models;

namespace GamesList.web.Services
{
    public class GenresService
    {
        private readonly List<Genre> genres = new List<Genre>
        {
            new Genre { Id = 1, 
                Name = "Action",
                Description = "Action games are characterized by physical challenges, including hand-eye coordination and reaction time.",
                GameImages = new List<string> {
                "Bean.jpg",
                "EpicHero.png"
                }
            },
            new Genre { Id = 2, 
                Name = "Adventure", 
                Description = "Adventure games focus on narrative-driven experiences, often involving exploration and puzzle-solving.",
                GameImages = new List<string> {
                    "EpicHero.png",
                    "Bean.jpg"
                }
            },
            new Genre { Id = 3, 
                Name = "Role-Playing", 
                Description = "Role-playing games (RPGs) allow players to assume the roles of characters in a fictional setting.",
                GameImages = new List<string> {
                    "EpicHero.png",
                    "Bean.jpg"
                }
            },
            new Genre { Id = 4, 
                Name = "Simulation", 
                Description = "Simulation games mimic real-world activities, allowing players to experience various scenarios.",
                GameImages = new List<string> {
                    "EpicHero.png",
                    "Bean.jpg"
                }
            },
            new Genre { Id = 5, 
                Name = "Strategy", 
                Description = "Strategy games emphasize skillful thinking and planning to achieve victory.",
                GameImages = new List<string> {
                    "EpicHero.png",
                    "Bean.jpg"
                }
            },
        };

        public Genre? GetGenreById(int id) => genres.FirstOrDefault(g => g.Id == id);

        public Genre[] GetAllGenres()
        {
            return genres.ToArray();
        }

        public void UpdateGenre(Genre updatedGenre)
        {
            var index = genres.FindIndex(g => g.Id == updatedGenre.Id);
            if (index != -1)
            {
                genres[index] = updatedGenre;
            }

        }

        public void AddGenre(Genre genre)
        {
            genre.Id = genres.Count == 0 ? 1 : genres.Max(g => g.Id) + 1;
            genres.Add(genre);
        }

        public void RemoveGenreById(int id)
        {
            var genre = GetGenreById(id);
            if (genre != null)
            {
                genres.Remove(genre);
            }
        }
    }
}
