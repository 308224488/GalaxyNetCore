using System;
using System.Collections.Generic;

namespace GalaxyNetCore.Domain.Entities;

public partial class StrategyConfig
{
    public int Id { get; set; }

    public string ParameterName { get; set; } = null!;

    public string ParameterValue { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<TradeHistory> TradeHistories { get; set; } = new List<TradeHistory>();
}
