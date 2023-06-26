namespace LN.Contracts.Models
{
    /// <summary>
    /// Модель для логина
    /// </summary>
    public  class LoginDto
    {
        /// <summary>
        /// Логин- емайл
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
    }
}
