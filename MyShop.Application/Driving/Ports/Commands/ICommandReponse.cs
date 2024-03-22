using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Driving.Ports.Commands
{
    public interface ICommandReponse<TData>
        where TData : class
    {
        bool IsSuccess { get; }

        List<string> Errors { get; }

        TData? Data { get; }
    }
}
