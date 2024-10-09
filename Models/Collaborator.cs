using System;
using System.Collections.Generic;

namespace ApiGap.Models;

public partial class Collaborator
{
    public string Id { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public DateTime AdmissionDate { get; set; }

    public DateTime? ResignationDate { get; set; }

    public string AcademicFormation { get; set; } = null!;

    public string? AcademicInstitution { get; set; }

    public string? StudyArea { get; set; }

    public int? ConclusionYear { get; set; }

    public string Cpf { get; set; } = null!;

    public string? Rg { get; set; }

    public string IdUser { get; set; } = null!;

    public string IdAddress { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Actioncollaborator> Actioncollaborators { get; set; } = new List<Actioncollaborator>();

    public virtual Address IdAddressNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
