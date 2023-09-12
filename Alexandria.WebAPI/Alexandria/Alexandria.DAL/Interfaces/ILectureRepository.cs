using Alexandria.Models.Models;

namespace Alexandria.DAL.Interfaces;

public interface ILectureRepository
{
    void CreateLecture(Lecture lecture);
}