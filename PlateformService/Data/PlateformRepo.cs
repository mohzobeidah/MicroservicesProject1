using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlateformService.Models;

namespace PlateformService.Data
{
    public class PlateformRepo : IPlateformRepo
    {
        private readonly AppDataContext _context;
        public PlateformRepo(AppDataContext context)
        {
            this._context = context;
            
        }
        public void createPlatefrom(Plateform plateform)
        {
            if(plateform==null)
            throw new ArgumentException(nameof(plateform));

          _context.Add(plateform);
        }

        public Plateform GetAllPlateformById(int id)
        {
         return _context.Plateforms.FirstOrDefault(x=>x.Id==id);
        }

        public IEnumerable<Plateform> GetAllPlateforms()
        {
        return _context.Plateforms;
        }

        public bool SaveChanges()
        {
          return  _context.SaveChanges()>=0;
        }
    }
}