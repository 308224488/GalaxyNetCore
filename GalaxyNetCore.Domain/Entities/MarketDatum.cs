using System;
using System.Collections.Generic;

namespace GalaxyNetCore.Domain.Entities;

public partial class MarketDatum
{
    public int Id { get; set; }

    public int TradingPairId { get; set; }

    public int TimeFrameId { get; set; }

    public decimal OpenPrice { get; set; }

    public decimal HighPrice { get; set; }

    public decimal LowPrice { get; set; }

    public decimal ClosePrice { get; set; }

    public DateTime Timestamp { get; set; }

    public int Confirm { get; set; }

    public virtual TimeFrame TimeFrame { get; set; } = null!;

    public virtual TradingPair TradingPair { get; set; } = null!;
}
