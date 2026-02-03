using System;
using System.Collections.Generic;

namespace Övning_Frisörsalong_Saxess.Models;

public partial class Treatment
{
    public int Id { get; set; }

    public string Treatmentname { get; set; } = null!;

    public int Duration { get; set; }

    public decimal Price { get; set; }

    public bool? Avaible { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
