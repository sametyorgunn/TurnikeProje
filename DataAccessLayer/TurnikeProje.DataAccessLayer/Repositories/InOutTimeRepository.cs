using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TurnikeProje.DataAccessLayer.Abstract;
using TurnikeProje.DataAccessLayer.Contexts;
using TurnikeProje.DataAccessLayer.Repositories.GenericRepositorie;
using TurnikeProje.EntityLayer.Dtos;
using TurnikeProje.EntityLayer.Entities;

namespace TurnikeProje.DataAccessLayer.Repositories
{
    public class InOutTimeRepository : EfGenericRepository<InOutTime>, IInOutTimeDal
    {

        public void CreateMovements(CreateMovementsDto dto)
        {
            using(var c = new AppDbContext())
            {
                var user = c.Users.Where(x=>x.UserName == dto.UserName && x.Password == dto.Password).FirstOrDefault();
                if(user !=null)
                {
                    InOutTime time = new InOutTime
                    {
                        InTime = DateTime.UtcNow,
                        OutTime = null,
                        UserId = user.Id
                    };
                    c.InOutTimes.Add(time);
                    c.SaveChanges();
                }
                
            }
        }

        public List<InOutTime> GetUserInOutTime(int userId)
        {
            using(var c = new AppDbContext())
            {
                var giriscikis = c.InOutTimes.Where(x => x.UserId == userId).ToList();
                return giriscikis;
            }
        }

        public void TAddExitTime(int id)
        {
            using (var c = new AppDbContext())
            {

                var inout = c.InOutTimes.Where(x => x.UserId == id).FirstOrDefault();
                var ids = inout.Id;
                if (inout != null)
                {
                    InOutTime times = new InOutTime
                    {
                        Id = ids,
                        InTime = inout.InTime,
                        OutTime = DateTime.UtcNow,
                        UserId = id
                        
                    };
                    c.InOutTimes.Update(times);
                    c.SaveChanges();
                }

            }
        }
    }
}
