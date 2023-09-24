using Alexandria.Common.DTOs.LectureDTOs;
using Alexandria.Models.Models;

namespace Alexandria.DAL.Interfaces;

public interface ILectureRepository
{
    void CreateLecture(Lecture lecture);

    Task<Lecture> GetLecture(RequestLectureGetDto requestLectureGetDto);

    List<Lecture> GetRecommendationsLecture(List<RequestLectureGetDto> requestLectureGetDtos);
}