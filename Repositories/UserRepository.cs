using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class UserRepository
    {
        private readonly UserDataContext _context;

        public UserRepository(UserDataContext context)
        {
            _context = context;
        }        

        public async Task<List<UserEntity>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();

        }

        public async Task<UserEntity> GetByIdEntity(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<UserEntity> CreateEntity(UserEntity userEntity)
        {
            await _context.AddAsync(userEntity);
            await _context.SaveChangesAsync();

            return userEntity;
        }

        public async Task<UserEntity> UpdateEntity(UserEntity userEntity)
        {
            var existingUser = await _context.Users.FindAsync(userEntity.Id);
            if (existingUser == null)
            {
                return null;
            }

            _context.Users.Update(userEntity);
            
            await _context.SaveChangesAsync();

            return userEntity;
        }

        public async Task<UserEntity> DeleteEntity(UserEntity userEntity)
        {
            var existingUser = await _context.Users.FindAsync(userEntity.Id);
            if (existingUser == null)
            {
                return null;
            }

            _context.Users.Remove(userEntity);
            await _context.SaveChangesAsync();

            return userEntity;
        }


    }
}
