using FriendlyLinks.Data;
using FriendlyLinks.Models;
using System;
using System.Linq;

namespace FriendlyLinks.Services
{
    public class GolferServices
    {
        public bool CreateGolfer(GolferCreate model)
        {
            var entity =
                new Golfer()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Golfer.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // This is where i need to put the info to show the tee times that a golfer has purchased. This also needs a model build for GolferListOfTeeTimes
        //public IEnumerable<GolferListItem> GetTeeTimes()
        //{
        //  using (var ctx = new ApplicationDbContext())
        //{
        //  var query =
        //    ctx
        //      .TeeTime
        //    .Where(e => e.TeeTimeId == e.TeeTimeId)
        //  .Select(
        //    e =>
        //      new TeeTimeListItem
        //    {
        //      TeeTimeId = e.TeeTimeId,
        //    CoursePrice = e.CoursePrice,
        //  TeeOffTime = e.TeeOffTime,

        //  }
        //  );

        //  return query.ToArray();
        // }
        //  }

        public GolferDetail GetGolferById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Golfer
                        .Single(e => e.GolferId == id);
                return
                    new GolferDetail
                    {
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Email = entity.Email
                    };
            }
        }

        public bool UpdateGolfer(GolferEdit model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Golfer
                        .Single(e => e.GolferId == model.GolferId && e.GolferId == e.GolferId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Email = model.Email;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool GolferDelete(int golferId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Golfer
                        .Single(e => e.GolferId == golferId && e.GolferId == e.GolferId);

                ctx.Golfer.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}