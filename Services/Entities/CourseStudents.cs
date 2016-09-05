using System.Collections.Generic;

namespace assign2.Services.Entities
{
    public class CourseStudent
    {
        /// <summary>
        /// Primary key in db
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Foreign key to Course table
        /// </summary>
        public string StudentSSN { get; set; }

        /// <summary>
        /// Foreign key to Course table
        /// </summary>
        public string CourseID { get; set; }
    }
}