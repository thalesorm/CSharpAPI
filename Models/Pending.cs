using System;
using System.Collections.Generic;

namespace ApiGap.Models;

public partial class Pending
{
    public string Id { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string IdMeeting { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string PendingDescription { get; set; } = null!;

    public virtual Meeting IdMeetingNavigation { get; set; } = null!;
}
