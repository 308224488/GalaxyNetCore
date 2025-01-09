using System;
using System.Collections.Generic;

namespace GalaxyNetCore.Domain.Entities;

public partial class TimeFrame
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<MarketDatum> MarketData { get; set; } = new List<MarketDatum>();
}
