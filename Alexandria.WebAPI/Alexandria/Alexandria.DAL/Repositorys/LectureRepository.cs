using Alexandria.DAL.Interfaces;
using Alexandria.Models;
using Alexandria.Models.Models;

namespace Alexandria.DAL.Repositorys;

public class LectureRepository : ILectureRepository
{
    private readonly ApplicationContext _applicationContext;
    
    public LectureRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }
    
    public async void CreateLecture(Lecture lecture)
    {
        await _applicationContext.Lectures.AddAsync(lecture);
        await _applicationContext.SaveChangesAsync();
    }
}