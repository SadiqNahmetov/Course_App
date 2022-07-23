using CourseApplication.Controllers;
using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;

namespace CourseApplication
{
    class Program
    {
        static void Main(string[] args)
        {
           
            GroupController groupController = new GroupController();

            StudentController studentController = new StudentController();

            Helper.WriteConsole(ConsoleColor.Blue, "Select one option: ");

            GetMenues();

            while (true)
            {
            SelectOption : string selectOption = Console.ReadLine();
                int selectTrueOption;
                bool isSelectOption = int.TryParse(selectOption, out selectTrueOption);

                if (isSelectOption)
                {
                    switch (selectTrueOption)
                    {
                        case (int)Menues.CreateGroup:

                            groupController.Create();
                            break;

                        case (int)Menues.GetGroupById:

                            groupController.GetById();
                            break;


                        case (int)Menues.UpdateGroup:

                            groupController.Update();
                            break;


                        case (int)Menues.DeleteGroup:

                            groupController.Delete();
                            break;

                        case (int)Menues.GetAllGroups:

                            groupController.GetAll();
                            break;

                        case (int)Menues.SearchForGroupsByTeacherName:
                            
                            groupController.SearchByTeacherName();
                            break;

                        case (int)Menues.GetAllGroupsByRoom:

                             groupController.GetAllByRoom();
                             break;

                        case (int)Menues.SearchMethodForGroupsByName:

                            groupController.SearchByName();
                             break;

                           
                            // Student

                        case (int)Menues.CreateStudent:

                           studentController.Create();
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
        private static void GetMenues()
        {
            Helper.WriteConsole(ConsoleColor.Yellow, "1 - Create Group, 2 - Get group by id , 3 - Update group, 4 - Delete Group," +
              " 5 - Get all groups, 6 - Search for groups by teacher name, 7 - Get all groups by room," +
              " 8 - Search method for groups by name , 9 - Create Student");
        }
    }
}
