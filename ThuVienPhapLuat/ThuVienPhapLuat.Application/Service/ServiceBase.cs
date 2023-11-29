using DataAccessLayer.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuVienPhapLuat.Application.Helper;

namespace ThuVienPhapLuat.Application.Service
{
    public class ServiceBase
    {
        private readonly thuVienPhapLuatDBContext _context;
        public static string connectionString;
        public ServiceBase(thuVienPhapLuatDBContext context)
        {
            _context = context;
            connectionString = _context.Database.GetDbConnection().ConnectionString;
        }
        //protected static SqlConnection GetConnection()
        //{
        //    return SqlHelper.GetConnection(connectionString);
        //}
    }
}
