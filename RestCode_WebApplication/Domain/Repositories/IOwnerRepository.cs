using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestCode_WebApplication.Domain.Models;

namespace RestCode_WebApplication.Domain.Repositories
{
    public interface IOwnerRepository
    {
        Task<IEnumerable<Owner>> ListAsync();
        Task AddAsync(Owner owner);
        Task<Owner> FindById(int id);
        void Update(Owner owner);
        void Remove(Owner owner);
    }
}
