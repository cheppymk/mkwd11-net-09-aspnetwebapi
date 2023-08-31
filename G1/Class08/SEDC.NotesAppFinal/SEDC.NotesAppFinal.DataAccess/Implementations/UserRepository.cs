using Microsoft.EntityFrameworkCore;
using SEDC.NotesAppFinal.DataAccess.Interfaces;
using SEDC.NotesAppFinal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.NotesAppFinal.DataAccess.Implementations
{
    public class UserRepository : IRepository<User>
    {
        private readonly NotesDbContext _context;

        public UserRepository(NotesDbContext _context)
        {
            this._context = _context;
        }
        public async Task CreateAsync(User entity)
        {

          _context.Users.Add(entity);
        await  _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            User user = await _context.Users.FindAsync(id);
            
             _context.Users.Remove(user);
             await _context.SaveChangesAsync();  
        
          
        }

        public async Task<List<User>> GetAllAsync()
        {
           return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public Task UpdateAsync(User entity)
        {
            _context.Users.Update(entity);
            return _context.SaveChangesAsync(); 


        }
    }
}
