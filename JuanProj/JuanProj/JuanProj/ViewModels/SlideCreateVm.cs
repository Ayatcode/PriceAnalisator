using Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace JuanProj.ViewModels
{
    public class SlideCreateVm:IEntity
    {
        public int Id { get; set; }

        public IFormFile? Image { get; set; }
        [MaxLength(100)]
        public string? Subtitle { get; set; }
        [Required, MaxLength(100)]
        public string? Title { get; set; }
      
    }
}
