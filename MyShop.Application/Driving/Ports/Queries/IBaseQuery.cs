using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Driving.Ports.Queries
{
    public interface IBaseQuery<TResult> : IRequest<IQueryResult<TResult>>
        where TResult : class
    {
    }
}
