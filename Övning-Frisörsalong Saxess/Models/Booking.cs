using System;
using System.Collections.Generic;

namespace Övning_Frisörsalong_Saxess.Models;

public partial class Booking
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public int CustomerId { get; set; }

    public int TreatmentId { get; set; }

    public DateTime BookingDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual Treatment Treatment { get; set; } = null!;
}
