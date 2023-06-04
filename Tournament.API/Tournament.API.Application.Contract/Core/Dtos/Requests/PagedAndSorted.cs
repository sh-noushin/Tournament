using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.API.Application.Contract.Core.Dtos.Requests
{
    public class PagedAndSorted : IPagedRequest, ISortedRequest
    {
        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }
        [Range(0, int.MaxValue)]
        public int MaxResultCount { get; set; } = 10;
        public string Sorting { get; set; } = "";
    }
}
