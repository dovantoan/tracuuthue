namespace ThuVienPhapLuat.Models
{
    public class BaseSearchCriteria
    {
        public int PageIndex { get; set; }

        public int RowNumber { get; set; }

        public bool IsDesc { get; set; }

        public string SortName { get; set; }
    }
}
