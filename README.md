# Veft_Assign2

Summary Folder Overview:
    API         - Core project, this is what the client interacts with.
    Models      - Library storage for Models.
    Services    - Library storage for Services.

Summary Model Type Overview:
    DTO:        Data the API returns to a client
    ViewModel:  Data the API accepts from a client
    Entity:     Class that maps to a database   

- [x] XML documentation (20%)
    - [x] API methods
    - [x] Model Classes
    - [x] Include description
    - [x] Include example value for property description
- [x] Service (20%)
    - [x] Seperate class library for business logic
- [x] SQL (20%)
    - [x] Store data in an SQL database
    - [x] Write all queries in LINQ
- [x] Semester property for Courses (20%)
    - [x] Query for specific semesters
    - [x] If no query default to 20163
- [x] Models (20%)
    - [x] Do not expose entity classes outside of the API
    - [x] Use DTO/Viewmodel classes for return, applies to the above

- [ ] ROUTE SUPPORT
    - [x] /api/courses - GET
        - [x] Should return "T-514-VEFT" "20163"
    - [x] /api/courses?semester=20153
        - [x] Should return "T-514-VEFT" and "T-111-PROG" both "20153" 
    - [x] /api/courses/1 - GET
        - [x] Should return a more detailed object describing "T-514-VEFT", taught in "20153"
    - [x] /api/courses/999- GET
        - [x] Should return HTTP 404
    - [ ] /api/courses/1 - PUT
        - [ ] Should allow the client of the API to modify the given course instance.
        - [ ] CourseID and Semester are required
        - [ ] StartDate and EndDate are not required as parameters
    - [ ] /api/courses/999 - PUT
        - [ ] Should return 404
    - [ ] /api/courses/1 - DELETE
        - [ ] Should remove the given course
    - [ ] /api/courses/999 - DELETE
        - [ ] Should return 404
    - [ ] /api/courses/1/students - GET
        - [ ] Should return a list of all students in "T-514-VEFT" taught in "20153"
    - [ ] /api/courses/2/students - POST
        - [ ] Should add a new student to T-514-VEFT in 20163.
        - [ ] Request body should contain the SSN of the student 
     
