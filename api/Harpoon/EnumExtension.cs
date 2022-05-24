
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Harpoon {
    public static class EnumExtension {
        public static T ToCombined<T>(this IEnumerable<T> list) where T : Enum
        {
            Type underlyingType = Enum.GetUnderlyingType(typeof(T));

            var currentParameter = Expression.Parameter(typeof(T), "current");
            var nextParameter = Expression.Parameter(typeof(T), "next");

            Func<T, T, T> aggregator = Expression.Lambda<Func<T, T, T>>(
                Expression.Convert(
                    Expression.Or(
                        Expression.Convert(currentParameter, underlyingType),
                        Expression.Convert(nextParameter, underlyingType)
                        ),
                    typeof(T)
                    ),
                currentParameter,
                nextParameter
                ).Compile();

            return list.Aggregate(aggregator);
        }
    }
}