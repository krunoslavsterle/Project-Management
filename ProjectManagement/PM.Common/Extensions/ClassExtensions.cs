using System;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace PM.Common.Extensions
{
    /// <summary>
    /// Class extensions.
    /// </summary>
    public static class ClassExtensions
    {
        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        /// <typeparam name="T">Class.</typeparam>
        /// <typeparam name="TProp">The type of the property.</typeparam>
        /// <param name="obj">The object.</param>
        /// <param name="propertySelector">The property selector.</param>
        /// <returns>The name of the property.</returns>
        public static string PropertyName<T, TProp>(this T obj, Expression<Func<T, TProp>> propertySelector)
        {
            MemberExpression body = (MemberExpression)propertySelector.Body;
            return body.Member.Name;
        }

        /// <summary>
        /// To navigation property string. example: [User.UserRoles.Role].
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="properties">The properties.</param>
        /// <returns>The navigation property string. example: [User.UserRoles.Role].</returns>
        public static string ToNavPropertyString<T>(this T obj, params string[] properties)
        {
            StringBuilder sBuilder = new StringBuilder();
            if (properties != null)
            {
                int count = properties.Count();
                for (int i = 0; i < count; i++)
                {
                    sBuilder.Append(properties[i]);
                    if (i + 1 < count)
                        sBuilder.Append(".");
                }
            }
            return sBuilder.ToString();
        }
    }
}
