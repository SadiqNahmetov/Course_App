using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApplication.Controllers
{
    public class StudentController
    {
        StudentService studentService = new StudentService();
        GroupService groupService = new GroupService();
        public void Create()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add group id: ");
           GroupId: string groupId = Console.ReadLine();
            int selectedGroupId;

            bool isSelectedId = int.TryParse(groupId, out selectedGroupId);

            var datas = groupService.GetById(selectedGroupId);
            if (datas != null)
            {
                if (isSelectedId)
                {
                    Helper.WriteConsole(ConsoleColor.Blue, "Add student name: ");

                    string studentName = Console.ReadLine();
                    for (int i = 0; i <= 9; i++)
                    {
                        if (studentName.Contains(i.ToString()))
                        {
                            Helper.WriteConsole(ConsoleColor.Red, "Please correct name: ");
                            goto surneme;
                        }

                    }



                    Helper.WriteConsole(ConsoleColor.Blue, "Add student surname: ");

                surneme: string studentSurName = Console.ReadLine();
                    for (int i = 0; i <= 9; i++)
                    {
                        if (studentSurName.Contains(i.ToString()))
                        {
                            Helper.WriteConsole(ConsoleColor.Red, "Please correct  surname: ");
                            goto surneme;
                        }

                    }
                    Helper.WriteConsole(ConsoleColor.Blue, "Add student age: ");

                    Age: string studentAge = Console.ReadLine();

                    int age;
                    bool isAge = int.TryParse(studentAge, out age);

                    if (isAge)
                    {
                        Student student = new Student()
                        {
                            Name = studentName,
                            Surname = studentSurName,
                            Age = age
                        };
                        var result = studentService.Create(selectedGroupId, student);
                        if (result != null)
                        {
                            Helper.WriteConsole(ConsoleColor.Green, $" Student name : {result.Id}, Studen name : {result.Name},Student surname : {result.Surname}, Student age : {result.Age}, Student group : {result.Group.Name}");
                        }
                        else
                        {
                            Helper.WriteConsole(ConsoleColor.Red, "Add correct student age: ");
                            goto Age;
                        }
                    }
                    else
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Add correct student age type: ");
                        goto Age;
                    }

                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Add correct group id type: ");
                    goto GroupId;
                }

            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct group id: ");
                goto GroupId;
            }
          









        }

    }
}
