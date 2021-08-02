using FriendlyLinks.Data;
using FriendlyLinks.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FriendlyLinks.Services
{
    public class GolfCourseServices
    {
        private readonly Guid _userId;

        public GolfCourseServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateGolfCourse(GolfCourseCreate model)
        {
            var entity =
                new GolfCourse()
                {
                    CourseName = model.CourseName,
                    City = model.CourseCity,
                    State = model.CourseState,
                    Info = model.CourseInfo,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.GolfCourse.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GolfCourseList> GetGolfCourses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .GolfCourse
                        .Where(e => e.CourseId == e.CourseId)
                        .Select(
                            e =>
                                new GolfCourseList
                                {
                                    CourseId = e.CourseId,
                                    CourseName = e.CourseName,
                                    CourseCity = e.City,
                                    CourseState = e.State,
                                    CourseInfo = e.Info,
                                }
                        );

                return query.ToArray();
            }
        }

        public GolfCourseDetail GetGolfCourseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GolfCourse
                        .Single(e => e.CourseId == id && e.CourseId == e.CourseId);
                return
                    new GolfCourseDetail
                    {
                        CourseId = entity.CourseId,
                        CourseName = entity.CourseName,
                        CourseCity = entity.City,
                        CourseState = entity.State,
                        CourseInfo = entity.Info,
                    };
            }
        }

        public bool UpdateGolfCourse(GolfCourseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GolfCourse
                        .Single(e => e.CourseId == model.CourseId && e.CourseId == e.CourseId);

                entity.CourseId = model.CourseId;
                entity.CourseName = model.CourseName;
                entity.City = model.CourseCity;
                entity.State = model.CourseState;
                entity.Info = model.CourseInfo;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool GolfCourseDelete(int golfCourseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GolfCourse
                        .Single(e => e.CourseId == golfCourseId && e.CourseId == e.CourseId);

                ctx.GolfCourse.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}