using Alexandria.Common.DTOs.LectureDTOs;
using Alexandria.DAL.Interfaces;
using Alexandria.Models;
using Alexandria.Models.Models;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Lecture> GetLecture(RequestLectureGetDto requestLectureGetDto)
    {
        var lecture = await _applicationContext.Lectures.FirstOrDefaultAsync(l => 
            l.CombinePlacement == requestLectureGetDto.CombinePlacement);

        return lecture;
    }
    
    public List<Lecture> GetRecommendationsLecture(List<RequestLectureGetDto> requestLectureGetDtos)
    {
        var lecture = _applicationContext.Lectures.Where(l => l.CombinePlacement!.
            Contains(requestLectureGetDtos.First().CombinePlacement)).ToList();

        return lecture;
    }
}