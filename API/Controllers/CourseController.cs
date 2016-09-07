using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using assign2.Models;
using assign2.Services;
using assign2.Exceptions;

namespace assign2.API.Controllers
{
    [Route("api/courses")]
    public class CourseController : Controller
    {

        private readonly ICoursesService _service;
        

        public CourseController(ICoursesService service)
        {
             _service = service;
        }
        
        [HttpGet]
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
        /// IActionResult
        /// </returns>
        public IActionResult GetCoursesBySemester(string semester = null)
        {
            return new ObjectResult(_service.GetCoursesBySemester(semester)); 
        }

        [HttpGet]
        [Route("{id:int}")]
        /// <summary>
        /// Returns a fully detailed course including a list with its students
        /// </summary>
        /// <param name="id">
        /// integer representing the Course ID
        /// example: 1
        /// </param>
        /// <returns>
        /// IActionResult
        /// </returns>
        public IActionResult GetCourseByID(int id)
        {
            var course = _service.GetCourseByID(id);
            if(course != null)
            {
                return new ObjectResult(course);
            }
            else
            {
                return NotFound();
            }
        }
        
        [HttpGet]
        [Route("{id:int}/students")]
        /// <summary>
        /// Returns a list of students belonging to the course with the given ID
        /// </summary>
        /// <param name="id">
        /// integer representing the Course ID
        /// example: 1
        /// </param>
        /// <returns>
        /// IActionResult
        /// </returns>
        public IActionResult GetStudentsByCourseID(int id  )
        {
            try
            {
                return new ObjectResult(_service.GetStudentsByCourseID(id));
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        [Route("{id:int}/students")]
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
        /// IActionResult
        /// </returns>
        public IActionResult AddStudentToCourseByID(int id, [FromBody]AddStudentViewModel model)
        {
            try
            {
                _service.AddStudentToCourseByID(id, model);
                return new NoContentResult();
            }
            catch (NoStudentException e)
            {
                Console.Write(e.Message);
                return NotFound();
            } 
            catch (NoCourseException e2)
            {
                Console.Write(e2.Message);
                return NotFound();
            }
            catch (ConnectionExistsException e3)
            {
                Console.Write(e3.Message);
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{id:int}")]
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
        /// IActionResult
        /// </returns>    
        public IActionResult EditCourseByID(int id, [FromBody]EditCourseViewModel model)
        {
            bool edited = _service.EditCourseByID(id, model);
            if(edited)
            {
                return new NoContentResult();
            }
            return NotFound();
        }
        
        [HttpDelete]
        [Route("{id:int}")]
        /// <summary>
        /// Deletes the course with the given id
        /// </summary>
        /// <param name="id">
        /// integer representing the Course ID
        /// example: 1
        /// </param>
        /// <returns></returns>
        public IActionResult DeleteCourseByID(int id)
        {
            bool deleted = _service.DeleteCourseByID(id);
            if(deleted)
            {
                return new NoContentResult();
            }
            return NotFound();
        }
    }
}
