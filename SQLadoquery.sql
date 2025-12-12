 CREATE TABLE Students
(
    StudentId INT IDENTITY(1,1) PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE,
    Department VARCHAR(50) NOT NULL,
    YearOfStudy INT NOT NULL
);
Insert Into Students (FullName, Email, Department, YearOfStudy)
Values ('Mani', 'KanasaniNagamani1995@.gmail.com', 'Computer Science', 1);

Insert Into Students (FullName, Email, Department, YearOfStudy)
VALUES ('Sam', 'samvidha@gmail.com', 'Electronics', 2);

Insert Into Students (FullName, Email, Department, YearOfStudy)
VALUES ('Parvathi', 'Pari123@gmail.com', 'Mechanical', 3);

Insert Into Students (FullName, Email, Department, YearOfStudy)
Values ('Abhi', 'Abhi080988@gmail.com.com', 'Civil Engineering', 4);

Insert Into Students (FullName, Email, Department, YearOfStudy)
Values ('Srinu', 'Srinu456@gmail.com', 'Information Technology', 1);

select * from Students;
//////2nd table
CREATE TABLE Courses
(
    CourseId INT IDENTITY(1,1) PRIMARY KEY,
    CourseName VARCHAR(100) NOT NULL,
    Credits INT NOT NULL,
    Semester VARCHAR(20) NOT NULL
);
Insert Into Courses (CourseName, Credits, Semester)
Values ('Data Structures', 4, 'Semester 1');

Insert Into Courses (CourseName, Credits, Semester)
Values ('Database Management Systems', 3, 'Semester 2');

Insert Into Courses (CourseName, Credits, Semester)
Values ('Operating Systems', 4, 'Semester 3');

Insert Into Courses (CourseName, Credits, Semester)
Values ('Computer Networks', 3, 'Semester 4');

Insert Into Courses (CourseName, Credits, Semester)
Values ('Software Engineering', 3, 'Semester 5');

Insert Into Courses (CourseName, Credits, Semester)
Values ('Machine Learning', 4, 'Semester 6');

Insert Into Courses (CourseName, Credits, Semester)
VALUES ('Artificial Intelligence', 4, 'Semester 7');

Insert Into Courses (CourseName, Credits, Semester)
Values ('Cloud Computing', 3, 'Semester 8');

select * from Courses;
///
CREATE TABLE Enrollments
(
    EnrollmentId INT IDENTITY(1,1) PRIMARY KEY,
    StudentId INT NOT NULL,
    CourseId INT NOT NULL,
    EnrollDate DATETIME NOT NULL,
    Grade VARCHAR(5) NULL,

    Constraint FK_Enrollments_Students
        Foreign Key (StudentId) REFERENCES Students(StudentId),

    Constraint FK_Enrollments_Courses
        Foreign Key (CourseId) References Courses(CourseId)
);
Insert Into Students (FullName, Email, Department, YearOfStudy)
Values ('Mani', 'KanasaniNagamani1995@.gmail.com',  'Computer Science', 1);

Insert Into Students (FullName, Email, Department, YearOfStudy)
Values ('Sam', 'samvidha@gmail.com', 'Electronics', 2);

Insert Into Students (FullName, Email, Department, YearOfStudy)
Values ('Parvathi', 'Pari123@gmail.com',  'Mechanical', 3);

Insert Into Students (FullName, Email, Department, YearOfStudy)
Values ('Abhi', 'Abhi080988@gmail.com.com', 'Civil Engineering', 4);

Insert Into Students (FullName, Email, Department, YearOfStudy)
Values ('Srinu', 'Srinu456@gmail.com', 'Information Technology', 1);
select * from Students;
////
Insert Into Courses (CourseName, Credits, Semester)
Values ('Data Structures', 4, 'Semester 1');

Insert Into Courses (CourseName, Credits, Semester)
Values ('Database Management Systems', 3, 'Semester 2');

Insert Into Courses (CourseName, Credits, Semester)
Values ('Operating Systems', 4, 'Semester 3');

Insert Into Courses (CourseName, Credits, Semester)
Values ('Computer Networks', 3, 'Semester 4');

Insert Into Courses (CourseName, Credits, Semester)
Values ('Software Engineering', 3, 'Semester 5');

Insert Into Courses (CourseName, Credits, Semester)
Values ('Machine Learning', 4, 'Semester 6');
select * from Courses;

Insert Into Enrollments (StudentId, CourseId, EnrollDate, Grade)
Values (1, 1, GETDATE(), 'A');

Insert Into Enrollments (StudentId, CourseId, EnrollDate, Grade)
Values (1, 2, GETDATE(), 'B+');

Insert Into Enrollments (StudentId, CourseId, EnrollDate, Grade)
Values (2, 3, GETDATE(), 'A+');

Insert Into Enrollments (StudentId, CourseId, EnrollDate, Grade)
Values (3, 4, GETDATE(), 'B');

Insert Into Enrollments (StudentId, CourseId, EnrollDate, Grade)
Values (4, 5, GETDATE(), NULL);  
Insert Into Enrollments (StudentId, CourseId, EnrollDate, Grade)
Values (5, 6, GETDATE(), 'A');
select * from Enrollments;



