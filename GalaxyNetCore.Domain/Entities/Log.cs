using System;
using System.Collections.Generic;

namespace GalaxyNetCore.Domain.Entities;

public partial class Log
{
    public int Id { get; set; }

    public DateTime LogDate { get; set; }

    public string LogLevel { get; set; } = null!;

    public string Message { get; set; } = null!;

    public string Logger { get; set; } = null!;

    public string? Exception { get; set; }

    public string? Method { get; set; }

    public string? RequestPath { get; set; }

    public string? RequestMethod { get; set; }

    public string? RequestHeaders { get; set; }

    public string? RequestBody { get; set; }

    public string? UserId { get; set; }

    public string? ClientIp { get; set; }

    public int? ExecutionDuration { get; set; }
}
