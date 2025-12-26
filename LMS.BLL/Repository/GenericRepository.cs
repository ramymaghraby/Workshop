using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.BLL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
    }

    public interface IGenericRepository<T> where T : class, new()
    {
    }
}
