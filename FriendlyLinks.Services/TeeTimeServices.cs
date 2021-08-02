using FriendlyLinks.Data;
using FriendlyLinks.Models;
using System.Collections.Generic;
using System.Linq;

namespace FriendlyLinks.Services
{
    public class TeeTimeServices
    {
        public bool CreateTeeTime(TeeTimeCreate model)
        {
            var entity =
                new TeeTime()
                {
                    TeeTimeId = model.TeeTimeId,
                    CoursePrice = model.CoursePrice,
                    TeeOffTime = model.TeeOffTime,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.TeeTime.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TeeTimeListItem> GetTeeTimes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .TeeTime
                        .Where(e => e.TeeTimeId == e.TeeTimeId)
                        .Select(
                            e =>
                                new TeeTimeListItem
                                {
                                    TeeTimeId = e.TeeTimeId,
                                    CoursePrice = e.CoursePrice,
                                    TeeOffTime = e.TeeOffTime,
                                }
                        );

                return query.ToArray();
            }
        }

        public TeeTimeDetail GetTeeTimeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TeeTime
                        .Single(e => e.TeeTimeId == id && e.TeeTimeId == e.TeeTimeId);
                return
                    new TeeTimeDetail
                    {
                        TeeTimeId = entity.TeeTimeId,
                        CoursePrice = entity.CoursePrice,
                        TeeOffTime = entity.TeeOffTime,
                    };
            }
        }

        public bool UpdateTeeTime(TeeTimeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TeeTime
                        .Single(e => e.TeeTimeId == model.TeeTimeId && e.TeeTimeId == e.TeeTimeId);

                entity.TeeOffTime = model.TeeOffTime;
                entity.CoursePrice = model.CoursePrice;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool TeeTimeDelete(int teeTimeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TeeTime
                        .Single(e => e.TeeTimeId == teeTimeId && e.TeeTimeId == e.TeeTimeId);

                ctx.TeeTime.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}