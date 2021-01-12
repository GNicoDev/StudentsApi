using System;

namespace GNDSoft.Students.Infrastructure.Students.Core.Exceptions
{
    /// <summary>
    /// Исключение вызываемое при работе с объектами студентов
    /// </summary>
    public class StudentException :
        BaseException
    {
        /// <summary>
        /// Код ошибки по умолчанию
        /// </summary>
        public const string DefaultCode = "student_default";

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        public StudentException(string message) : base(message, DefaultCode) { }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        /// <param name="code">Код ошибки</param>
        public StudentException(string message, string code) : base(message, code) { }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        /// <param name="code">Код ошибки</param>
        /// <param name="innerException">Внутренняя ошибка</param>
        public StudentException(string message, string code, Exception innerException) : base(message, code, innerException) { }
    }
}