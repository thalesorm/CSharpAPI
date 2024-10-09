using System;
using System.Collections.Generic;

namespace ApiGap.Models;

public partial class Actioncollaborator
{
    public string Id { get; set; } = null!;

    public string Responsability { get; set; } = null!;

    public string IdAction { get; set; } = null!;

    public string IdCollaborator { get; set; } = null!;

    public string IdUser { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Action IdActionNavigation { get; set; } = null!;

    public virtual Collaborator IdCollaboratorNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
