
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HotChocolate.Types;

using static O8Query.Models.StatementAnalyte;

namespace Harpoon
{
    // Adapted from: https://github.com/graphql-dotnet/graphql-dotnet/issues/1666
    public static class EnumExtensions
    {
        // Adapted from: https://stackoverflow.com/questions/53636974/c-sharp-method-to-combine-a-generic-list-of-enum-values-to-a-single-value/53637933#53637933
        public static T ToCombined<T>(this IEnumerable<T> list) where T : struct, Enum
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

    public class AssayEnumType : EnumType<Assay> { }
}