using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThuVienPhapLuat.Utilities.Models
{
    public class SearchResult<T> where T : class
    {
        public int TotalRows { get; set; }
        public T Data { get; set; }
        public bool Success { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
    }

    public class PostResult<T> where T : class
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
    }
}
