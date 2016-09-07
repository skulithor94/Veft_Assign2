using System.Collections.Generic;
using assign2.Models; 

namespace assign2.Services
{
    public interface ICoursesService
    {
        List<CourseSimpleDTO> GetCoursesBySemester(string semester);
        CourseDetailDTO GetCourseByID(int id);
        bool DeleteCourseByID(int id);
        bool EditCourseByID(int id, EditCourseViewModel model);
        bool AddStudentToCourseByID(int id, AddStudentViewModel student);
    }
}