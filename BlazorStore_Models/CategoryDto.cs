using System.ComponentModel.DataAnnotations;

namespace BlazorStore_Models;

public class CategoryDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Rentre un nom...")]
    public string Name { get; set; }
}
