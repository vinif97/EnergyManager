﻿using AutoMapper;
using EnergyManager.Application.Dtos;
using EnergyManager.Application.Dtos.Response;
using EnergyManager.Application.Helper;
using EnergyManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnergyManager.Application.Profiles
{
    public class DomainToDtoProfile : Profile
    {
        public DomainToDtoProfile()
        {
            CreateMap<EndpointDto, Endpoint>()
                .ForPath(member => member.Meter.ModelId, opt => opt
                    .MapFrom(value => EndpointDictionary.endpoints.ContainsKey(value.SerialNumber) ? EndpointDictionary.endpoints[value.SerialNumber] : value.Meter.ModelId))
                .ForPath(member => member.Meter.Number, opt => opt
                    .MapFrom(value => value.Meter.Number))
                .ForPath(member => member.Meter.FirmwareVersion, opt => opt
                    .MapFrom(value => value.Meter.FirmwareVersion));
                    
            CreateMap<Endpoint, EndpointDtoResponse>();
            CreateMap<EndpointUpdateDto, Endpoint>()
                .ForPath(member => member.Meter.ModelId, opt => opt
                    .MapFrom(value => EndpointDictionary.endpoints.ContainsKey(value.SerialNumber) ? EndpointDictionary.endpoints[value.SerialNumber] : value.Meter.ModelId))
                .ForPath(member => member.Meter.Number, opt => opt
                    .MapFrom(value => value.Meter.Number))
                .ForPath(member => member.Meter.FirmwareVersion, opt => opt
                    .MapFrom(value => value.Meter.FirmwareVersion));
            CreateMap<Endpoint, EndpointDto>();

            CreateMap<MeterDto, Meter>().ReverseMap();
        }
    }
}
