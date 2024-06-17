using Microsoft.AspNetCore.Mvc;
using WebApplication5.Dto;
using WebApplication5.Models;
using WebApplication5.Service;

namespace WebApplication5.controllers;

[ApiController]
[Route("/prescriptionapp")]
public class PrescriptionController : ControllerBase
{



    private readonly PatientService _dbService;

    public PrescriptionController(PatientService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{idPatient:int}")]
    public async Task<IActionResult> GetOrdersData(int idPatient)
    {
        var patient = await _dbService.GetPatientData(idPatient);

        return Ok(patient.Select(e => new PatientDTO()
        {
            IdPatient = e.IdPatient,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Birthdate = e.Birthdate,
            Prescriptions = e.Prescriptions.Select(p => new PrescriptionDTO()
            {
                IdPrescription = p.IdPrescription,
                Date = p.Date,
                DueDate = p.DueDate,
                Doctor = new DoctorDto()
                {
                    IdDoctor = p.IdDoctor,
                    FirstName = p.Doctor.FirstName
                },
                Medicaments = p.PrescriptionMedicaments.Select(m => new MedicamentDto()
                {
                    IdMedication = m.IdMedicament,
                    Name = m.Medicament.Name,
                    Dose = m.Dose,
                    Details = m.Medicament.Description
                })

            }).ToList()
        }));

    }

    [HttpPost]
    public async Task<IActionResult> PostNewPrescription(PrescriptionAddDto newPrescription)
    {
        if (!await _dbService.DoesPatientExist(newPrescription.Patient.IdPatient))
            return NotFound("Patient");
        if (!await _dbService.DoesDoctorExist(newPrescription.Doctor.IdDoctor))
            return NotFound("Doctor");
        var medic = newPrescription.Medicaments;
        foreach (var tmp in medic)
        {
            if (!await _dbService.DoesDoctorExist(tmp.IdMedicament))
                return NotFound("Medicament");
        }

        var prescription = new Prescription()
        {
            Date = newPrescription.Date,
            DueDate = newPrescription.DueDate,
            IdPatient = newPrescription.Patient.IdPatient,
            IdDoctor = newPrescription.Doctor.IdDoctor
        };

        return Ok();
    }
}