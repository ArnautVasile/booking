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
    class BarbershopRepository: IBarbershopRepository
    {
        private readonly DataContext _context;

        public BarbershopRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Barbershop>> GetAll()
        {
            var test = await _context.Barbershops
                .Include(b => b.Services)
                .Include(e => e.Employees)
                .ToListAsync();

            return test;
        }
        public async Task<Barbershop> GetById(Guid id)
        {
            var barbershop = await _context.Barbershops
                .Include(b => b.Services)
                .Include(e => e.Employees)
                .FirstOrDefaultAsync(e => e.Id == id);

            return barbershop;
        }

        public void Add(Barbershop item)
        {
            _context.Barbershops.Add(item);
        }

        public void Update(Barbershop item)
        {
            var barbershop = _context.Barbershops.Find(item.Id);

            if (barbershop != null)
            {
                barbershop.Name = item.Name;
                barbershop.Address = item.Address;
                barbershop.Services = item.Services;
                barbershop.Employees = item.Employees;
                _context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            var barbershop = _context.Barbershops.Find(id);

            if (barbershop != null)
                _context.Barbershops.Remove(barbershop);
        }

        public void AddEmployee(Guid barbershopId, Employee employee)
        {
            var result = _context.Barbershops.Find(barbershopId);

            if (result != null)
            {
                if (result.Employees == null)
                    result.Employees = new List<Employee>();
                result.Employees.Add(employee);
                _context.SaveChanges();
            }
        }

        public void AddService(Guid barbershopId, Service service)
        {
            var result = _context.Barbershops.Find(barbershopId);

            if (result != null)
            {
                if (result.Services == null)
                    result.Services = new List<Service>();
                result.Services.Add(service);
                _context.SaveChanges();
            }
        }

        public async Task RmEmployee(Guid barbershopId, Employee employee)
        {
         //   var barbershop = _context.Barbershops.Find(barbershopId);
            var barbershop = await _context.Barbershops
                    .Include(b => b.Employees)
                    .SingleOrDefaultAsync(b => b.Id == barbershopId);

            if (barbershop != null)
                barbershop.Employees.Remove(employee);

            await (_context.SaveChangesAsync());
        }

        public void RmService(Guid serviceId, Service service)
        {
            var barbershop = _context.Barbershops.Find(serviceId);

            if (barbershop != null)
                barbershop.Services.Remove(service);
        }
    }
}
