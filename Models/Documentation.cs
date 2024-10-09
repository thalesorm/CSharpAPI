using System;
using System.Collections.Generic;

namespace ApiGap.Models;

public partial class Documentation
{
    public string Id { get; set; } = null!;

    public string? TechnicalDocumentation { get; set; }

    public string? RequirementsGathering { get; set; }

    public string? UsabilityManual { get; set; }

    public string? SatisfactionIndex { get; set; }

    public string? Report { get; set; }

    public string IdAction { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Action IdActionNavigation { get; set; } = null!;
}
