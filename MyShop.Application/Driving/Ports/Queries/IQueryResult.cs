using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Driving.Ports.Queries
{
    public interface IQueryResult<TData>
        where TData : class
    {
        bool IsSuccess { get; }

        List<string> Errors { get; }

        TData? Data { get; }
    }
}
