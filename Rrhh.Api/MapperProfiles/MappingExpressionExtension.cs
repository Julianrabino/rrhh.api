﻿using AutoMapper;
using System.Linq;

namespace Rrhh.Api.MapperProfiles
{
    public static class MappingExpressionExtension
    {
        public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>
            (this IMappingExpression<TSource, TDestination> expression)
        {
            var sourceType = typeof(TSource);
            var destinationType = typeof(TDestination);

            var existingMaps = Mapper.Configuration.GetAllTypeMaps().First(x => x.SourceType.Equals(sourceType) && x.DestinationType.Equals(destinationType));

            foreach (var property in existingMaps.GetUnmappedPropertyNames())
                expression.ForMember(property, opt => opt.Ignore());

            return expression;
        }
    }
}
