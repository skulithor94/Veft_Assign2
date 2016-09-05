using System.Collections.Generic;

namespace assign2.Services.Entities
{
    public class Course
    {
        /// <summary>
        /// Primary key in db
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// /// 
        /// </summary>
        public string Semester { get; set; }

        /// <summary>
        /// Foreign key to CourseTemplate table
        /// </summary>
        public int TemplateID { get; set; }

        /// <summary>
        /// A nullable Start Date
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// A nullable End Date
        /// </summary>
        public string EndDate { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}