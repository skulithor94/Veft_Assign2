namespace assign2.Models
{
    /// <summary>
    /// A simple abstraction of student
    /// Used for passing a reference to a student to the server
    /// </summary>
    public class AddStudentViewModel
    {
        /// <summary>
        /// String representing the ssn of the student
        /// </summary>
        /// <returns></returns>
        public string SSN { get; set; }
    }
}