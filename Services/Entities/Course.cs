using System;

namespace assign2.Services.Entities
{
    public class Course
    {
        /// <summary>
        /// Primary key in db
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Foreign key to CourseTemplate table
        /// </summary>
        public int TemplateID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Semester { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}