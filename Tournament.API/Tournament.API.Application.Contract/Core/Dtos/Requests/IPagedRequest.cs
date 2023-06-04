using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.API.Application.Contract.Core.Dtos.Requests
{
    public interface IPagedRequest
    {
        int SkipCount { get; set; }
        int MaxResultCount { get; set; }
    }
}
