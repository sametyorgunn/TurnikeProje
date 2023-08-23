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
    public class MovementsRepository : EfGenericRepository<Movement>, IMovementsDal
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

                    movement.OutTime = DateTime.UtcNow;
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

        public List<Movement> GetUserMovementsFilter(int userId, DateTime EnterDate, DateTime ExitDate)
        {
           using(AppDbContext c = new AppDbContext())
            {
                //ExitDate = ExitDate == Convert.ToDateTime("1.01.0001 00:00:00") ? Convert.ToDateTime("2029 - 08 - 23 23:21:25.961 + 0300") : ExitDate;
                if (userId == null)
                {
                    var allmovementsFilterDate = c.Movements.Where(x => x.InTime > EnterDate && x.OutTime < ExitDate).ToList();
                    return allmovementsFilterDate;
                }
                else if (EnterDate == Convert.ToDateTime("1.01.0001 00:00:00"))
                {
                    var movementsOutOfEnterdate = c.Movements.Where(x => x.UserId == userId && x.OutTime < ExitDate).ToList();
                    return movementsOutOfEnterdate;
                }
                else if (ExitDate == Convert.ToDateTime("1.01.0001 00:00:00"))
                {
                    var movementsOutOfExitdate = c.Movements.Where(x => x.UserId == userId && x.InTime > EnterDate).ToList();
                    return movementsOutOfExitdate;
                }
                else
                {
                    var movements = c.Movements.Where(x => x.UserId == userId && x.InTime > EnterDate && x.OutTime < ExitDate).ToList();
                    return movements;
                }
                
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

        public GetUserOneDayMovementsDto TGetUserOneDayMovements(int userId)
        {
            using(var c = new AppDbContext())
            {
                var usergiris = c.Movements.Where(x => x.UserId == userId).FirstOrDefault();
                var usercikis = c.Movements.Where(x=>x.UserId==userId).OrderByDescending(x=>x.Id).FirstOrDefault();
                var giris = usergiris.InTime;
                var cikis = usercikis.OutTime;

                TimeSpan? time = cikis - giris;
                GetUserOneDayMovementsDto a = new()
                {
                    InTime = giris,
                    OutTime = cikis,
                    UserId = userId,
                    OutInDifference = time
                };
                return a;
            }
        }
    }
}
