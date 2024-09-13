using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoginRegi.Models;

public partial class User
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? gender { get; set; }

    public string? age { get; set; }

    public string? email { get; set; }
/*
    [DataType(DataType.Password)]*/

    public string? password { get; set; }
}
