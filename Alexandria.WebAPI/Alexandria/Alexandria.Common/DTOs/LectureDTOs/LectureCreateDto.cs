namespace Alexandria.Common.DTOs.LectureDTOs;

public class LectureCreateDto
{
    public string? Title { get; set; }
    
    public string? Text { get; set; }
    
    public string? CombinePlacement { get; set; }
    
    public DateTime LastModifiedDate { get; set; }
    
    public int UserId { get; set; }
}