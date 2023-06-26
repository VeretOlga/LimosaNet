namespace LN.Contracts.Models
{
    /// <summary>
    /// Модель, описывающая пользоватяля
    /// </summary>
    public class UserCreateDto: UserBaseDto
    {              
        /// <summary>
        /// пароль
        /// </summary>
        public string Password { get;set; } = string.Empty;
    }
}
