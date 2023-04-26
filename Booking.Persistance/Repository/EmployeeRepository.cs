using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.BusinessLogic.Repository;
using Booking.Domain.Entities;
using Booking.Persistance.Context;

namespace Booking.Persistance.Repository
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAll()
        {
            var test = await _context.Employees
                .Include(e => e.Services)
                .ToListAsync();

            return test;
        }

        public async Task<Employee> GetById(Guid id)
        {
            var employee = await _context.Employees
                .Include(e => e.Services)
                .FirstOrDefaultAsync(e => e.Id == id);

            return employee;
        }

        public void Add(Employee item)
        {
            _context.Employees.Add(item);
        }

        public void Delete(Employee item)
        {
            var employee = _context.Employees.Find(item.Id);

            if (employee != null)
                _context.Employees.Remove(employee);
        }

        public void Update(Employee item)
        {
            var employee = _context.Employees.Find(item.Id);

            if (employee != null)
            { 
                employee.FirstName = item.FirstName;
                employee.LastName = item.LastName;
                employee.Username = item.Username;
                employee.Password = item.Password;
                employee.Services = item.Services;
                employee.BarbershopId = item.BarbershopId;
                _context.SaveChanges();
            }
        }
    }
}
