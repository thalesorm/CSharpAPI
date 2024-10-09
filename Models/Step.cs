using System;
using System.Collections.Generic;

namespace ApiGap.Models;

public partial class Step
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Status { get; set; } = null!;

    public bool IsChecked { get; set; }

    public string IdAction { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Action IdActionNavigation { get; set; } = null!;
}
