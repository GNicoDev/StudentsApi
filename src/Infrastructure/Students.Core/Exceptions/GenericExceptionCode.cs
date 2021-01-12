namespace GNDSoft.Students.Infrastructure.Students.Core.Exceptions
{
    /// <summary>
    /// Базовые коды ошибок
    /// </summary>
    public static class GenericExceptionCode<TEntry>
        where TEntry: class
    {
        /// <summary>
        /// Объект TEntry не найден
        /// </summary>
        public static string NotFound => $"{nameof(TEntry).ToLower()}_not_found_error";
        /// <summary>
        /// Ошибка при создании TEntry
        /// </summary>
        public static string Create => $"create_{nameof(TEntry).ToLower()}_error";
        /// <summary>
        /// Ошибка при удалении TEntry
        /// </summary>
        public static string Update => $"update_{nameof(TEntry).ToLower()}_error";
        /// <summary>
        /// Ошибка при обновлении TEntry
        /// </summary>
        public static string Delete => $"delete_{nameof(TEntry).ToLower()}_error";
    }
}