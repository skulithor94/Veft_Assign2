using System;

namespace assign2.Models
{
    public class EditCourseViewModel
    {
         /// <summary>
        /// Primary key in db
        /// </summary>
        public int ID { get; set; }

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