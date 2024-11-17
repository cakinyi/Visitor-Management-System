using System;

namespace VisitorManagement.Models;

public class User
{
    public int Id {get; set; }
    public string Fullname {get; set;}
    public string Email{get; set;}
    public string Password{get; set;}


}
public class RegisterUser{
    public string Fullname {get; set;}
    public string Email{get; set;}
    public string Password{get; set;}
}
public class LogInUser{
    public string Email{get; set;}
    public string Password{get; set;}
}

