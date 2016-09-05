namespace assign2.Models
{
    public class StudentLiteDTO
    {
        /// <summary>
        /// Unique integer representing the ID of the student object
        /// Generated by the database
        /// </summary>        
        public int ID { get; set; }

        /// <summary>
        /// String representing the Name of the student object
        /// Example: "Andri Rafn"
        /// </summary>        
        public string Name { get; set; }

        /// <summary>
        /// String representing the SSN of the student object
        /// Example: "2304852759"
        /// </summary>        
        public string SSN { get; set; } 
    }
}