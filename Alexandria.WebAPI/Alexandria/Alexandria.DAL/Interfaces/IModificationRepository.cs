using Alexandria.Models.Models;

namespace Alexandria.DAL.Interfaces;

public interface IModificationRepository
{
    void CreateModification(Modification modification);
}