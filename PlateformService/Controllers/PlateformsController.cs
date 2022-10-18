using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlateformService.Data;
using PlateformService.Dtos;

namespace PlateformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlateformsController:ControllerBase
    {
        private readonly IPlateformRepo _plateformRepo;
        private readonly IMapper _mapper;

        public PlateformsController(IPlateformRepo plateformRepo ,IMapper mapper )
        {
            this._plateformRepo = plateformRepo;
            this._mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlateformReadDtos>> GetAllPlateforms()
        {
            var res =_plateformRepo.GetAllPlateforms();
            Console.WriteLine(res.Count());
            return Ok(_mapper.Map<IEnumerable<PlateformReadDtos>>(res)) ;
        }
    }


}