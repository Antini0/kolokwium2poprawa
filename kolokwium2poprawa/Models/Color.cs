using System.ComponentModel.DataAnnotations;

namespace kolokwium2poprawa.Models;

public class Color
{
    [Key] 
    public int IdColor { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string Name { get; set; }

    public ICollection<Car> Cars { get; set; }
}