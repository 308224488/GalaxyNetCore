using System;
using System.Collections.Generic;
using GalaxyNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GalaxyNetCore.Infrastructure.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<MarketDatum> MarketData { get; set; }

    public virtual DbSet<RiskManagementConfig> RiskManagementConfigs { get; set; }

    public virtual DbSet<StrategyConfig> StrategyConfigs { get; set; }

    public virtual DbSet<TimeFrame> TimeFrames { get; set; }

    public virtual DbSet<TradeHistory> TradeHistories { get; set; }

    public virtual DbSet<TradingPair> TradingPairs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // 可选：你可以在这里配置默认连接字符串，或者完全移除
            // optionsBuilder.UseSqlServer("Your_Default_Connection_String");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Logs__3214EC07B9473F96");

            entity.Property(e => e.ClientIp).HasMaxLength(45);
            entity.Property(e => e.LogDate).HasColumnType("datetime");
            entity.Property(e => e.LogLevel).HasMaxLength(50);
            entity.Property(e => e.Logger).HasMaxLength(255);
            entity.Property(e => e.Method).HasMaxLength(255);
            entity.Property(e => e.RequestMethod).HasMaxLength(10);
            entity.Property(e => e.RequestPath).HasMaxLength(500);
            entity.Property(e => e.UserId).HasMaxLength(100);
        });

        modelBuilder.Entity<MarketDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MarketDa__3214EC07015CC78C");

            entity.HasIndex(e => e.TimeFrameId, "IDX_MarketData_TimeFrameId");

            entity.HasIndex(e => e.Timestamp, "IDX_MarketData_Timestamp");

            entity.HasIndex(e => e.TradingPairId, "IDX_MarketData_TradingPairId");

            entity.Property(e => e.ClosePrice).HasColumnType("decimal(18, 8)");
            entity.Property(e => e.HighPrice).HasColumnType("decimal(18, 8)");
            entity.Property(e => e.LowPrice).HasColumnType("decimal(18, 8)");
            entity.Property(e => e.OpenPrice).HasColumnType("decimal(18, 8)");
            entity.Property(e => e.Timestamp).HasColumnType("datetime");

            entity.HasOne(d => d.TimeFrame).WithMany(p => p.MarketData)
                .HasForeignKey(d => d.TimeFrameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MarketData_TimeFrame");

            entity.HasOne(d => d.TradingPair).WithMany(p => p.MarketData)
                .HasForeignKey(d => d.TradingPairId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MarketData_TradingPair");
        });

        modelBuilder.Entity<RiskManagementConfig>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RiskMana__3214EC07E30BF2AD");

            entity.ToTable("RiskManagementConfig");

            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.ParameterName).HasMaxLength(50);
            entity.Property(e => e.ParameterValue).HasMaxLength(50);
        });

        modelBuilder.Entity<StrategyConfig>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Strategy__3214EC0722E947F7");

            entity.ToTable("StrategyConfig");

            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.ParameterName).HasMaxLength(50);
            entity.Property(e => e.ParameterValue).HasMaxLength(50);
        });

        modelBuilder.Entity<TimeFrame>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TimeFram__3214EC079C6AD95D");

            entity.HasIndex(e => e.Name, "UQ__TimeFram__737584F699A57454").IsUnique();

            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<TradeHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TradeHis__3214EC07201E6403");

            entity.ToTable("TradeHistory");

            entity.HasIndex(e => e.TradeTime, "IDX_TradeHistory_TradeTime");

            entity.HasIndex(e => e.TradingPairId, "IDX_TradeHistory_TradingPairId");

            entity.Property(e => e.OrderType).HasMaxLength(20);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 8)");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 8)");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.TradeTime).HasColumnType("datetime");

            entity.HasOne(d => d.StrategyConfig).WithMany(p => p.TradeHistories)
                .HasForeignKey(d => d.StrategyConfigId)
                .HasConstraintName("FK_TradeHistory_StrategyConfig");

            entity.HasOne(d => d.TradingPair).WithMany(p => p.TradeHistories)
                .HasForeignKey(d => d.TradingPairId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TradeHistory_TradingPair");
        });

        modelBuilder.Entity<TradingPair>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TradingP__3214EC0700CD8EAD");

            entity.HasIndex(e => e.Symbol, "UQ__TradingP__B7CC3F01BB11741C").IsUnique();

            entity.Property(e => e.BaseAsset).HasMaxLength(20);
            entity.Property(e => e.QuoteAsset).HasMaxLength(20);
            entity.Property(e => e.Symbol).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
