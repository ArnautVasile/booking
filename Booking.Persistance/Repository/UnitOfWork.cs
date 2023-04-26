using Booking.BusinessLogic.Repository;
using Booking.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.Persistance.Repository;

namespace Booking.Persistance.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DataContext _context;

        public IEmployeeRepository EmployeeRepository  { get; set; }
        public IBarbershopRepository BarbershopRepository  { get; set; }
        public IServiceRepository ServiceRepository  { get; set; }

        public UnitOfWork(DataContext context)
        {
            _context = context;

            EmployeeRepository = new EmployeeRepository(context);
            BarbershopRepository = new BarbershopRepository(context);
            ServiceRepository = new ServiceRepository(context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
