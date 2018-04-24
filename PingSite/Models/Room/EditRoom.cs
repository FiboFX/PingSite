using System.ComponentModel.DataAnnotations;

namespace PingSite.Models.Room
{
    public class EditRoom
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}