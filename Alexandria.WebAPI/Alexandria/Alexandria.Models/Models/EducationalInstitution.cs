using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alexandria.Models.Models;

public class EducationalInstitution
{
    [Key]
    public int EducationalInstitutionId { get; set; }
    
    public string? CombinePlacement { get; set; }
    
    [ForeignKey("LectureId")]
    public int LectureId { get; set; }
    
    public Lecture? Lecture { get; set; }
}