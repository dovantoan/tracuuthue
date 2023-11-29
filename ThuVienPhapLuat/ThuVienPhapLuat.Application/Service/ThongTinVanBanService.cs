using DataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuVienPhapLuat.Application.Dtos.RepositoryImplement;
using ThuVienPhapLuat.Utilities.Models;

namespace ThuVienPhapLuat.Application.Service
{
    public class ThongTinVanBanService
    {
        private readonly ThongTinVanBanImplement implement;
        private readonly thuVienPhapLuatDBContext _context;
        public ThongTinVanBanService(thuVienPhapLuatDBContext context)
        {
            _context = context;
            implement = new ThongTinVanBanImplement(context);
        }
        public SearchResult<List<ThongTinVanBan>> GetListThongTinVanBan(int? linhVucId, int? coQuanBanHanhId, string soKyHieu, DateTime? fromDate, DateTime? toDate, int rowNum, int pageNum)
        {
            return implement.GetListThongTinVanBan(linhVucId, coQuanBanHanhId, soKyHieu, fromDate, toDate, rowNum, pageNum);
        }
        public SearchResult<List<CoQuanBanHanh>> GetAllCoQuanBanHanh()
        {
            return implement.GetAllCoQuanBanHanh();
        }
        public SearchResult<List<LinhVuc>> GetAllLinhVuc()
        {
            return implement.GetAllLinhVuc();
        }
    }
}
