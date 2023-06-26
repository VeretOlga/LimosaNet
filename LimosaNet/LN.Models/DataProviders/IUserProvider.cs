using LN.Core.Entities;

namespace LN.Contracts.DataProviders
{
    public interface IUserProvider
    {
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <returns></returns>
        Task<int> RegisterUser(UserEntity user);

        /// <summary>
        /// Получение всех пользователей
        /// </summary>
        /// <returns></returns>
        Task<List<UserEntity>> GetUsers();

        /// <summary>
        /// Получение пользователя по идетификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserEntity> GetUserById(int id);


        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> DeleteUser(int id);


        /// <summary>
        /// Получение пользователя по логину
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<UserEntity> GetUserByEmail(string email);
    }
}
