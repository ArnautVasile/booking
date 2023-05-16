using Booking.BusinessLogic.Repository;
using Booking.Domain.Entities;
using Booking.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Persistance.Repository
{
    public class UserAppointmentRepository: IUserAppointmentRepository
    {
        private readonly DataContext _context;

        public UserAppointmentRepository(DataContext context)
        {
            _context = context;
        }

      
        public async Task<List<UserAppointment>> GetAll()
        {
            var test = await _context.UserAppointments
             .ToListAsync();

            return test;
        }
        public void Add(UserAppointment item)
        {
            _context.UserAppointments.Add(item);
        }

        public void Delete(Guid id)
        {
            var appointment = _context.UserAppointments.Find(id);

            if (appointment != null)
                _context.UserAppointments.Remove(appointment);
        }

        public Task<UserAppointment> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserAppointment item)
        {
            throw new NotImplementedException();
        }
    }
}
