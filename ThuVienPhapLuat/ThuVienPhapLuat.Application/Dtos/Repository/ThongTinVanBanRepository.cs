using DataAccessLayer.Data;
//using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuVienPhapLuat.Application.Dtos.IRepository;
using ThuVienPhapLuat.Application.Helper;
using ThuVienPhapLuat.Utilities.Models;

namespace ThuVienPhapLuat.Application.Dtos.Repository
{
    public class ThongTinVanBanRepository : IThongTinVanBanRepository
    {
        private readonly thuVienPhapLuatDBContext _context;
        public ThongTinVanBanRepository(thuVienPhapLuatDBContext context)
        {
            _context = context;
        }

        public SearchResult<List<CoQuanBanHanh>> GetAllCoQuanBanHanh()
        {
            SearchResult<List<CoQuanBanHanh>> result = new SearchResult<List<CoQuanBanHanh>>();
            try
            {
                DataTable dt = new DataTable();
                SqlHelper hp = new SqlHelper(_context);
                dt = hp.SearchStoreProcedureDataTable("sp_GetAllCoQuanBanHanh", null);
                var ls = new List<CoQuanBanHanh>();
                if (dt != null && dt.Rows.Count > 0)
                {
                    ls.Add(new CoQuanBanHanh { Id = 0, Ten = "Chọn tất cả" });
                    foreach (DataRow row in dt.Rows)
                    {
                        ls.Add(new CoQuanBanHanh
                        {
                            Id = Int32.Parse(row["Id"].ToString()),
                            Ten = row["Ten"].ToString()
                        });
                    }
                    result.Data = ls;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Success = false;
                result.Data = null;
            }
            return result;
        }

        public SearchResult<List<LinhVuc>> GetAllLinhVuc()
        {
            SearchResult<List<LinhVuc>> result = new SearchResult<List<LinhVuc>>();
            try
            {
                DataTable dt = new DataTable();
                SqlHelper hp = new SqlHelper(_context);
                dt = hp.SearchStoreProcedureDataTable("sp_GetAllLinhVuc", null);
                var ls = new List<LinhVuc>();
                if (dt != null && dt.Rows.Count > 0)
                {
                    ls.Add(new LinhVuc { Id = 0, Ten = "Chọn tất cả" });
                    foreach (DataRow row in dt.Rows)
                    {
                        ls.Add(new LinhVuc
                        {
                            Id = Int32.Parse(row["Id"].ToString()),
                            Ten = row["Ten"].ToString()
                        });
                    }
                    result.Data = ls;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Success = false;
                result.Data = null;
            }
            return result;
        }

        public SearchResult<List<ThongTinVanBan>> GetListThongTinVanBan(int? linhVucId, int? coQuanBanHanhId, string soKyHieu, DateTime? fromDate, DateTime? toDate, int rowNum, int pageNum)
        {
            SearchResult<List<ThongTinVanBan>> result = new SearchResult<List<ThongTinVanBan>>();
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDBParameter[] inputParams = new SqlDBParameter[7];
                inputParams[0] = new SqlDBParameter("@LINHVUCID", SqlDbType.Int, linhVucId);
                inputParams[1] = new SqlDBParameter("@COQUANBANHANHID", SqlDbType.Int, coQuanBanHanhId);
                inputParams[2] = new SqlDBParameter("@SOKYHIEU", SqlDbType.NVarChar,250, soKyHieu);
                inputParams[3] = new SqlDBParameter("@SKIP", SqlDbType.Int, rowNum);
                inputParams[4] = new SqlDBParameter("@TASK", SqlDbType.Int, pageNum);
                inputParams[5] = new SqlDBParameter("@FROMDATE", SqlDbType.DateTime, fromDate);
                inputParams[6] = new SqlDBParameter("@TODATE", SqlDbType.DateTime, toDate);
                SqlHelper hp = new SqlHelper(_context);
                ds = hp.SearchStoreProcedure("sp_ThongTinVanBan_Search", inputParams);
                var ls = new List<ThongTinVanBan>();
                dt = ds.Tables[1];
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ls.Add(new ThongTinVanBan
                        {
                            Id = Int32.Parse(row["Id"].ToString()),
                            SoKyHieu = row["SoKyHieu"].ToString(),
                            CoQuanBanHanh = row["CoQuanBanHanhTen"].ToString(),
                            LinhVuc = row["LinhVucTen"].ToString(),
                            TrichYeu = row["TrichYeu"].ToString(),
                            NgayBanHanh = DateTime.Parse(row["NgayBanHanh"].ToString()),
                            Detailt = row["Detailt"].ToString(),
                            Linkdownload = row["Linkdownload"].ToString()
                        });
                    }
                    result.Data = ls;
                    result.TotalRows = ds.Tables[0].Rows[0].Field<int>(0);
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Success = false;
                result.Data = null;
            }
            return result;
        }
    }
}
