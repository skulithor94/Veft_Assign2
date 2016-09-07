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
        - [x] Returns:
        ```
        [
            {
                "id": 1,
                "name": "Vefþjónustur",
                "courseID": "T-514-VEFT",
                "semester": "20163",
                "students": 3
            }
        ]
        ```
    - [x] /api/courses?semester=20153 - GET
        - [x] Returns:
        ```
        [
            {
                "id": 2,
                "name": "Forritun",
                "courseID": "T-111-PROG",
                "semester": "20153",
                "students": 3
            },
            {
                "id": 3,
                "name": "Vefþjónustur",
                "courseID": "T-514-VEFT",
                "semester": "20153",
                "students": 2
            }
        ]
        ```
    - [x] /api/courses/1 - GET
        - [x] Returns:
        ```
        {
            "id": 1,
            "name": "Vefþjónustur",
            "courseID": "T-514-VEFT",
            "semester": "20163",
            "startDate": "",
            "endDate": "",
            "students": [
                {
                "id": 4,
                "name": "Jóna Halldórsdóttir",
                "ssn": "4567891230"
                },
                {
                "id": 2,
                "name": "Guðrún Jónsdóttir",
                "ssn": "9876543210"
                },
                {
                "id": 1,
                "name": "Jón Jónsson",
                "ssn": "1234567890"
                }
            ]
        }
        ```
    - [x] /api/courses/999 - GET
        - [x] Returns:
        ```
        Status: 404 Not Found
        ```
    - [x] /api/courses/1 - PUT
        - [x] Should allow the client of the API to modify the given course instance.
        - [x] StartDate and EndDate are the only values that can be changed
    - [x] /api/courses/999 - PUT
        - [x] Returns:
        ```
        Status: 404 Not Found
        ```
    - [x] /api/courses/1 - DELETE
        - [x] Should remove the given course
    - [x] /api/courses/999 - DELETE
        - [x] Returns:
        ```
        Status: 404 Not Found
        ```
    - [x] /api/courses/1/students - GET
        - [x] Should return a list of all students in "T-514-VEFT" taught in "20153"
    - [x] /api/courses/2/students - POST
        - [x] Should add a new student to T-514-VEFT in 20163.
        - [x] Request body should contain the SSN of the student 
     
