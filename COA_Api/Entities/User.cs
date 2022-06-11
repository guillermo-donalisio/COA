using System.ComponentModel.DataAnnotations;

namespace COA_Api.Entities;

public class User
{
    [Key]
    [Required]
    public int UserID {set;get;}

    [Required]
    public string UserName {set;get;}

    [Required]
    public string Name {set;get;}
    
    [Required]
    public string Email {set;get;}
    public string Phone {set;get;}

    public User(int id, string username, string name, string email, string phone)
    {
        this.UserID = id;
        this.UserName = username;
        this.Name = name;
        this.Email = email;
        this.Phone = phone;
    }
}
