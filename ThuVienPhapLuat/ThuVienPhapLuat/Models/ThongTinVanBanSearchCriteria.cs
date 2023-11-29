using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Globalization;

namespace ThuVienPhapLuat.Models
{
    public class ThongTinVanBanSearchCriteria: BaseSearchCriteria
    {
        public int? LinhVucId { get; set; }

        public int? CoQuanBanHanhId { get; set; }

        public string SoKyHieu { get; set; }

        public string? StrFromDate { get; set; }
        public DateTime? FromDate 
        { 
            get { 
                return string.IsNullOrEmpty(StrFromDate) ? null : DateTime.ParseExact(StrFromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            } 
        }

        public string? StrToDate { get; set; }
        public DateTime? ToDate 
        { 
            get { 
                return string.IsNullOrEmpty(StrToDate) ? null : DateTime.ParseExact(StrToDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            } 
        }

        public int Skip { get { return PageIndex * RowNumber; } }

        public int Task { get { return RowNumber; } }
    }
}
