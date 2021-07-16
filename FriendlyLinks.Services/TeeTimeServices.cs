using FriendlyLinks.Data;
using FriendlyLinks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyLinks.Services
{
    public class TeeTimeServices
    {
        private readonly Guid _teeTimeId;
        public TeeTimeServices()
        {
            //  _teeTimeId = teeTimeId;
        }
        public bool CreateTeeTime(TeeTimeCreate model)
        {
            var entity =
                new TeeTime()
                {
                    TeeTimeId = _teeTimeId,
                    CourseName = model.CourseName,
                    CourseCity = model.CourseCity,
                    CoursePrice = model.CoursePrice,
                    TeeOffTime = model.TeeOffTime
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
                        .Where(e => e.TeeTimeId == _teeTimeId)
                        .Select(
                            e =>
                                new TeeTimeListItem
                                {
                                    TeeTimeId = e.TeeTimeId,
                                    IsStarred = e.IsStarred,
                                    CourseName = e.CourseName,
                                    CourseCity = e.CourseCity,
                                    CoursePrice = e.CoursePrice
                                }
                        );

                return query.ToArray();

            }

        }
        public TeeTimeDetail GetTeeTimeById(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TeeTime
                        .Single(e => e.TeeTimeId == id && e.TeeTimeId == _teeTimeId);
                return
                    new TeeTimeDetail
                    {
                        TeeTimeId = entity.TeeTimeId,
                        CourseName = entity.CourseName,
                        CourseCity = entity.CourseCity,
                        CoursePrice = entity.CoursePrice

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
                        .Single(e => e.TeeTimeId == model.TeeTimeId && e.TeeTimeId == _teeTimeId);

                entity.CourseName = model.CourseName;
                entity.CourseCity = model.CourseCity;
                entity.CoursePrice = model.CoursePrice;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool TeeTimeDelete(Guid teeTimeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TeeTime
                        .Single(e => e.TeeTimeId == teeTimeId && e.TeeTimeId == _teeTimeId);

                ctx.TeeTime.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

