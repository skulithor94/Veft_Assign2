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
        ///  List<CourseSimpleDTO>
        /// </returns>
        public List<CourseSimpleDTO> GetCoursesBySemester(string semester)
        {
            // Defaulting to the current semester, ideally this should not be hardcoded
            if(semester == null)
                semester = "20163";

            // LINQ: joining the barebone course info with the detailed info
            var result = (
                from course in _db.Courses
                join courseTemplate in _db.CoursesTemplates                
                on course.TemplateID equals courseTemplate.ID
                where course.Semester == semester
                orderby courseTemplate.Name

                // Mapping to a DTO
                select new CourseSimpleDTO
                {
                    ID = course.ID,                    
                    Name = courseTemplate.Name,
                    CourseID = courseTemplate.CourseID,
                    Semester = course.Semester
                }).ToList();



                // append number of students to this
                
                return result;
        }

        /// <summary>
        /// Gets a single course that has the given id
        /// </summary>
        /// <param name="id">An integer representing the course id</param>
        /// <returns>
        /// CourseSimpleDTO
        /// </returns>
        public CourseSimpleDTO GetCourseByID(int id)
        {
            return (
                from course in _db.Courses                
                join courseTemplate in _db.CoursesTemplates on course.TemplateID equals courseTemplate.ID
                where course.ID == id

                select new CourseSimpleDTO
                {
                    ID = course.ID,
                    Name = courseTemplate.Name,
                    CourseID = courseTemplate.CourseID,
                    Semester = course.Semester
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
            var result = (
                from course in _db.Courses
                where course.ID == id
                select course
                ).SingleOrDefault();
            if(result == null)
                return false;

            _db.Courses.Remove(result);
            _db.SaveChanges();

            return true;
        }

        /// <summary>
        /// Updates a pre-existing Course with new info
        /// </summary>
        /// <param name="id">
        /// The ID of the course to edit
        /// Example: 1
        ///</param>
        /// <param name="model">
        /// Accepts an EditCourseViewModel with the following parameters:
        /// CourseID: required string - example: T-514-VEFT
        /// Name: required string - example: Vefþjónustur
        /// StartDate: optional string - example: 05092016
        /// EndDate: optional string - example: 05092016
        /// </param>
        /// <returns></returns>
        public bool EditCourseByID(int id, EditCourseViewModel model)
        {
             var result = (
                from course in _db.Courses
                where course.ID == id
                select course
                ).SingleOrDefault();
            
            if(result == null)
                return false;
            
            // Are we forgetting to actually implement the editing?
            
            Console.WriteLine(result);

            result.StartDate = model.StartDate;
            result.EndDate = model.EndDate;
            _db.SaveChanges();

            return true;
        }        
    }
}