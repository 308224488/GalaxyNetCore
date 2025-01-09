using System;
using System.Collections.Generic;

namespace GalaxyNetCore.Domain.Entities;

public partial class TradingPair
{
    public int Id { get; set; }

    public string Symbol { get; set; } = null!;

    public string BaseAsset { get; set; } = null!;

    public string QuoteAsset { get; set; } = null!;

    public virtual ICollection<MarketDatum> MarketData { get; set; } = new List<MarketDatum>();

    public virtual ICollection<TradeHistory> TradeHistories { get; set; } = new List<TradeHistory>();
}
