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
    public class MovementsRepository : EfGenericRepository<Movement>, MovementsDal
    {
        public void CreateExitTime(int id)
        {
            using (AppDbContext c = new AppDbContext())
            {
                if (c.Movements.Count() > 0)
                {
                    var movement = c.Movements.Where(x => x.UserId == id).OrderByDescending(x => x.Id).FirstOrDefault();

                    movement.OutTime = DateTime.UtcNow;
                    movement.UserId = id;
                    movement.InTime = movement.InTime;

                    c.Movements.Update(movement);
                    c.SaveChanges();
                }
                else
                {
                    var movement = c.Movements.Where(x => x.UserId == id).FirstOrDefault();

                    movement.OutTime = Convert.ToDateTime(DateTime.Now);
                    movement.UserId = id;
                    movement.InTime = movement.InTime;

                    c.Movements.Update(movement);
                    c.SaveChanges();
                }

                
            }
        }

        public void CreateMovements(CreateMovementsDto dto)
        {
           using(AppDbContext c = new AppDbContext())
            {
                Movement mov = new Movement
                {
                    InTime = dto.InTime,
                    OutTime = null,
                    UserId = dto.UserId
                };
                c.Movements.Add(mov);
                c.SaveChanges();
            }
        }

        public List<Movement> GetUserMovementsTime(int userId)
        {
            using (AppDbContext c = new AppDbContext())
            {
                var movements = c.Movements.Where(x=>x.UserId==userId).ToList();
                return movements;
            }
        }
    }
}
