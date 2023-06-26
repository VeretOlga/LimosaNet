namespace LN.Core.Entities
{
    /// <summary>
    /// Упрощенная сущность пользователя
    /// </summary>
    public  class UserEntity
    {
        /// <summary>
        /// Уникальный идентификатор сущности
        /// </summary>
        public int Id { get; set; }
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
        /// Почтовый ящик
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        ///Hash пароль
        /// </summary>
        public string HashPassword { get; set; } = string.Empty;

    }
}
