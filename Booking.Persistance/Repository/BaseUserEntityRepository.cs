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
    class BaseUserEntityRepository : IBaseUserEntity
    {

        private readonly DataContext _context;

        public BaseUserEntityRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(BaseUserEntity item)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseUserEntity> FindByUserName(string username)
        {
            return await _context.BaseUserEntities.FirstOrDefaultAsync(b => b.Username == username);
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BaseUserEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BaseUserEntity> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(BaseUserEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
