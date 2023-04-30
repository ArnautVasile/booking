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

        public void Add(UserAppointment item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserAppointment>> GetAll()
        {
            var test = await _context.UserAppointments
             .ToListAsync();

            return test;
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
