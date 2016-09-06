﻿using System;

namespace assign2.Models
{
    public class CourseSimpleDTO
    {
        /// <summary>
        /// Unique integer representing the ID of the course object
        /// Generated by the database
        /// </summary>        
        public int ID { get; set; }

        /// <summary>
        /// String representing the Name of the course object
        /// Example: "Web Services"
        /// </summary>        
        public string Name { get; set; }
        
        /// <summary>
        /// String representing the CourseID of the course object
        /// Example: "T-111-PROG"
        /// </summary>        
        public string CourseID { get; set; }

        /// <summary>
        /// String representing the Semester of the course object
        /// Example: "20163"
        /// </summary>        
        public string Semester { get; set; }    

        /// <summary>
        /// Integer representing the number of students belonging to this course object
        /// </summary>
        /// <returns></returns>
        public int Students { get; set; }
    }
}