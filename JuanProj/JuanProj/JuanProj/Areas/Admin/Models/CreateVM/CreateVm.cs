using System.ComponentModel.DataAnnotations;

namespace JuanProj.Areas.Admin.Models.CreateVM
{
    public class CreateVM
    {

        [Required]
        public string? Username { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        public string? DisplayRole { get; set; }
        
    }
}
