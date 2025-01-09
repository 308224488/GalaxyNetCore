using System;
using System.Collections.Generic;

namespace GalaxyNetCore.Domain.Entities;

public partial class RiskManagementConfig
{
    public int Id { get; set; }

    public string ParameterName { get; set; } = null!;

    public string ParameterValue { get; set; } = null!;

    public string? Description { get; set; }
}
