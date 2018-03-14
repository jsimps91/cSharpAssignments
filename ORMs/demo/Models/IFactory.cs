using demo.Models;
using System.Collections.Generic;
namespace DapperApp.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}