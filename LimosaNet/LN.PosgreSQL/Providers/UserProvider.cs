using LN.Contracts.DataProviders;
using LN.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LN.PosgreSQL.Providers
{
    public class UserProvider : BaseProvider, IUserProvider
    {
        public UserProvider(LimosaNetDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> DeleteUser(int id)
        {
            var entity = await GetUserById(id);
            DBContext.Users.Remove(entity);
            return await DBContext.SaveChangesAsync();
        }

        public async Task<UserEntity> GetUserByEmail(string email)
        {
            var entity = await DBContext.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
            if (entity == null) throw new Exception("Нет такой сущности");
            return entity;
        }


        /// <inheritdoc/>
        public async Task<UserEntity> GetUserById(int id)
        {
            var entity = await DBContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (entity == null) throw new Exception("Нет такой сущности");
            return entity;
        }

        /// <inheritdoc/>
        public async Task<List<UserEntity>> GetUsers()
        {
            return await DBContext.Users.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<int> RegisterUser(UserEntity user)
        {
            await DBContext.Users.AddAsync(user);
            return await DBContext.SaveChangesAsync();
        }
    }
}
