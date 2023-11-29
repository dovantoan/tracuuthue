using ClosedXML.Excel;
using DataAccessLayer.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection.Metadata;
using ThuVienPhapLuat.Application.Service;
using ThuVienPhapLuat.DataProcessing;
using ThuVienPhapLuat.Models;
using ThuVienPhapLuat.Utilities.Models;

namespace ThuVienPhapLuat.Controllers
{
    public class HomeController : Controller
    {
        private readonly thuVienPhapLuatDBContext _context;

        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(ILogger<HomeController> logger, thuVienPhapLuatDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var result = new JsonSearchResultCriteria<IList<CoQuanBanHanh>>();
            ThongTinVanBanService sv = new ThongTinVanBanService(_context);
            try
            {
                SearchResult<List<CoQuanBanHanh>> data = sv.GetAllCoQuanBanHanh();
                if (data != null)
                {
                    ViewBag.listCoQuanBanHanh = data.Data;
                }
                SearchResult<List<LinhVuc>> data2 = sv.GetAllLinhVuc();
                if (data != null)
                {
                    ViewBag.listLinhVuc = data2.Data;
                }
            }
            catch (Exception ex)
            {
                
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[AllowAnonymous]
        [HttpPost]
        public JsonResult SearchThongTinVanBan(ThongTinVanBanSearchCriteria searchEntity)
        {
            ThongTinVanBanService sv = new ThongTinVanBanService(_context);
            var result = new JsonSearchResultCriteria<IList<ThongTinVanBan>>();
            try {
                if (searchEntity != null)
                {
                    SearchResult<List<ThongTinVanBan>> data = sv.GetListThongTinVanBan(searchEntity.LinhVucId, searchEntity.CoQuanBanHanhId,searchEntity.SoKyHieu,searchEntity.FromDate,searchEntity.ToDate, searchEntity.Skip,searchEntity.Task);
                    if (data != null)
                    {
                        result.Data = data.Data;
                        result.TotalRows = data.TotalRows;
                        result.Success = true;
                        return Json(result);
                    }
                }
            }
            catch(Exception ex)
            {
                result.ExceptionMessage = ex.Message;
            }
            return Json(new
            {
                Success = true,
                Message =""
            });
        }

        [HttpPost]
        public JsonResult ExporDataToFile(ThongTinVanBanSearchCriteria searchEntity)
        {
            ThongTinVanBanService sv = new ThongTinVanBanService(_context);
            try
            {
                if (searchEntity != null)
                {
                    SearchResult<List<ThongTinVanBan>> data = sv.GetListThongTinVanBan(searchEntity.LinhVucId, searchEntity.CoQuanBanHanhId, searchEntity.SoKyHieu, searchEntity.FromDate, searchEntity.ToDate, searchEntity.Skip, searchEntity.Task);
                    if (data.Data != null)
                    {
                        var templateFileInfo = new FileInfo(Path.Combine(_webHostEnvironment.ContentRootPath, "Template", "ReportData_template.xlsx"));
                        MemoryStream stream = ReportData.UpdateDataIntoExcelTemplate(data.Data, templateFileInfo);
                        //return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ThongTinVanBanReport-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx");
                        var bytesdata = File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ThongTinVanBanReport-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx");
                        return Json(bytesdata);

                    }
                }
            }
            catch (Exception ex)
            {
                //result.ExceptionMessage = ex.Message;
            }
            return null;
        }

        public IActionResult DecodeFileToBase64(string b64Str)
        {
            string pathFile = Path.Combine(_webHostEnvironment.ContentRootPath, "Temp");
            ReportData.decodeFileToBase64(b64Str, pathFile);
            return null;
        }
    }
}