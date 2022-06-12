using System.ComponentModel.DataAnnotations;

namespace COA_Api.Entities;

public class User : BaseEntity
{
    [Required]
    [MaxLength(50)]
    public string UserName {set;get;}

    [Required]
    [MaxLength(50)]
    public string Name {set;get;}
    
    [Required]
    [EmailAddress]
    public string Email {set;get;}

    [MaxLength(30)]
    public string Phone {set;get;}

    public User(int id, string username, string name, string email, string phone)
    {
        this.ID = id;
        this.UserName = username;
        this.Name = name;
        this.Email = email;
        this.Phone = phone;
    }
    public User()
    {        
    }
}
