using Alexandria.BusinessLogic.Interfaces;
using Alexandria.Common.DTOs.LectureDTOs;
using Alexandria.DAL.Interfaces;
using Alexandria.Models.Models;

namespace Alexandria.BusinessLogic.Services;

public class LectureService : ILectureService
{
    private readonly ILectureRepository _lectureRepository;
    private readonly IModificationService _modificationService;
    
    public LectureService(ILectureRepository lectureRepository, IModificationService modificationService)
    {
        _lectureRepository = lectureRepository;
        _modificationService = modificationService;
    }
    
    public void CreateLecture(RequestLectureCreateDto requestLectureCreateDto, User user)
    {
        var lecture = new Lecture
        {
            Title = requestLectureCreateDto.Title,
            Text = requestLectureCreateDto.Text,
            CombinePlacement = requestLectureCreateDto.CombinePlacement
        };

        var modification = new Modification
        {
            LastModifiedDate = DateTime.UtcNow,
            User = user,
            Lecture = lecture
        };
        
        lecture.Modifications?.Add(modification);
        
        _lectureRepository.CreateLecture(lecture);
        _modificationService.CreateModification(modification);
    }

    public async Task<ResponseLectureGetDto> GetLecture(RequestLectureGetDto requestLectureGetDto)
    {
        var lecture = await _lectureRepository.GetLecture(requestLectureGetDto);

        var responseLectureGetDto = new ResponseLectureGetDto
        {
            CombinePlacement = lecture.CombinePlacement,
            Title = lecture.Title,
            Text = lecture.Title
        };
        
        return responseLectureGetDto;
    }
    
    public List<ResponseLectureGetDto> GetRecommendationsLecture(List<RequestLectureGetDto> requestLectureGetDtos)
    {
        var lectures = _lectureRepository.GetRecommendationsLecture(requestLectureGetDtos);

        var responseLectureGetDtos = lectures.Select(l => new ResponseLectureGetDto
        {
            CombinePlacement = l.CombinePlacement,
            Title = l.Title,
            Text = l.Text
        }).ToList();

        var responseLectureGetDtosWithoutDupes = responseLectureGetDtos.Distinct().ToList();
        
        return responseLectureGetDtosWithoutDupes;
    }
}