using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class prodSpecificationparams
    {
        private const int MaxpageSize=50;
        public int pageIndex{ get; set; }=1;
        private int _pageSize=6;

        public int PageSize
        {
            get =>_pageSize;
            set => _pageSize=(value>MaxpageSize ? MaxpageSize : value);
        } 

        public int? brandId { get; set; }
        public int? typeId{ get; set; }

        public string sort { get; set; }
        public string brands { get; set; }
        public string types { get; set; }

        private string _Search;
        public string Search
        {
            get => (_Search ?? "").ToLower();
            set => _Search = value.ToLower();
        }

    }
}