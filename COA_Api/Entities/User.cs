using System.ComponentModel.DataAnnotations;

namespace COA_Api.Entities;

public class User : BaseEntity
{
    [Required]
    public string UserName {set;get;}

    [Required]
    public string Name {set;get;}
    
    [Required]
    public string Email {set;get;}
    public string Phone {set;get;}

    public User(int id, string username, string name, string email, string phone)
    {
        this.ID = id;
        this.UserName = username;
        this.Name = name;
        this.Email = email;
        this.Phone = phone;
    }
}
