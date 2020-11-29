using IndividualProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartB_Mammos
{
    class menuUtils
    {


       

        public menuUtils()
        {
            menu();
        }

        private void menu()
        {
            GreetingMessage();
            List<string> menuOptions = new List<string>() { "A list of All the Students","A list of All the Trainers","A list of All the Assignments", "A list of All the Courses",
                                                            "All the Students per Course","All the Trainers per Course","All the Assignments per Course",
                                                            "All the Assignments per Course per Student", "A list of students that belong to more than one Courses",
                                                            "Bonus - All graded Assignments", "Insert New Student", "Insert New Trainer", "Insert New Assignment",
                                                            "Insert New Course","Add Students Per Course","Add Trainers Per Course", 
                                                            "Add assignments per student per course","Exit\n" };
            PrintQueryUtils printQueryMethods = new PrintQueryUtils();
            bool exit = false;
            bool sameChoice = false;
            int menuChoice = 0;
            while (!exit)
            {
                if (!sameChoice)
                {
                    ShowOptions(menuOptions);
                    menuChoice = ReadMenuInput(menuOptions.Count);
                }

                switch (menuChoice)
                {
                    case 1:
                        printQueryMethods.PrintAllStudents();
                        break;
                    case 2:
                        printQueryMethods.PrintAllTrainers();
                        break;
                    case 3:
                        printQueryMethods.PrintAllAssignments();
                        break;
                    case 4:
                        printQueryMethods.PrintAllCourses();
                        break;
                    case 5:
                        printQueryMethods.PrintAllStudentsPerCourse();
                        break;
                    case 6:
                        printQueryMethods.PrintAllTrainersPerCourse();
                        break;
                    case 7:
                        printQueryMethods.PrintAllAssignmentsPerCourse();
                        break;
                    case 8:
                        printQueryMethods.PrintAllAssignmentsPerCoursePerStudent();
                        break;
                    case 9:
                        printQueryMethods.PrintAllStudentsThatBelongInMoreThanOneClass();
                        break;
                    case 10:
                        printQueryMethods.PrintAllSubmittedAssignments();
                        break;
                    case 11:
                        NewStudent();
                        break;
                    case 12:
                        NewTrainer();
                        break;
                    case 13:
                        NewAssignment();
                        break;
                    case 14:
                        NewCourse();
                        break;
                    case 15:
                        NewStudentAndCourse();
                        break;
                    case 16:
                        NewTrainerAndCourse();
                        break;
                    case 17:
                        NewAssignmentsPerStudentPerCourse();
                        break;
                    default:
                        exit = true;
                        break;
                        


                }
                if (!exit)
                {
                    sameChoice = SameChoiceQuestion();
                }
            }
            Console.WriteLine("Goodbye!!!");
        }

        private void GreetingMessage() {
            Console.WriteLine("Hello message");
        
        }
        private void ShowOptions(List<string> menuOptions)
        {
            
            PrintListNumbered(menuOptions);
        }
        private void PrintListNumbered(List<string> list)
        {

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {list[i]}");
            }
        }
        private int ReadMenuInput(int optionsCount)
        {
            
            int result = 0;
            result = AskValidNumber("Select one of the above options by writing its number", 1, optionsCount);
            return (result);

        }
        private bool SameChoiceQuestion(string message = null)
        {
            bool result = false;
            if (message is null)Console.WriteLine("If you want to repeat the last option selected from the menu, type YES , otherwise press enter (or give any other input).");
            else Console.WriteLine(message);
            
            if (Console.ReadLine() == "YES") result = true;
            return (result);
        }
        public int AskValidNumber(string message, int minValue, int maxValue) // OK
        {
            int result = 0;
            bool isValidFlag = false;
            string input;
            while (!isValidFlag)
            {
                Console.WriteLine(message + ": ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input)) Console.WriteLine("INVALID INPUT, must not be an empty/white space input");
                else
                {
                    if (!Int32.TryParse(input, out result)) Console.WriteLine("INVALID INPUT, must be an interger");
                    else
                    {
                        if (minValue <= result && result <= maxValue) isValidFlag = true;
                        else Console.WriteLine($"INVALID INPUT, number must be equal or between {minValue} and {maxValue}");
                    }
                }
            }
            return (result);
        }

        private void NewStudent()
        {
            AskDetailsUtils adu = new AskDetailsUtils();
            Student s = new Student();
            s = adu.GetStudentDetails();
            InsertQueryUtils iq = new InsertQueryUtils();           
            iq.InsertStudent(s.FirstName, s.LastName, s.DateOfBirth, s.TuitionFees);
        }
        private void NewTrainer()
        {
            Trainer trainer = new Trainer();
            AskDetailsUtils d = new AskDetailsUtils();
            InsertQueryUtils i = new InsertQueryUtils();

            trainer = d.GetTrainerDetails();
            i.InsertTrainer(trainer.FirstName, trainer.LastName, trainer.Subject);
        }
        private void NewCourse()
        {
            Course course;
            AskDetailsUtils d = new AskDetailsUtils();
            InsertQueryUtils i = new InsertQueryUtils();
            course = d.GetCourseDetails();
            i.InsertCourse(course.Title, course.StartDate, course.EndDate, course.Type,course.Stream);
        }
        private void NewAssignment()
        {
            Assignment assignment;
            AskDetailsUtils d = new AskDetailsUtils();
            InsertQueryUtils i = new InsertQueryUtils();
            assignment = d.GetAssignmentDetails();
            i.InsertAssignment(assignment.Title, assignment.Description, assignment.SubDateTime, assignment.OralMark, assignment.TotalMark);

        }
        private void NewStudentAndCourse()
        {
            InsertQueryUtils iq = new InsertQueryUtils();
            NewCourse();
            int courseID = iq.LastCourseID();
            int studentID;

            bool repeat = true;

            while (repeat)
            {
                NewStudent(); 
                studentID = iq.LastStudentID();
                iq.InsertStudentCourseRelation(courseID, studentID);

                repeat = SameChoiceQuestion("Do you want to add another student in the same course? If so type YES , otherwise press enter (or give any other input). ");

            }
        }
        private void NewTrainerAndCourse()
        {
            InsertQueryUtils iq = new InsertQueryUtils();
            NewCourse();
            int courseID = iq.LastCourseID();
            int trainerID;

            bool repeat = true;

            while (repeat)
            {
                NewTrainer();
                trainerID = iq.LastTrainerID();
                iq.InsertTrainerCourseRelation(courseID, trainerID);

                repeat = SameChoiceQuestion("Do you want to add another trainer in the same course? If so type YES , otherwise press enter (or give any other input). ");

            }
        }

        private void NewAssignmentsPerStudentPerCourse()
        {
            //edw den to ekana oso poluploko tha mporousa gt otan rwtisa sto breafing mas eipate apla nea assignment, students kai courses.
            //opws to exw ftiaxei egw to assignment table exei apla tin ekfwnisi kai ta oral/total marks einai ousiastika ta max
            //για αυτο και έφτιαξα ένα έξτρα πίνακα που κρατάει τις βαθμολογίες αλλά πλέον πάω πολύ μακρυά απο την αρχική υλοποίηση
            // Δεν είμαι σίγουρος τι ακριβώς θέλουμε σε αυτο το ερώτημα οπότε θα το κάνω όπως είπαμε στο briefing 
            // και απλα θα περάσω στον StudentSubmittedAssignments τους συνδυασμούς χωρις βαθμολογίες
            InsertQueryUtils iq = new InsertQueryUtils();
            NewCourse();
            int courseID = iq.LastCourseID();
            List<int> studentID = new List<int>(); // for multiple students

            bool repeat = true;

            while (repeat)
            {
                NewStudent();
                studentID.Add(iq.LastStudentID());
                iq.InsertStudentCourseRelation(courseID, studentID.Last());

                repeat = SameChoiceQuestion("Do you want to add another student in the same course? If so type YES , otherwise press enter (or give any other input). ");

            }

            List<int> assignmentID = new List<int>();
            repeat = true;

            while (repeat)
            {
                NewAssignment();
                assignmentID.Add(iq.LastAssignmentID());
                iq.InsertAssignmentCourseRelation(courseID, assignmentID.Last());

                repeat = SameChoiceQuestion("Do you want to add another assignment in the same course? If so type YES , otherwise press enter (or give any other input). ");

            }

            // Μέχρι εδω έχω ένα course + students kai course + assignments
            // Η επόμενη Method θα κάνει όλους τους συσχετισμούς στον πινακα StudentSubmittedAssignments

            iq.InsertMultipleStudentSumbittedAssignments(courseID, studentID, assignmentID);




        }



    }
}
