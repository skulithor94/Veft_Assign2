using System.Linq;
using System.Collections.Generic;
using assign2.Models; 
using assign2.Services.Entities;

namespace assign2.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly AppDataContext _db;

        public CoursesService(AppDataContext db)
        {
            _db = db;
        }

        public List<CourseLiteDTO> GetCoursesBySemester(string semester)
        {

            if(semester == null)
            {
                semester = "20163";
            }

            var result = (from c in _db.Courses
                join ct in _db.CoursesTemplates on c.TemplateID equals ct.ID
                where c.Semester == semester 
                orderby ct.Name
                select new CourseLiteDTO
                {
                    ID = c.ID,
                    Name = ct.Name,
                    Semester = c.Semester
                }).ToList();

                return result;
        }

        public CourseLiteDTO GetCourseByID(int id)
        {
            return (from c in _db.Courses
                        join ct in _db.CoursesTemplates on c.TemplateID equals ct.ID
                        where c.ID == id
                        select new CourseLiteDTO
                        {
                            ID = c.ID,
                            Name = ct.Name,
                            Semester = c.Semester
                        }).SingleOrDefault();
        }

        public void AddCourse(AddCourseViewModel model)
        {
            var course = new Course
            {
                TemplateID = model.TemplateID,
                Semester = model.Semester
            };

            _db.Courses.Add(course);
            _db.SaveChanges();
        }
        
    }
}