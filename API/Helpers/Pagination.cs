namespace API.Helpers
{
    public class Pagination<T> where T : class
    {

        public Pagination(int pageIndex, int pageSize, int count,IReadOnlyList<T> data)
        {
            this.pageIndex = pageIndex;
            this.Count = count;
            this.pageSize = pageSize;
            this.Data = data;

        }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}