using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlateformService.Models;

namespace PlateformService.Data
{
    public interface IPlateformRepo
    {
        bool SaveChanges() ;
        IEnumerable<Plateform> GetAllPlateforms() ;
        Plateform GetAllPlateformById(int id) ;
        void createPlatefrom(Plateform plateform);

    }
}