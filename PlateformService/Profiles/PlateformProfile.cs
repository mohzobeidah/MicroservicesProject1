using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PlateformService.Dtos;
using PlateformService.Models;

namespace PlateformService.Profiles
{
    public class PlateformProfile:Profile
    {
        public PlateformProfile()
        {
            // sourse -> target 
            CreateMap<Plateform,PlateformReadDtos>().ReverseMap();
            CreateMap<Plateform,PlateformCreateDtos>();

        }
    }
}