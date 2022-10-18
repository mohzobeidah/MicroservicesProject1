using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlateformService.Data;
using PlateformService.Dtos;
using PlateformService.Models;

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
        [HttpGet("{id}", Name="GetPlateformById")]
        public ActionResult<PlateformReadDtos> GetPlateformById(int id)
        {
            var res =_plateformRepo.GetAllPlateformById(id);
            if(res is not null)
            return Ok(_mapper.Map<PlateformReadDtos>(res)) ;
            
            return NotFound();
        }
        [HttpPost]
        public ActionResult<PlateformReadDtos> CreatePlateform(PlateformCreateDtos plateformCreateDtos)
        {
            var res =_mapper.Map<Plateform>(plateformCreateDtos);
             _plateformRepo.createPlatefrom(res);
            _plateformRepo.SaveChanges();
            var returnObj= _mapper.Map<PlateformReadDtos>(res);
            Console.WriteLine(res.Id);
            return CreatedAtRoute(nameof(GetPlateformById),new {id=res.Id},returnObj) ;
           
        }
    }


}