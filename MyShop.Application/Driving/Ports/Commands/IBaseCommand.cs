using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Driving.Ports.Commands
{
    public interface IBaseCommand<TResponse> : IRequest<ICommandReponse<TResponse>>
        where TResponse : class
    {}
}
