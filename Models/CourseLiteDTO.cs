﻿using System;

namespace assign2.Models
{
    public class CourseLiteDTO
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
        /// String representing the Semester of the course object
        /// Example: "20163"
        /// </summary>        
        public string Semester { get; set; } 
    
    }
}
