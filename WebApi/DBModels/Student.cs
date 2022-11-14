using System;
using System.Collections.Generic;

namespace WebApi.DBModels;

public partial class Student
{
    public int Id { get; set; }

    public string? Studentname { get; set; }

    public int? Mobilenumber { get; set; }

    public string? Companyname { get; set; }
}
