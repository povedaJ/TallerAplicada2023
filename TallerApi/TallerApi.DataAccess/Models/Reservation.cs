using System;
using System.Collections.Generic;

namespace TallerApi.DataAccess.Models;

public partial class Reservation
{
    public Guid ReservationId { get; set; }

    public Guid CustomerId { get; set; }

    public int RoomId { get; set; }

    public DateTime ReservationDate { get; set; }

    public DateTime CheckInDate { get; set; }

    public DateTime CheckOutDate { get; set; }

    public int Customersln { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
