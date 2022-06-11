using System.ComponentModel.DataAnnotations;

namespace COA_Api.Entities;

public class BaseEntity
{   
    [Key]
    [Required]
    public int ID {set;get;}
    public bool isActive {set;get;}
}
