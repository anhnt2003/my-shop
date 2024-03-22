using MediatR;
using MyShop.Application.Driving.Ports.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Driving.Ports.Queries
{
    public interface IBaseQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, IQueryResult<TResult>>
        where TQuery : IBaseQuery<TResult>
        where TResult : class
    {
    }
}
