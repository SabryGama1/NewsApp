using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsApp.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JpbTitle { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
    }
}
