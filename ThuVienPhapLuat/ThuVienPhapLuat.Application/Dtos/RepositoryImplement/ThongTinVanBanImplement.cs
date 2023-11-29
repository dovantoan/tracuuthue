using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuVienPhapLuat.Application.Dtos.IRepositoryImplement;
using ThuVienPhapLuat.Application.Dtos.Repository;
using ThuVienPhapLuat.Utilities.Models;

namespace ThuVienPhapLuat.Application.Dtos.RepositoryImplement
{
    public class ThongTinVanBanImplement : IThongTinVanBanImplement
    {
        private readonly ThongTinVanBanRepository repository;
        private readonly thuVienPhapLuatDBContext _context;
        //public ThongTinVanBanRepository(thuVienPhapLuatDBContext context)
        //{
        //    _context = context;
        //}
        public ThongTinVanBanImplement(thuVienPhapLuatDBContext context)
        {
            _context = context;
            repository = new ThongTinVanBanRepository(context);
        }

        public SearchResult<List<CoQuanBanHanh>> GetAllCoQuanBanHanh()
        {
           return repository.GetAllCoQuanBanHanh();
        }

        public SearchResult<List<LinhVuc>> GetAllLinhVuc()
        {
            return repository.GetAllLinhVuc();
        }

        public SearchResult<List<ThongTinVanBan>> GetListThongTinVanBan(int? linhVucId, int? coQuanBanHanhId, string soKyHieu, DateTime? fromDate, DateTime? toDate, int rowNum, int pageNum)
        {
            return repository.GetListThongTinVanBan(linhVucId, coQuanBanHanhId,soKyHieu,fromDate,toDate, rowNum, pageNum);
        }
    }
}
