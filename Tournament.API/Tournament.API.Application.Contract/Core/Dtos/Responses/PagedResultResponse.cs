using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.API.Application.Contract.Core.Dtos.Responses
{
    public class PagedResultResponse<T>
    {
        public long TotalCount { get; set; }
        private IReadOnlyList<T> _Items;
        public IReadOnlyList<T> Items
        {
            get
            {
                return _Items ?? (_Items = new List<T>());
            }

            set
            {
                _Items = value;
            }
        }
    }
}
