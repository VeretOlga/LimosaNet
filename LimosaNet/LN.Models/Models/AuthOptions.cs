using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LN.Contracts.Models
{
    /// <summary>
    ///Для настроек генерации токена модель
    /// </summary>
    public  class AuthOptions
    {
        public const string ISSUER = "LimosaNet"; // издатель токена
        public const string AUDIENCE = "LimosaNetClient"; // потребитель токена
        const string KEY = "limosa_net!_2023_need_more_home_work";   // ключ для шифрации
        public static SymmetricSecurityKey GetSymmetricSecurityKey() => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
