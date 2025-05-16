using GamesList.web.Models;

namespace GamesList.web.Services
{
    public class GenresService
    {        
        List<Genre> genres = new List<Genre>
        {
            new Genre { Id = 1, Name = "Action", Description = "Action games are characterized by physical challenges, including hand-eye coordination and reaction time." },
            new Genre { Id = 2, Name = "Adventure", Description = "Adventure games focus on narrative-driven experiences, often involving exploration and puzzle-solving." },
            new Genre { Id = 3, Name = "Role-Playing", Description = "Role-playing games (RPGs) allow players to assume the roles of characters in a fictional setting." },
            new Genre { Id = 4, Name = "Simulation", Description = "Simulation games mimic real-world activities, allowing players to experience various scenarios." },
            new Genre { Id = 5, Name = "Strategy", Description = "Strategy games emphasize skillful thinking and planning to achieve victory." },
        };


        public void AddGenre(Genre genre)
        {
            genre.Id = genres.Count == 0 ? 1 : genres.Max(g => g.Id) + 1;
            genres.Add(genre);
        }

        public Genre[] GetAllGenres()
        {
            return genres.ToArray();
        }     

        public Genre GetGenreById(int id) => genres.Single(g => g.Id == id);              

        public void RemoveGenre(Genre genre)
        {
            genres.Remove(genre);
        }
              
        //public bool GenreExists(string name)
        //{
            //return genres.Any(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        //}

    }
}
