using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Driven.Ports.Mapper
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
