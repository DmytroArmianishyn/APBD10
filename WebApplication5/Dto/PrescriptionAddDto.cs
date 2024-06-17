namespace WebApplication5.Dto;
using System.ComponentModel.DataAnnotations;

public class PrescriptionAddDto
{
    [Required]
    public AddPatientDto Patient { get; set; }
    [Required]
    public ICollection<AddPrescriptionMedicamentDTO> Medicaments { get; set; } = new List<AddPrescriptionMedicamentDTO>();
    [Required]
    public AddDoctorDto Doctor { get; set; }
    [Required]
    public DateTime Date { get; set; } 
    [Required]
    public DateTime DueDate { get; set; } 
}