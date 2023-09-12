using Alexandria.Models.Models;

namespace Alexandria.DAL.Interfaces;

public interface IEducationalInstitutionRepository
{
    void CreateEducationalInstitution(EducationalInstitution educationalInstitution);
}