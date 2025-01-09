using System;
using System.Collections.Generic;

namespace GalaxyNetCore.Domain.Entities;

public partial class TradeHistory
{
    public int Id { get; set; }

    public int TradingPairId { get; set; }

    public string OrderType { get; set; } = null!;

    public DateTime TradeTime { get; set; }

    public decimal Price { get; set; }

    public decimal Quantity { get; set; }

    public string Status { get; set; } = null!;

    public int? StrategyConfigId { get; set; }

    public virtual StrategyConfig? StrategyConfig { get; set; }

    public virtual TradingPair TradingPair { get; set; } = null!;
}
