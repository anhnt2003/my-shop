using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Driving.Ports.Commands
{
    public abstract class BaseCommandHandler<TCommand, TResponse> : IBaseCommandHandler<TCommand, TResponse>
        where TCommand : IBaseCommand<TResponse>
        where TResponse : class
    {
        public abstract Task<ICommandReponse<TResponse>> Handle(TCommand request, CancellationToken cancellationToken);
    }
}
