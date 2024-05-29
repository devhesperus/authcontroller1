using System;
using System.Collections.Generic;

namespace HRMSAPPLICATION.Models;

public partial class PaymEmployee
{
    public int PnCompanyId { get; set; }

    public int PnBranchId { get; set; }

    public int PnEmployeeId { get; set; }

    public string? EmployeeCode { get; set; }

    public string? EmployeeFirstName { get; set; }

    public string? EmployeeMiddleName { get; set; }

    public string? EmployeeLastName { get; set; }

    public DateTime? DateofBirth { get; set; }

    public string? Password { get; set; }

    public string? Gender { get; set; }

    public string? Status { get; set; }

    public string? EmployeeFullName { get; set; }

    public int? Readerid { get; set; }

    public string? OtEligible { get; set; }

    public string? Pfno { get; set; }

    public string? Esino { get; set; }

    public double? OtCalc { get; set; }

    public double? Ctc { get; set; }

    public double? BasicSalary { get; set; }

    public string? BankCode { get; set; }

    public string? BankName { get; set; }

    public string? BranchName { get; set; }

    public string? AccountType { get; set; }

    public string? MicrCode { get; set; }

    public string? IfscCode { get; set; }

    public string? Address { get; set; }

    public string? OtherInfo { get; set; }

    public string? ReportingPerson { get; set; }

    public int? ReportingId { get; set; }

    public string? ReportingEmail { get; set; }

    public string? PanNo { get; set; }

    public string? CardNo { get; set; }

    public string? SalaryType { get; set; }

    public string? TdsApplicable { get; set; }

    public string? Flag { get; set; }

    public int? Role { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual PaymBranch PaymBranch { get; set; } = null!;

    public virtual ICollection<PaymEmpDeduction> PaymEmpDeductions { get; set; } = new List<PaymEmpDeduction>();

    public virtual ICollection<PaymEmpEarning> PaymEmpEarnings { get; set; } = new List<PaymEmpEarning>();

    public virtual PaymEmployeeWorkDetail? PaymEmployeeWorkDetail { get; set; }
}
