using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.BusinessLogic.Repository
{
    public interface IBarbershopRepository: IRepository<Barbershop>
    {
        void AddEmployee(Guid barbershop, Employee employee);
        void AddService(Guid barbershop, Service service);

        Task RmEmployee(Guid barbershop, Employee employee);
        void RmService(Guid barbershop, Service service);
    }
}
