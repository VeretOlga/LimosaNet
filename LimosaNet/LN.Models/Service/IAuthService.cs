namespace LN.Contracts.Service
{
    public interface IAuthService
    {
        /// <summary>
        /// Получить хэш пароля
        /// </summary>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        string Hash(string password);

        /// <summary>
        /// Verifies that the hash of the given text matches the provided hash
        /// </summary>
        /// <param name="text">The text to verify.</param>
        /// <param name="hash">The previously-hashed password.</param>
        /// <returns></returns>
        bool Verify(string text, string hash);

        /// <summary>
        /// Метод для генерации токена
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        string GenerateToken(string userLogin);
    }
}
