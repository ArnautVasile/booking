
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.BusinessLogic.Repository
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; set; }
        IBarbershopRepository BarbershopRepository { get; set; }
        IServiceRepository ServiceRepository { get; set; }
        void Save();
    }
}
