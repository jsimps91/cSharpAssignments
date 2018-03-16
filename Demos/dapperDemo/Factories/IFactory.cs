using dapperDemo.Models;
using System.Collections.Generic;
namespace dapperDemo.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}