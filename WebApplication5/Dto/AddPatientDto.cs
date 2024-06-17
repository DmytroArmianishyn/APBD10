namespace WebApplication5.Dto;
using System.ComponentModel.DataAnnotations;
public class AddPatientDto
{
    [Required]
    public int IdPatient { get; set; }
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = null!;
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = null!;
    [Required]
    public DateOnly Birtdate { get; set; }
}