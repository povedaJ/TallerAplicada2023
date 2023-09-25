using System;
using System.Collections.Generic;

namespace TallerApi.DataAccess.Models;

public partial class Customer
{
    public Guid CustomerId { get; set; }

    public int Cedula { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<CustomerCompanion> CustomerCompanions { get; set; } = new List<CustomerCompanion>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
