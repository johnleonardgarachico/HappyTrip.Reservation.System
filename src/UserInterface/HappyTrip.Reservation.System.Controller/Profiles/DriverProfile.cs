using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HappyTrip.Reservation.System.Controller.Helpers;
using HappyTrip.Reservation.System.Domain.Data.Models;
using HappyTrip.Reservation.System.Domain.Data.Entities;

namespace HappyTrip.Reservation.System.Controller.Profiles
{
    public class DriverProfile : Profile
    {
        public DriverProfile()
        {
            CreateMap<Driver, DriverDto>()
                .ForMember(domain => domain.Name, data => data.MapFrom(src => string.Format("{0} {1}", src.FirstName, src.LastName)))
                .ForMember(domain => domain.Age, data => data.MapFrom(src => src.BirthDate.GetCurrentAge()));
            CreateMap<Driver, DriverForUpdateDto>();

            CreateMap<DriverForCreation, Driver>();
            CreateMap<DriverForUpdateDto, Driver>();

        }
    }
}
