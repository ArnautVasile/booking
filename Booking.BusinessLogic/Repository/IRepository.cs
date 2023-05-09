using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.BusinessLogic.Repository
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
        void Add(T item);
        void Update(T item);
        void Delete(Guid id);
    }
}
