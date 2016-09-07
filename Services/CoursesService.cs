using System.Linq;
using System.Collections.Generic;
using assign2.Models; 
using assign2.Services.Entities;
using assign2.Exceptions;
using System;

/*
                                                 (\ /)	Wot is this
                                                 ( . .) ♥ 
                                                c(”)(”)	  
    ---------------------------------------------------------------------------
*/

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
        /// Returns a list of simple versions of courses including a count of their students
        /// The returned courses all belong to the semester passed or if no semester is passed
        /// returns courses that belong to semester 2016
        /// </summary>
        /// <param name="semester">
        /// string representing the Course semester
        /// example: "20153"
        /// </param>
        /// <returns>
        /// List<CourseSimpleDTO>
        /// </returns>
        public List<CourseSimpleDTO> GetCoursesBySemester(string semester)
        {
            // Defaulting to the current semester, ideally this should not be hardcoded
            if(semester == null)
                semester = "20163";

            var result = (
                from course in _db.Courses
                join courseTemplate in _db.CoursesTemplates                
                on course.TemplateID equals courseTemplate.ID
                where course.Semester == semester
                orderby courseTemplate.Name

                select new CourseSimpleDTO
                {
                    ID = course.ID,                    
                    Name = courseTemplate.Name,
                    CourseID = courseTemplate.CourseID,
                    Semester = course.Semester
                }).ToList();

            foreach(var item in result){
                int count = (
                    from courseStudent in _db.CourseStudents
                    where courseStudent.CourseID == item.ID
                    select courseStudent
                ).Count();
                item.Students = count;
            }
            return result;
        }
        
        /// <summary>
        /// Returns a fully detailed course including a list with its students
        /// </summary>
        /// <param name="id">
        /// integer representing the Course ID
        /// example: 1
        /// </param>
        /// <returns>
        /// CourseDetailDTO
        /// </returns>
        public CourseDetailDTO GetCourseByID(int id)
        {
          var result = (
                from course in _db.Courses
                join courseTemplate in _db.CoursesTemplates                
                on course.TemplateID equals courseTemplate.ID
                where course.ID == id
                orderby courseTemplate.Name

                // Mapping to a DTO
                select new CourseDetailDTO
                {
                    ID = course.ID,                    
                    Name = courseTemplate.Name,
                    CourseID = courseTemplate.CourseID,
                    Semester = course.Semester,
                    StartDate = course.StartDate,
                    EndDate = course.EndDate
                }).FirstOrDefault();

            if(result != null){
                result.Students = GetStudentsByCourseID(id);;
            }

            return result;
        }

        /// <summary>
        /// Returns a list of students belonging to the course with the given ID
        /// </summary>
        /// <param name="id">
        /// integer representing the Course ID
        /// example: 1
        /// </param>
        /// <returns>
        /// List<StudentLiteDTO>
        /// </returns>
        public List<StudentLiteDTO> GetStudentsByCourseID(int id)
        {
            var students = (
                from courseStudent in _db.CourseStudents
                join student in _db.Students
                on courseStudent.StudentID equals student.ID
                where courseStudent.CourseID == id
                select new StudentLiteDTO
                {
                    ID = student.ID,
                    Name = student.Name,
                    SSN = student.SSN
                }).ToList();

            return students;
        }

        /// <summary>
        /// Adds a student to the course with the given id
        /// </summary>
        /// <param name="id">
        /// integer representing the Course ID
        /// example: 1
        /// </param>
        /// <param name="model">
        /// An AddStudentViewModel with the SSN of the student
        /// example: { "SSN": "2302962315"}
        /// </param>
        /// <returns>
        /// bool
        /// </returns>
        public bool AddStudentToCourseByID(int id, AddStudentViewModel student)
        {
            Console.Write(student);
            if(student == null)
                throw new NoStudentException("Student is null");

            var course = (
                from c in _db.Courses
                where c.ID == id
                select c
                ).SingleOrDefault();
            
            if(course == null)
                throw new NoCourseException("Course not found");
            
            var studentInCourse = (
                from s in _db.Students
                where s.SSN == student.SSN
                select s
                ).SingleOrDefault();   
            

            if(studentInCourse == null)    
                throw (new NoStudentException("Student not found"));

            var result = (
                from s in _db.CourseStudents
                where s.CourseID == course.ID
                && s.StudentID == studentInCourse.ID 
                select s
            ).SingleOrDefault(); 

            if(result != null)
                throw new ConnectionExistsException("Student and course already connected");

            CourseStudent cs = new CourseStudent
            {
                StudentID = studentInCourse.ID,
                CourseID   = id
            };

            _db.CourseStudents.Add(cs);
            _db.SaveChanges();

            return true;
        }

        /// <summary>
        /// Edit a course with the given id
        /// </summary>
        /// <param name="id">
        /// integer representing the Course ID
        /// example: 1
        /// </param>
        /// <param name="model">
        /// An EditCourseViewModel with the SSN of the student
        /// example: {
        /// "CourseID": 1
        /// "Name": "T-111-PROG"
        /// "StartDate": "230416"
        /// "EndDate": "230416"
        /// }
        /// </param>
        /// <returns>
        /// bool
        /// </returns>   
        public bool EditCourseByID(int id, EditCourseViewModel model)
        {
             var courseResult = (
                from course in _db.Courses
                where course.ID == id
                select course
                ).SingleOrDefault();

            if(courseResult == null)
                return false;

            var courseTemplateResult = (
                from courseTemplate in _db.CoursesTemplates
                where courseTemplate.ID == courseResult.TemplateID
                select courseTemplate
                ).SingleOrDefault();
                 
            courseResult.StartDate = model.StartDate;
            courseResult.EndDate = model.EndDate;
            _db.SaveChanges();

            return true;
        } 

        /// <summary>
        /// Deletes the course with the given id
        /// </summary>
        /// <param name="id">
        /// integer representing the Course ID
        /// example: 1
        /// </param>
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

    }
}