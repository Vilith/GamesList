using System.ComponentModel.DataAnnotations;

namespace GamesList.web.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
        public string Description { get; set; } = string.Empty;     
        
        public List<string> GameImages { get; set; } = new List<string>();

    }

}
