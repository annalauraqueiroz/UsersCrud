using CRUDUsuarios.Data;
using CRUDUsuarios.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.Data;

namespace CRUDUsuarios.Services
{
    public class PersonService
    {
        private readonly DataContext _context;
        public PersonService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<PersonModel>> FindAllAsync()
        {
            return await _context.Person.ToListAsync();
        }
        public async Task<Person> FindByIdAsync(int id)
        {
            return await _context.Person.FirstOrDefaultAsync(obj => obj.PersonId == id);
        }
        public async Task InsertAsync(Person obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Person obj)
        {
            bool hasAny = await _context.Person.AnyAsync(x => x.PersonId == obj.PersonId);
            if (!hasAny)
            {
                throw new Exception("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Person.FindAsync(id);
                _context.Person.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}
