using System.ComponentModel.DataAnnotations;

namespace COA_Api.Core.Models.DTOs;

public class UserCreateDTO
{
    [Required(ErrorMessage = "UserName is required")]
    public string UserName {set;get;}

    [Required(ErrorMessage = "Name is required")]
    public string Name {set;get;}
    
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public string Email {set;get;}
    public string Phone {set;get;}
}