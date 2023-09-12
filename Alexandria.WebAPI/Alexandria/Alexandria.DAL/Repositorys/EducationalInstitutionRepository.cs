using Alexandria.DAL.Interfaces;
using Alexandria.Models;
using Alexandria.Models.Models;

namespace Alexandria.DAL.Repositorys;

public class EducationalInstitutionRepository : IEducationalInstitutionRepository
{
    private readonly ApplicationContext _applicationContext;
    
    public EducationalInstitutionRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }
    
    public async void CreateEducationalInstitution(EducationalInstitution educationalInstitution)
    {
        await _applicationContext.EducationalInstitutions.AddAsync(educationalInstitution);
        await _applicationContext.SaveChangesAsync();
    }
}