using System.Collections.Generic;
using assign2.Models; 

namespace assign2.Services
{
    public interface ICoursesService
    {
        List<CourseLiteDTO> GetCoursesBySemester(string semester);
        CourseLiteDTO GetCourseByID(int id);
        bool DeleteCourseByID(int id);
        //TODO: Add more functions
    }
}