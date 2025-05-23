using System.ComponentModel.DataAnnotations;

namespace GamesList.web.ViewModels
{
    public class DetailsVM
    {
        public int Id { get; set; }              
        public string Name { get; set; } = string.Empty;                        
        public string Description { get; set; } = string.Empty;
        public List<string> GameImages { get; set; } = new List<string>();
    }
}
