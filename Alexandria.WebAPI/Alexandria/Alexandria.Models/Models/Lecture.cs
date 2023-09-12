using System.ComponentModel.DataAnnotations;

namespace Alexandria.Models.Models;

public class Lecture
{
    [Key]
    public int LectureId { get; set; }

    public string? Title { get; set; }
    
    public string? Text { get; set; }
    
    public string? CombinePlacement { get; set; }
    
    public List<Modification>? Modifications { get; set; }
}