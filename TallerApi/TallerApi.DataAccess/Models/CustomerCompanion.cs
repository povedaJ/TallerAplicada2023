using System;
using System.Collections.Generic;

namespace TallerApi.DataAccess.Models;

public partial class CustomerCompanion
{
    public Guid CustomerId { get; set; }

    public int Cedula { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public Guid? CompanionId { get; set; }

    public virtual Customer? Companion { get; set; }
}
