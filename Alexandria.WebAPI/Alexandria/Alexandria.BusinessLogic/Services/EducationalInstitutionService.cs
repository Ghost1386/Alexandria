using Alexandria.BusinessLogic.Interfaces;
using Alexandria.DAL.Interfaces;
using Alexandria.Models.Models;

namespace Alexandria.BusinessLogic.Services;

public class EducationalInstitutionService : IEducationalInstitutionService
{
    private readonly IEducationalInstitutionRepository _educationalInstitutionRepository;

    public EducationalInstitutionService(IEducationalInstitutionRepository educationalInstitutionRepository)
    {
        _educationalInstitutionRepository = educationalInstitutionRepository;
    }

    public void CreateEducationalInstitution(EducationalInstitution educationalInstitution)
    {
        _educationalInstitutionRepository.CreateEducationalInstitution(educationalInstitution);
    }
}