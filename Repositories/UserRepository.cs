using API.Data;
using API.Entities;

namespace API.Repositories
{
    public class UserRepository
    {
        private readonly UserDataContext _context;

        public UserRepository(UserDataContext context)
        {
            _context = context;
        }

        public async Task<UserEntity> CreateEntity(UserEntity userEntity)
        {
            await _context.AddAsync(userEntity);
            await _context.SaveChangesAsync();

            return userEntity;
        }

        public async Task<UserEntity> GetByIdEntity(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<UserEntity> UpdateEntity(UserEntity userEntity)
        {
            _context.Users.Update(userEntity);
            await _context.SaveChangesAsync();

            return userEntity;
        }

        public async Task<UserEntity> DeleteEntity(UserEntity userEntity)
        {
            _context.Users.Remove(userEntity);
            await _context.SaveChangesAsync();

            return userEntity;
        }


    }
}
