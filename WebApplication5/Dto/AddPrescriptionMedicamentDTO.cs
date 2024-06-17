namespace WebApplication5.Dto;
using System.ComponentModel.DataAnnotations;

public class AddPrescriptionMedicamentDTO
{
    [Required]
    public int IdMedicament { get; set; }

    public int? Dose { get; set; } = null;
    [Required]
    [MaxLength(100)]
    public string Description { get; set; } = null!;
}