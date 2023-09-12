using System.ComponentModel.DataAnnotations.Schema;

namespace Alexandria.Models.Models;

public class Modification
{
    public int ModificationId { get; set; }
    
    public DateTime LastModifiedDate { get; set; }
    
    [ForeignKey("LectureId")]
    public int LectureId { get; set; }
    
    public Lecture? Lecture { get; set; }
    
    [ForeignKey("UserId")]
    public int UserId { get; set; }
     
    public User? User { get; set; }
}