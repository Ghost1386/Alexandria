using Alexandria.DAL.Interfaces;
using Alexandria.Models;
using Alexandria.Models.Models;

namespace Alexandria.DAL.Repositorys;

public class ModificationRepository : IModificationRepository
{
    private readonly ApplicationContext _applicationContext;
    
    public ModificationRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }
    
    public async void CreateModification(Modification modification)
    {
        await _applicationContext.ModeModifications.AddAsync(modification);
        await _applicationContext.SaveChangesAsync();
    }
}