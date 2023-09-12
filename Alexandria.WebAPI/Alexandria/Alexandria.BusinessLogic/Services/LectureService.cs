using Alexandria.BusinessLogic.Interfaces;
using Alexandria.Common.DTOs;
using Alexandria.Common.DTOs.LectureDTOs;
using Alexandria.DAL.Interfaces;
using Alexandria.Models.Models;

namespace Alexandria.BusinessLogic.Services;

public class LectureService : ILectureService
{
    private readonly IUserRepository _userRepository;
    private readonly ILectureRepository _lectureRepository;
    private readonly IEducationalInstitutionRepository _educationalInstitutionRepository;
    private readonly IModificationRepository _modificationRepository;
    
    public LectureService(IUserRepository userRepository, ILectureRepository lectureRepository, 
        IEducationalInstitutionRepository educationalInstitutionRepository, IModificationRepository modificationRepository)
    {
        _userRepository = userRepository;
        _lectureRepository = lectureRepository;
        _educationalInstitutionRepository = educationalInstitutionRepository;
        _modificationRepository = modificationRepository;
    }
    
    public async void CreateLecture(LectureCreateDto lectureCreateDto, Identifier identifier)
    {
        var lecture = new Lecture
        {
            Title = lectureCreateDto.Title,
            Text = lectureCreateDto.Text,
        };

        var educationalInstitution = new EducationalInstitution
        {
            CombinePlacement = lectureCreateDto.CombinePlacement,
            Lecture = lecture
        };

        var modification = new Modification
        {
            LastModifiedDate = DateTime.UtcNow,
            User = await _userRepository.GetUser(identifier),
            Lecture = lecture
        };
        
        lecture.Modifications.Add(modification);
        
        _lectureRepository.CreateLecture(lecture);
        _educationalInstitutionRepository.CreateEducationalInstitution(educationalInstitution);
        _modificationRepository.CreateModification(modification);
    }
}