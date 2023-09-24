using System.Text.Json;
using Alexandria.BusinessLogic.Interfaces;
using Alexandria.Common.DTOs.LectureDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alexandria.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class LectureController : ControllerBase
{
    private readonly ILogger<LectureController> _logger;
    private readonly ILectureService _lectureService;
    private readonly IUserService _userService;
    private readonly IReviewService _reviewService;
    private readonly AuthController _authController;
    
    public LectureController(ILogger<LectureController> logger, ILectureService lectureService, 
        IUserService userService, IReviewService reviewService, AuthController authController)
    {
        _logger = logger;
        _lectureService = lectureService;
        _userService = userService;
        _reviewService = reviewService;
        _authController = authController;
    }
    
    [Authorize]
    [HttpPost("/lecture/create")]
    public async Task<IActionResult> Create(RequestLectureCreateDto requestLectureCreateDto)
    {
        try
        {
            var identifier = _authController.GetUserIdentifier();

            var user = await _userService.GetUser(identifier);

            _lectureService.CreateLecture(requestLectureCreateDto, user);
        
            _logger.LogInformation($"{DateTime.UtcNow}: User with email {user.UserId} " +
                                   $"created lecture {requestLectureCreateDto.Title}");
        
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError($"{DateTime.UtcNow}: {e.Message}");

            return BadRequest();
        }
    }
    
    [Authorize]
    [HttpPost("/lecture/get")]
    public async Task<IActionResult> Get(RequestLectureGetDto requestLectureGetDto)
    {
        try
        {
            var lecture = await _lectureService.GetLecture(requestLectureGetDto);

            var identifier = _authController.GetUserIdentifier();

            _reviewService.CreateReview(identifier, requestLectureGetDto);

            var jsonLecture = JsonSerializer.Serialize(lecture);
            
            return Ok(jsonLecture);
        }
        catch (Exception e)
        {
            _logger.LogError($"{DateTime.UtcNow}: {e.Message}");

            return BadRequest();
        }
    }
}