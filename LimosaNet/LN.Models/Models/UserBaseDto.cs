using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN.Contracts.Models
{
    public class UserBaseDto
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Фамилия
        /// </summary>
        public string SecondName { get; set; } = string.Empty;

        /// <summary>
        /// Возраст
        /// </summary>
        public int Old { get; set; } = 0;

        /// <summary>
        /// Город
        /// </summary>
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Интересы
        /// </summary>
        public string Hobbies { get; set; } = string.Empty;

        /// <summary>
        /// Почтовый ящик - обязательный к заполнению
        /// </summary>
        public string Email { get; set; } = string.Empty;
    }
}
