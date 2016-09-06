using System.Collections.Generic;

namespace assign2.Services.Entities
{
    public class Student
    {
        /// <summary>
        /// Primary key in db
        /// </summary>
        public int ID {get; set; }
        
        /// <summary>
        /// Represents the students SSN
        /// </summary>
        public string SSN { get; set; }

        /// <summary>
        /// Foreign key to CourseTemplate table
        /// </summary>
        public string Name { get; set; }
    }
}