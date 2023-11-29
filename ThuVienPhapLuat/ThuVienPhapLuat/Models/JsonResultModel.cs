namespace ThuVienPhapLuat.Models
{
    public class JsonResultModel<T> where T : class
    {
        public string ExceptionMessage { get; set; }

        public IList<string> ValidateMessage { get; set; }

        public bool Success { get; set; }
        public int TotalRows { get; set; }

        public T Data { get; set; }

    }
}
