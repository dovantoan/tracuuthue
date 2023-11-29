using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuVienPhapLuat.Utilities.Models;

namespace ThuVienPhapLuat.Application.Dtos.IRepositoryImplement
{
    public interface IThongTinVanBanImplement
    {
        public SearchResult<List<ThongTinVanBan>> GetListThongTinVanBan(int? linhVucId, int? coQuanBanHanhId,string soKyHieu, DateTime? fromDate, DateTime? toDate, int rowNum, int pageNum);
        public SearchResult<List<CoQuanBanHanh>> GetAllCoQuanBanHanh();
        public SearchResult<List<LinhVuc>> GetAllLinhVuc();
    }
}
