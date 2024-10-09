using System;
using System.Collections.Generic;

namespace ApiGap.Models;

public partial class Log
{
    public string Id { get; set; } = null!;

    public string TableName { get; set; } = null!;

    public string ColumnName { get; set; } = null!;

    public string Action { get; set; } = null!;

    public string? OldValue { get; set; }

    public string? NewValue { get; set; }

    public string IdObject { get; set; } = null!;

    public string IdUser { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
