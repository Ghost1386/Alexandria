using Alexandria.Common.DTOs.LectureDTOs;
using Alexandria.Models.Models;

namespace Alexandria.BusinessLogic.Interfaces;

public interface ILectureService
{
    void CreateLecture(RequestLectureCreateDto requestLectureCreateDto, User user);

    Task<ResponseLectureGetDto> GetLecture(RequestLectureGetDto requestLectureGetDto);

    List<ResponseLectureGetDto> GetRecommendationsLecture(List<RequestLectureGetDto> requestLectureGetDtos);
}