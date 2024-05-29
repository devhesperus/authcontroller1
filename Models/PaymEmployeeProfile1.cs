using System;
using System.Collections.Generic;

namespace HRMSAPPLICATION.Models;

public partial class PaymEmployeeProfile1
{
    public int Id { get; set; }

    public int? PnCompanyId { get; set; }

    public int? PnBranchId { get; set; }

    public int? PnEmployeeId { get; set; }

    public int? PnDivisionId { get; set; }

    public int? PnDepartmentId { get; set; }

    public int? PnDesingnationId { get; set; }

    public int? PnGradeId { get; set; }

    public int? PnShiftId { get; set; }

    public int? PnCategoryId { get; set; }

    public int? PnJobStatusId { get; set; }

    public int? PnLevelId { get; set; }

    public int? PnProjectsiteId { get; set; }

    public DateTime? DDate { get; set; }

    public string? VReason { get; set; }

    public int? RDepartment { get; set; }

    public virtual PaymCategory? PaymCategory { get; set; }

    public virtual PaymDepartment? PaymDepartment { get; set; }
}
