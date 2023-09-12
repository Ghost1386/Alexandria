using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alexandria.Models.Models;

public class Lecture
{
    [Key]
    public int LectureId { get; set; }

    public string? Title { get; set; }
    
    public string? Text { get; set; }
    
    [ForeignKey("EducationalInstitutionId")]
    public int EducationalInstitutionId { get; set; }
    
    public EducationalInstitution? EducationalInstitution { get; set; }
    
    public List<Modification>? Modifications { get; set; }
}