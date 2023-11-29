using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThuVienPhapLuat.Utilities.Models
{
    public class ThongTinVanBan
    {
        public int Id { get; set; }
        public string? SoKyHieu { get; set; }

        public DateTime? NgayBanHanh { get; set; }

        public string? TrichYeu { get; set; }

        public string? Detailt { get; set; }

        public string? Linkdownload { get; set; }

        public string? LinhVuc { get; set; }

        public string? CoQuanBanHanh { get; set; }
    }
}
