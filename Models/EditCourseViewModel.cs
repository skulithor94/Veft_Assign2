using System;

namespace assign2.Models
{
    /// <summary>
    /// An abstraction of Course
    /// Used for for editing course information by client request
    /// </summary>
    public class EditCourseViewModel
    {
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