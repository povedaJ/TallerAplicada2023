using System;
using System.Collections.Generic;

namespace TallerApi.DataAccess.Models;

public partial class Facility
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
}
