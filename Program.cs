using Lab4.Business.DTOs;
using Lab4.Business.Services;
using Lab4.Business.Validators;
using Lab4.Data;
using Lab4.Data.Interfaces;
using Lab4.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;

namespace Lab4
{
    internal class Program
    {
        static DepartmentService staffService;
        static StudentService studentService;
        static CourseService courseService;
        static EnrollmentService enrollmentService;
        static UnitOfWork unitOfWork;
        static StudentValidator studentValidator;
        static ClassValidator classValidator;
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
            string connection = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<Lab4DBContext>();
            optionsBuilder.UseSqlServer(connection);

            using (var context = new Lab4DBContext(optionsBuilder.Options))
            {

                unitOfWork = new UnitOfWork(context);
                studentValidator = new StudentValidator(unitOfWork);
                classValidator = new ClassValidator(unitOfWork);
                staffService = new DepartmentService(unitOfWork);
                studentService = new StudentService(unitOfWork, studentValidator, classValidator);
                courseService = new CourseService(unitOfWork);
                enrollmentService = new EnrollmentService(unitOfWork);

                RunApplication();
            }
        }

        static void RunApplication()
        {
            bool appIsRunning = true;
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            while (appIsRunning)
            {
                StartupMenu();
                appIsRunning = MenuChoice();

            }
        }

        static void StartupMenu()
        {
            ClearConsoleFully();
            Console.WriteLine("The middle-earth:ian learning center");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("\nChoose what must be done:");
            Console.WriteLine("[1] Show how many teachers are currenly working in each department");
            Console.WriteLine("[2] Show info about all students, including classes, courses and grades");
            Console.WriteLine("[3] Show all currently active courses");
            Console.WriteLine("[4] Add a new grade to a student");
            Console.WriteLine("[ESC] Exit the application");
            Console.WriteLine();
            Console.WriteLine("[5] -EXTRA FEATURE- Correct and update an existing student's information");
        }

        static bool MenuChoice()
        {
            switch (Console.ReadKey(intercept: true).Key)
            {
                case ConsoleKey.D1:
                    var departmentTeacherList = staffService.AmountOfTeachersPerDepartment();
                    ClearConsoleFully();
                    Console.WriteLine();
                    Console.WriteLine("-------------------------------------------------");

                    foreach (var department in departmentTeacherList)
                    {
                        Console.Write($"{department.DepartmentTitle}: {department.NumberOfTeachers} ");

                        if (department.NumberOfTeachers == 1)
                        {
                            Console.WriteLine("teacher");
                        }
                        else
                        {
                            Console.WriteLine("teachers");
                        }
                    }
                    Console.WriteLine("-------------------------------------------------");
                    ContinueBreak();
                    break;

                case ConsoleKey.D2:
                    var studentInfo = studentService.GetInfoAboutAllStudents();
                    ClearConsoleFully();
                    Console.WriteLine();
                    Console.WriteLine("-------------------------------------------------");

                    foreach (var student in studentInfo)
                    {
                        Console.WriteLine($"{student.FirstName} {student.LastName}, class of \"{student.NameOfClass}\"");
                        Console.WriteLine($"Courses: {student.Courses}");
                        Console.WriteLine($"Grades: {student.Grades}");
                        Console.WriteLine("-------------------------------------------------");
                    }
                    ContinueBreak();

                    break;

                case ConsoleKey.D3:
                    var activeCourses = courseService.GetAllActiveCourses();
                    ClearConsoleFully();
                    Console.WriteLine();
                    Console.WriteLine("-------------------------------------------------");

                    foreach (var course in activeCourses)
                    {
                        Console.WriteLine($"Course: {course.CourseTitle}");
                        Console.WriteLine($"Started at {course.StartDate} and ends at {course.EndDate}");
                        Console.Write($"Days left in course: {course.DaysLeft} ");

                        if (course.DaysLeft == 1)
                        {
                            Console.WriteLine("day");
                        }
                        else if (course.DaysLeft == 0)
                        {
                            Console.WriteLine("days! Examination day TODAY!");
                        }
                        else
                        {
                            Console.WriteLine("days");
                        }
                        Console.WriteLine("-------------------------------------------------");
                    }
                    ContinueBreak();
                    break;

                case ConsoleKey.D4:
                    ClearConsoleFully();
                    Console.Write("Enter the ID of the enrollment you wish to apply a grade to: ");
                    int enrollmentId = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    Console.Write("Enter the grade (between 0.0 - 10.0): ");
                    decimal gradePoint = decimal.Parse(Console.ReadLine());
                    Console.WriteLine();

                    ClearConsoleFully();
                    enrollmentService.SetGrade(enrollmentId, gradePoint);
                    Console.WriteLine("Grade set!\n");
                    ContinueBreak();
                    break;

                case ConsoleKey.D5:
                    ClearConsoleFully();
                    Console.Write("Enter the ID of the student you wish to correct/update: ");
                    int studentId = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    Console.Write("Enter their first name: ");
                    string firstName = Console.ReadLine();
                    Console.WriteLine();

                    Console.Write("Enter their last name: ");
                    string lastName = Console.ReadLine();
                    Console.WriteLine();

                    Console.Write("Enter the students personnummer 10 or 12 numbers, '-' to separate the last 4 digits (i.e. xxxxxxxx-xxxx): ");
                    string personnummer = Console.ReadLine();
                    Console.WriteLine();

                    Console.Write("Enter the student's home address: ");
                    string address = Console.ReadLine();
                    Console.WriteLine();

                    Console.Write("Enter the student's email: ");
                    string email = Console.ReadLine();
                    Console.WriteLine();

                    Console.Write("Enter the ID of the class the student is going to transfer to: ");
                    int classId = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    ClearConsoleFully();
                    studentService.UpdateStudentInfo(studentId, firstName, lastName, personnummer, address, email, classId);
                    Console.WriteLine("Student updated!");
                    ContinueBreak();
                    break;

                case ConsoleKey.Escape:
                    return false;

            }
            return true;
        }

        static void ContinueBreak()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(intercept: true);
            ClearConsoleFully();
        }

        private static void ClearConsoleFully()
        {
            try
            {
                Console.Write("\u001b[3J\u001b[H\u001b[2J");
                Console.Clear();
            }
            catch
            {
                int lines = Console.WindowHeight > 0 ? Console.WindowHeight : 50;
                for (int i = 0; i < lines; i++)
                {
                    Console.WriteLine();
                }
                Console.Clear();
            }
        }
    }
}
