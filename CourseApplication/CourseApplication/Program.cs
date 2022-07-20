using Service.Helpers;
using System;

namespace CourseApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Select one option: ");
            Helper.WriteConsole(ConsoleColor.Yellow, "1 - Create Group, 2 - Update group, 3 - Delete Group, 4 - Get group by id");

            while (true)
            {
            SelectOption : string selectOption = Console.ReadLine();
                int selectTrueOption;
                bool isSelectOption = int.TryParse(selectOption, out selectTrueOption);

                if (isSelectOption)
                {
                    switch (selectTrueOption)
                    {
                        case 1:
                            Helper.WriteConsole(ConsoleColor.Blue, "Add group name: ");
                            string groupName = Console.ReadLine();

                            Helper.WriteConsole(ConsoleColor.Blue, "Add teacher name: ");

                            string groupTeacher = Console.ReadLine();
                            string teacherCount;
                            
                            break;

                        case 2:
                            Console.WriteLine(selectTrueOption);
                            break;


                        case 3:
                            Console.WriteLine(selectTrueOption);
                            break;


                        case 4:
                            Console.WriteLine(selectTrueOption);
                            break;

                        default:
                            Helper.WriteConsole(ConsoleColor.Red, "Select correct option number: ");
                            break;
                    }
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Select correct option: ");
                    goto SelectOption;
                }
            }
        }
    }
}
