using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.BusinessLogic.Repository
{
    public interface IBaseUserEntity : IRepository<BaseUserEntity>
    {
        Task<BaseUserEntity> FindByUserName(string username);
    }
}
