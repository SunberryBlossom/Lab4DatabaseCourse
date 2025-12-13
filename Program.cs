using Lab4.Business.DTOs;
using Lab4.Business.Services;
using Lab4.Data;
using Lab4.Data.Interfaces;
using Lab4.Data.Repositories;

namespace Lab4
{
    internal class Program
    {
        static StaffService staffService;
        static void Main(string[] args)
        {
            using (var context = new Lab4DBContext())
            {
                // initializing everything needed from other layers
                var staffRepository = new StaffRepository(context);
                var departmentRepository = new DepartmentRepository(context);

                staffService = new StaffService(staffRepository, departmentRepository);

                RunApplication();
            }
        }

        static void RunApplication()
        {
            bool appIsRunning = true;

            while (appIsRunning)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                StartupMenu();
                MenuChoice();
                
            }
        }

        static void StartupMenu()
        {
            Console.Clear();
            Console.WriteLine("The middle-earth:ian learning center");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("\nChoose what must be done:");
            Console.WriteLine("[1] Show how many teachers are currenly working in each department");
            Console.WriteLine();

        }

        static void MenuChoice()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    List<DepartmentTeacherCountDto> departmentTeacherList = staffService.AmountOfTeachersPerDepartment();
                    Console.Clear();

                    foreach (var item in departmentTeacherList)
                    {
                        Console.WriteLine($"{item.DepartmentTitle}: {item.NumberOfTeachers} teacher(s)");
                    }
                    ContinueBreak();
                    break;
            }
        }

        static void ContinueBreak()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
