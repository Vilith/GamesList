using System.ComponentModel.DataAnnotations;

namespace GamesList.web.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;        

    }

}
