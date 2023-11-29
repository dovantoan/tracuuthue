using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entity;

public partial class ThongTinVanBan
{
    public long Id { get; set; }

    public string? SoKyHieu { get; set; }

    public DateTime? NgayBanHanh { get; set; }

    public string? TrichYeu { get; set; }

    public string? Detailt { get; set; }

    public string? Linkdownload { get; set; }

    public int? LinhVuc { get; set; }

    public int? CoQuanBanHanh { get; set; }

    public DateTime? NgayTao { get; set; }
}
