using System.Linq;
using System.Collections.Generic;
using assign2.Models; 
using assign2.Services.Entities;
using System;

namespace assign2.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly AppDataContext _db;

        public CoursesService(AppDataContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Gets a list of courses that all belong to the same semester
        /// </summary>
        /// <param name="semester">
        /// An optional string representing the semester, 
        /// if skipped the request will default semester to 20163
        /// </param>
        /// <returns>
        ///  List<CourseLiteDTO>
        /// </returns>
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

        /// <summary>
        /// Gets a single course that has the given id
        /// </summary>
        /// <param name="id">An integer representing the course id</param>
        /// <returns>
        /// CourseLiteDTO
        /// </returns>
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

        /// <summary>
        /// Deletes a single course that has the given id, 
        /// returning true on a successful delete, false otherwise
        /// </summary>
        /// <param name="id">An integer representing the course id</param>
        /// <returns>
        /// bool
        /// </returns>
        public bool DeleteCourseByID(int id)
        {
            var course = (from c in _db.Courses
                            where c.ID == id
                            select c).SingleOrDefault();
            if(course == null)
            {
                return false;
            }

            _db.Courses.Remove(course);
            _db.SaveChanges();

            return true;
        }


        /// <summary>
        ///         TODO
        /// </summary>
        /// <param name="model"></param>
        public void AddCourse(AddCourseViewModel model)
        {
            
        }

        public bool EditCourseByID(int id, EditCourseViewModel model)
        {
             var course = (from c in _db.Courses
                            where c.ID == id
                            select c).SingleOrDefault();
            
            if(course == null)
            {
                return false;
            }
            course.StartDate = model.StartDate;
            course.EndDate = model.EndDate;
            _db.SaveChanges();

            return true;
        }        
    }
}