using System.ComponentModel.DataAnnotations;

namespace JuanProj.Areas.Admin.Models.UpdateVm;

public class UpdateVM
{
    [Required]
    public string? UserName { get; set; }
    [Required, DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    [Required, DataType(DataType.Password)]
    public string? Password { get; set; }

    [Required]
    public string? DisplayRole { get; set; }
}
