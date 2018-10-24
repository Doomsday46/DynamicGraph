using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DynamicGraphic.App_Data;
using DynamicGraphic.Models;

namespace DynamicGraphic.Mappers.implements
{
    public class MeasurementMapper : IMapper
    {
        static MeasurementMapper()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<DateTime, string>().ConvertUsing(new DateTimeTypeConverter());
                cfg.CreateMap<Measurement, MeasurementView>();
            });
            Mapper.AssertConfigurationIsValid();
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }
    }
    public class DateTimeTypeConverter : ITypeConverter<DateTime, String>
    {
        private const String PATTERN_DATETIME = "yyyy.MM.dd HH:mm:ss";
        public String Convert(DateTime measurement, String measurementView, ResolutionContext context)
        {
            return measurement.ToString(PATTERN_DATETIME);
        }
    }

}