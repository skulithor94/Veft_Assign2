using System.Collections.Generic;
using assign2.Models; 

namespace assign2.Services
{
    public interface ICoursesService
    {
        List<CourseSimpleDTO> GetCoursesBySemester(string semester);
        CourseSimpleDTO GetCourseByID(int id);
        bool DeleteCourseByID(int id);
        bool EditCourseByID(int id, EditCourseViewModel model);
    }
}