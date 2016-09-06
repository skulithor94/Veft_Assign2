using System.Collections.Generic;

namespace assign2.Services.Entities
{
    public class CourseStudent
    {
        /// <summary>
        /// Primary key in db
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Foreign key to Course table
        /// </summary>
        public int StudentID { get; set; }

        /// <summary>
        /// Foreign key to Course table
        /// </summary>
        public int CourseID { get; set; }
    }
}