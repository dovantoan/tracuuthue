using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuVienPhapLuat.Utilities.Models;

namespace ThuVienPhapLuat.Application.Dtos.IRepository
{
    public interface IThongTinVanBanRepository
    {
        public SearchResult<List<ThongTinVanBan>> GetListThongTinVanBan(int? linhVucId,int? coQuanBanHanhId,string soKyHieu,DateTime? fromDate, DateTime? toDate, int rowNum,int pageNum);
        public SearchResult<List<LinhVuc>> GetAllLinhVuc();
        public SearchResult<List<CoQuanBanHanh>> GetAllCoQuanBanHanh();
    }
}
