using System;
using System.Collections.Generic;

namespace HRMSAPPLICATION.Models;

public partial class PaymShift
{
    public int PnCompanyId { get; set; }

    public int PnShiftId { get; set; }

    public string VShiftName { get; set; } = null!;

    public string? VShiftFrom { get; set; }

    public string? VShiftTo { get; set; }

    public string? Status { get; set; }

    public int? BranchId { get; set; }

    public string? VShiftCategory { get; set; }

    public virtual PaymCompany PnCompany { get; set; } = null!;
}
