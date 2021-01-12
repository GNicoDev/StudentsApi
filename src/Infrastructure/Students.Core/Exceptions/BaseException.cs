using System;

namespace GNDSoft.Students.Infrastructure.Students.Core.Exceptions
{
    /// <summary>
    /// Базовый класс исключения с кодом исключения
    /// </summary>
    public class BaseException: Exception
    {
        /// <summary>
        /// Пользовательский код ошибки
        /// </summary>
        public virtual string ErrorCode { get; } = "default_error";

        /// <summary>
        /// Базовый конструктор
        /// </summary>
        public BaseException()
        {}
        /// <summary>
        /// Конструктор с сообщением об ошибке
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        public BaseException(string message): base(message: message)
        {}
        /// <summary>
        /// Конструктор с сообщением об ошибке и кодом
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        /// <param name="errorCode">Код ошибки</param>
        public BaseException(string message, string errorCode):base (message: message)
        {ErrorCode = errorCode;}
        /// <summary>
        /// Конструктор с сообщением об ошибке и кодом
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        /// <param name="errorCode">Код ошибки</param>
        /// <param name="innerException">Внутренняя ошибка</param>
        public BaseException(string message, string errorCode, Exception innerException): base(message: message, innerException: innerException)
        {ErrorCode = errorCode;}
    }
}