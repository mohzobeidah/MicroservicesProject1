using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlateformService.Dtos;

namespace PlateformService.SyncDataServices.Http
{
    public interface ICommandDataCleint
    {
        Task SendPlateformToCommand(PlateformReadDtos  plateformReadDtos);
        


    }
}