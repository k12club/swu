using System;
using System.Globalization;

namespace Swu.Portal.Core
{
    /// <summary>
    /// Constains static methods for representing program contracts such as preconditions, postconditions, and object invariants.
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the given argument is null.
        /// </summary>
        /// <param name="argumentValue">The argument value.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static void ArgumentNotNull(object argumentValue, string argumentName)
        {
            if (argumentValue == null) throw new ArgumentNullException(argumentName);
        }

        /// <summary>
        /// Throws an exception if the tested string argument is null or the empty string.
        /// </summary>
        /// <param name="argumentValue">The argument value.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException">Argument must not be empty</exception>
        public static void ArgumentNotNullOrEmpty(string argumentValue, string argumentName)
        {
            if (argumentValue == null) throw new ArgumentNullException(argumentName);
            if (argumentValue.Length == 0) throw new ArgumentException("Argument must not be empty", argumentName);
        }

        /// <summary>
        /// Verifies that an argument type is assignable from the provided type (meaning
        /// interfaces are implemented, or classes exist in the base class hierarchy).
        /// </summary>
        /// <param name="assignmentTargetType">Type of the assignment target.</param>
        /// <param name="assignmentValueType">Type of the assignment value.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <exception cref="System.ArgumentNullException">assignmentTargetType</exception>
        /// <exception cref="System.ArgumentException"></exception>
        public static void TypeIsAssignable(Type assignmentTargetType, Type assignmentValueType, string argumentName)
        {
            if (assignmentTargetType == null) throw new ArgumentNullException("assignmentTargetType");
            if (assignmentValueType == null) throw new ArgumentNullException("assignmentValueType");

            if (!assignmentTargetType.IsAssignableFrom(assignmentValueType))
            {
                throw new ArgumentException(string.Format(
                    CultureInfo.CurrentCulture,
                    "The type {1} cannot be assigned to variables of type {0}.",
                    assignmentTargetType,
                    assignmentValueType),
                    argumentName);
            }
        }

        /// <summary>
        /// Verifies that an argument instance is assignable from the provided type (meaning
        /// interfaces are implemented, or classes exist in the base class hierarchy, or instance can be 
        /// assigned through a runtime wrapper, as is the case for COM Objects).
        /// </summary>
        /// <param name="assignmentTargetType">Type of the assignment target.</param>
        /// <param name="assignmentInstance">The assignment instance.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <exception cref="System.ArgumentNullException">assignmentTargetType</exception>
        /// <exception cref="System.ArgumentException"></exception>
        public static void InstanceIsAssignable(Type assignmentTargetType, object assignmentInstance,
                                                string argumentName)
        {
            if (assignmentTargetType == null) throw new ArgumentNullException("assignmentTargetType");
            if (assignmentInstance == null) throw new ArgumentNullException("assignmentInstance");

            if (!assignmentTargetType.IsInstanceOfType(assignmentInstance))
            {
                throw new ArgumentException(
                   string.Format(
                       CultureInfo.CurrentCulture,
                       "The type {1} cannot be assigned to variables of type {0}.",
                       assignmentTargetType,
                       GetTypeName(assignmentInstance)),
                   argumentName);
            }
        }

        private static string GetTypeName(object assignmentInstance)
        {
            string assignmentInstanceType;
            try
            {
                assignmentInstanceType = assignmentInstance.GetType().FullName;
            }
            catch (System.Exception)
            {
                assignmentInstanceType = "Unknown type";
            }
            return assignmentInstanceType;
        }
    }
}
