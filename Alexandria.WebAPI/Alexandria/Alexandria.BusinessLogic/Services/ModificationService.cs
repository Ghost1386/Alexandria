using Alexandria.BusinessLogic.Interfaces;
using Alexandria.DAL.Interfaces;
using Alexandria.Models.Models;

namespace Alexandria.BusinessLogic.Services;

public class ModificationService : IModificationService
{
    private readonly IModificationRepository _modificationRepository;

    public ModificationService(IModificationRepository modificationRepository)
    {
        _modificationRepository = modificationRepository;
    }

    public void CreateModification(Modification modification)
    {
        _modificationRepository.CreateModification(modification);
    }
}