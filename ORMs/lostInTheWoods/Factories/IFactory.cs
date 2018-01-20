using lostInTheWoods.Models;
using System.Collections.Generic;
namespace lostInTheWoods.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}