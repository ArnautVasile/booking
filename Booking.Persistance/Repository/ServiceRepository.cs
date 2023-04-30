using Booking.BusinessLogic.Repository;
using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.Persistance.Context;
using System.Data.Entity;


namespace Booking.Persistance.Repository
{
    public class ServiceRepository: IServiceRepository
    {
        private readonly DataContext _context;

        public ServiceRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Service>> GetAll()
        {
            var test = await _context.Services
                .ToListAsync();

            return test;
        }

        public async Task<Service> GetById(Guid id)
        {
            var service = await _context.Services
                .FirstOrDefaultAsync(e => e.Id == id);

            return service;
        }

        public void Add(Service item)
        {
            _context.Services.Add(item);
        }


        public void Update(Service item)
        {
            var barbershop = _context.Services.Find(item.Id);

            if (barbershop != null)
            {
                barbershop.ServiceName = item.ServiceName;
                barbershop.ServiceType = item.ServiceType;
                _context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            var barbershop = _context.Services.Find(id);

            if (barbershop != null)
                _context.Services.Remove(barbershop);
        }
    }
}
