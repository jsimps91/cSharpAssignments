using dojoLeague.Models;
using System.Collections.Generic;
namespace dojoLeague.Factory
{
    public interface IFactory<T> where  T : BaseEntity{}
}