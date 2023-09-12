using Alexandria.Common.DTOs;
using Alexandria.Common.DTOs.LectureDTOs;

namespace Alexandria.BusinessLogic.Interfaces;

public interface ILectureService
{
    void CreateLecture(LectureCreateDto lectureCreateDto, Identifier identifier);
}