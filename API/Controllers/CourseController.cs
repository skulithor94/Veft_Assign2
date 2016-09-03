using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using assign2.Models;
using assign2.Services;

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
        public IActionResult GetCoursesOnSemester(string semester = null)
        {
            return new ObjectResult(_service.GetCoursesBySemester(semester)); 
        }

        [HttpGet]
        [Route("{id:int}")]
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
        public List<StudentLiteDTO> GetStudentsInCourse()
        {
            return null;
        }

        [HttpPost]
        [Route("{id:int}/students")]
        public void AddStudentToCourse(int id, [FromBody]string value)
        {
        }

        [HttpPut]
        [Route("{id:int}")]    
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
