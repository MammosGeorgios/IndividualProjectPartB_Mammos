using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartB_Mammos
{
    class PrintQueryUtils
    {
        public void PrintQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection("Server =.; Database = IndividualProjectPartB; Trusted_Connection = True;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        //DateTime d = new DateTime();
                        if (rdr != null)
                        {
                            //Print table names
                            Console.Write(">>>>> ");
                            for (int i = 0; i < rdr.FieldCount; i++)
                            {
                                Console.Write($" {rdr.GetName(i),-31}");
                            }
                            Console.WriteLine("\n");

                            // Print table rows with my own counter
                            int resultCounter = 0;
                            while (rdr.Read())
                            {
                                resultCounter++;
                                Console.Write($"{resultCounter,3}>> ");
                                for (int i = 0; i < rdr.FieldCount; i++)
                                {
                                    
                                    Console.Write($" {rdr[i],-31}");
                                }
                                Console.Write("\n");
                            }
                        }
                    }
                }

            }
        }
        public void PrintAllStudents()
        {
            string query = "Select FirstName, LastName From Students";
            PrintQuery(query);
        }
        public void PrintAllTrainers()
        {
            string query = "Select TrainerID,FirstName,LastName,SubjectName From Trainers Join Subjects on Trainers.SubjectID = Subjects.SubjectID";
            PrintQuery(query);
        }
        public void PrintAllAssignments()
        {
            string query = "Select * From Assignments";
            PrintQuery(query);
        }
        public void PrintAllCourses()
        {
            string query = "Select CourseID,Title,StartDate,EndDate,TypeName,SubjectName From (Courses join CourseTypes On Courses.TypeID = CourseTypes.TypeID) " +
                "join Subjects on Courses.SubjectID = Subjects.SubjectID";

            PrintQuery(query);
        }
        public void PrintAllStudentsPerCourse()
        {
            string query = "Select Title,FirstName,LastName From (Courses join CourseStudents on Courses.CourseID = CourseStudents.CourseID) " +
                "join Students on CourseStudents.StudentID = Students.StudentID";
            PrintQuery(query);
        }
        public void PrintAllTrainersPerCourse()
        {
            string query = "Select Courses.Title, Trainers.TrainerID,Trainers.FirstName, Trainers.LastName  from Courses join CourseTrainers on Courses.CourseID = CourseTrainers.CourseID " +
                "join Trainers on CourseTrainers.TrainerID = Trainers.TrainerID";
            PrintQuery(query);
        }
        public void PrintAllAssignmentsPerCourse()
        {
            string query = "Select Courses.Title as 'Course Title', Assignments.AssignmentID,Assignments.Title as 'Assignment Title' " +
                "From Courses join CourseAssignments on Courses.CourseID = CourseAssignments.CourseID " +
                "join Assignments on CourseAssignments.AssignmentID = Assignments.AssignmentID";
            PrintQuery(query);
        }
        public void PrintAllAssignmentsPerCoursePerStudent()
        {
            string query = "Select Students.StudentID, Students.FirstName,Students.LastName , Courses.Title , Assignments.Title " +
                "From Students join CourseStudents on CourseStudents.StudentID = Students.StudentID " +
                "join Courses on CourseStudents.CourseID = Courses.CourseID " +
                "join CourseAssignments on Courses.CourseID = CourseAssignments.CourseID " +
                "join Assignments on CourseAssignments.AssignmentID = Assignments.AssignmentID " +
                "order by Students.StudentID; ";
            PrintQuery(query);
        }
        public void PrintAllStudentsThatBelongInMoreThanOneClass()
        {
            string query = "Select Students.StudentID,Students.FirstName, Students.LastName, count(*) as 'Numbers of classes' " +
                "from Students join CourseStudents on Students.StudentID = CourseStudents.StudentID " +
                "group by Students.StudentID, FirstName, LastName " +
                "Having Count(*)>1";
            PrintQuery(query);
        }
        public void PrintAllSubmittedAssignments()
        {
            string query = "Select Students.StudentID, Students.FirstName, Students.LastName, courses.Title, Assignments.Title, e.OralMark as 'Oral Grade', e.TotalMark as 'Total Grade' " +
                "From StudentSubmittedAssignments as e join Students on e.StudentID = Students.StudentID " +
                "join CourseAssignments on e.AssignmentID = CourseAssignments.AssignmentID and e.CourseID = CourseAssignments.CourseID " +
                "join Assignments on CourseAssignments.AssignmentID = Assignments.AssignmentID " +
                "join Courses on CourseAssignments.CourseID = Courses.CourseID " +
                "order by Students.StudentID, courses.Title; ";
            PrintQuery(query);
        }

     
    }
}

