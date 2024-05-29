using System;
using System.Collections.Generic;

namespace HRMSAPPLICATION.Models;

public partial class Asset
{
    public int PnCompanyId { get; set; }

    public int BranchId { get; set; }

    public int PnAssetid { get; set; }

    public string AssetName { get; set; } = null!;
}
