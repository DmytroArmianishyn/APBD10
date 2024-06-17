namespace WebApplication5.Dto;

public class PatientDTO
{
     
    public int IdPatient { get; set; }
    public string FirstName { get; set; } 
    public string LastName { get; set; } 
    public DateTime Birthdate { get; set; }
    public ICollection<PrescriptionDTO> Prescriptions { get; set; } = null!;
}