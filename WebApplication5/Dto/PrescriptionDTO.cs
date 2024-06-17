namespace WebApplication5.Dto;

public class PrescriptionDTO
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public IEnumerable<MedicamentDto> Medicaments { get; set; } =null!;
    public DoctorDto Doctor { get; set; } = null!;
}