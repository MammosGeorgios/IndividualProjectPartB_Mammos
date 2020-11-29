using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartB_Mammos
{
    class InsertQueryUtils
    {
        private void InsertQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection("Server =.; Database = IndividualProjectPartB; Trusted_Connection = True;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }


            }
        }
        private string ProperDate(DateTime d)
        {
            // Me auti ti method apofeugw provlimata metaxy diaforetikwn morfwn imerominiwn logo culture klp
            //  i Sql ithele month/day/year kai mou prokalouse provlimata
            string s;
            s = $"{d.Year}-{d.Month}-{d.Day}";

            return s;
        }

        public void InsertStudent(string firstName, string lastName, DateTime dateOfBirth, Decimal tuitionFees)
        {
            //INSERT INTO Students(FirstName, LastName, DateOfBirth, TuitionFees) VALUES('InsertMan', 'McInsert', '2000-01-01', 2500);

            string query = "INSERT INTO Students(FirstName, LastName, DateOfBirth, TuitionFees) VALUES(";
            query = string.Concat(query, $"'{firstName}', '{lastName}', '{ProperDate(dateOfBirth)}', '{tuitionFees}')");

            Console.WriteLine($"Query executed >> {query}");
            InsertQuery(query);
        }
        public void InsertTrainer(string firstName, string lastName, int subject)
        {
            //string query = "INSERT INTO Trainers (FirstName,LastName,SubjectID) VALUES ('TestManT','TesterManT',5)";
            string query = "INSERT INTO Trainers (FirstName,LastName,SubjectID) VALUES ("; //'TestManT','TesterManT',5)";
            query = string.Concat(query, $"'{firstName}', '{lastName}','{subject}')");

            Console.WriteLine($"Query executed >> {query}");
            InsertQuery(query);
        }

        public void InsertCourse(string title, DateTime startDate,DateTime endDate, int courseType, int subject)
        {
            // string query = "Insert Into Courses(Title, StartDate, EndDate, TypeID, SubjectID) Values('TestingCourse', '2021-05-01', '2021-08-01', '5', '5')";
            string query = "Insert Into Courses(Title, StartDate, EndDate, TypeID, SubjectID) Values(";
            query = string.Concat(query, $"'{title}', '{ProperDate(startDate)}','{ProperDate(endDate)}','{courseType}','{subject}')");
            Console.WriteLine($"Query executed >> {query}");
            InsertQuery(query);

        }

        public void InsertAssignment(string title, string description, DateTime submitionDay, int oralMark, int totalMark)
        {
            // string query = "Insert Into Assignments(Title, Description, SubDateTime, OralMark, TotalMark) values('InsertTest', 'Insert description test', '2020-12-25', '100', '100')";
            string query = "Insert Into Assignments(Title, Description, SubDateTime, OralMark, TotalMark) values(";
            query = string.Concat(query, $"'{title}', '{description}','{ProperDate(submitionDay)}','{oralMark}','{totalMark}')");
            Console.WriteLine($"Query executed >> {query}");
            InsertQuery(query);
        }

        public void InsertStudentCourseRelation(int courseID,int studentID)
        {

            string query = "Insert Into CourseStudents(CourseID, StudentID) Values(";
            query = string.Concat(query, $"'{courseID}','{studentID}')");
            Console.WriteLine($"Query executed >> {query}");
            InsertQuery(query);
        }
        public void InsertTrainerCourseRelation(int courseID, int trainerID)
        {

            string query = "Insert Into CourseTrainers(CourseID, TrainerID) Values(";
            query = string.Concat(query, $"'{courseID}','{trainerID}')");
            Console.WriteLine($"Query executed >> {query}");
            InsertQuery(query);
        }

        public void InsertAssignmentCourseRelation(int courseID, int assignmentID)
        {
            string query = "Insert Into CourseAssignments(CourseID, AssignmentID) Values(";
            query = string.Concat(query, $"'{courseID}','{assignmentID}')");
            Console.WriteLine($"Query executed >> {query}");
            InsertQuery(query);
        }

        public void InsertStudentSubmmitedAssignmentKey(int courseID,int studentID,int assignmentID)
        {
            string query = "Insert Into StudentSubmittedAssignments(CourseID,StudentID,AssignmentID) Values(";
            query = string.Concat(query, $"'{courseID}','{studentID}','{assignmentID}')");
            Console.WriteLine($"Query executed >> {query}");
            InsertQuery(query);
        }

        public void InsertMultipleStudentSumbittedAssignments(int courseID,List<int> studentIDs, List<int> assignmentIDs)
        {
            
            for (int i = 0; i < studentIDs.Count; i++)
            {
                for (int j = 0; j < assignmentIDs.Count; j++)
                {
                    InsertStudentSubmmitedAssignmentKey(courseID, studentIDs[i], assignmentIDs[j]);
                }
            }

        }


        // Helper methods to get information for Insert into the relation tables
        private int GetSingleIntResultFromQuery(string query)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection("Server =.; Database = IndividualProjectPartB; Trusted_Connection = True;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        rdr.Read();
                        if (rdr != null)result = Convert.ToInt32(rdr[0]);                        
                    }
                }
            }
            return result;
        }
        public int LastCourseID()
        {
            int result = GetSingleIntResultFromQuery("Select max(courseID) from courses");
            return (result);
        }
        public int LastStudentID()
        {
            int result = GetSingleIntResultFromQuery("Select max(studentID) from Students");
            return (result);
        }
        public int LastTrainerID()
        {
            int result = GetSingleIntResultFromQuery("Select max(TrainerID) from Trainers");
            return (result);
        }
        public int LastAssignmentID()
        {
            int result = GetSingleIntResultFromQuery("Select max(AssignmentID) from Assignments");
            return (result);
        }



    }
}
