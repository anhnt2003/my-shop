using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Driving.Ports.Commands
{
    public interface IBaseCommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, ICommandReponse<TResponse>>
        where TCommand : IBaseCommand<TResponse>
        where TResponse : class
    {
    }
}
