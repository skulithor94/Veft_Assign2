using System;

namespace assign2.Models
{
    /// <summary>
    /// An abstraction of Course and CourseTemplate
    /// Used for for editing course information by client request
    /// </summary>
    public class EditCourseViewModel
    {
        /// <summary>
        /// CourseID value stored in CoursesTemplates
        /// </summary>
        public string CourseID { get; set; }

        /// <summary>
        /// CourseID value stored in CoursesTemplates
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Start date stored in Courses
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// End date stored in Courses
        /// </summary>
        public string EndDate { get; set; }
    }
}