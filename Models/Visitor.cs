using System;

namespace VisitorManagement.Models;

public class Visitor
{
    public int Id{get; set;}
    public string Fullname{get; set;}
    public string Email{get; set;}
    public string PhoneNumber{get; set;}
    public DateTime TimeIn{get; set;}
    public DateTime TimeOut{get; set;}
}

