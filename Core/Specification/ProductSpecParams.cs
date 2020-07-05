namespace Core.Specification
{
    public class ProductSpecParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;
        private int _pageSize = 6;
        public int pageSize
        {
            get => _pageSize;
            set => _pageSize = (value > pageSize) ? pageSize : value;
        }
        public int? brandId { get; set; }
        public int? typeId { get; set; }
        public string Sort { get; set; }
        private string _search;
        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}