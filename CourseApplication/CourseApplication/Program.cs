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
            GroupService groupService = new GroupService();

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
                            Helper.WriteConsole(ConsoleColor.Blue, "Add group name: ");
                            string groupName = Console.ReadLine();

                            Helper.WriteConsole(ConsoleColor.Blue, "Add teacher name: ");

                            TeachName: string groupTeacherName = Console.ReadLine();
                           

                            foreach (var item in groupTeacherName)
                            {
                                for (int i = 0; i <= 9; i++)
                                {
                                    if (item.ToString() == i.ToString())
                                    {
                                        Helper.WriteConsole(ConsoleColor.Red, "Please add correct teacher name : ");
                                        goto TeachName;
                                    }
                                                                   
                                }
                            }

                            Helper.WriteConsole(ConsoleColor.Blue, "Add room name: ");
                            string roomName = Console.ReadLine();

                            Group group = new Group
                            {
                                Name = groupName,
                                Teacher = groupTeacherName,
                                Room = roomName
                            };
                            

                            var result = groupService.Create(group);
                            Helper.WriteConsole(ConsoleColor.Green, $"Group id : {result.Id}, Group name : {result.Name}, Teacher name : {result.Teacher}, Room name : {result.Room}");
                            break;

                        case (int)Menues.GetGroupById:
                            Helper.WriteConsole(ConsoleColor.Blue, "Add group id : ");
                        GroupId : string groupId = Console.ReadLine();
                            int id;

                            bool isGroupId = int.TryParse(groupId, out id);

                            if (isGroupId)
                            {
                                Group group1 = groupService.GetById(id);
                                if (group1 != null)
                                {
                                    Helper.WriteConsole(ConsoleColor.Green, $"Group id : {group1.Id}, Group name : {group1.Name}, Teacher name : {group1.Teacher}, Room name : {group1.Room}");
                                }
                                else
                                {
                                    Helper.WriteConsole(ConsoleColor.Red, "Group not found : ");
                                    goto GroupId; 
                                }
                               
                            }
                            else
                            {
                                Helper.WriteConsole(ConsoleColor.Red, "Select correct id type: ");
                                goto GroupId;
                            }
                            break;


                        case (int)Menues.UpdateGroup:
                            Console.WriteLine(selectTrueOption);
                            break;


                        case (int)Menues.DeleteGroup:
                            Console.WriteLine(selectTrueOption);
                            break;

                        case (int)Menues.GetAllGroups:
                            List<Group> groups = groupService.GetAll();
                            foreach (var item in groups)
                            {
                                Helper.WriteConsole(ConsoleColor.Green, $"Group id : {item.Id}, Group name : {item.Name}, Teacher name : {item.Teacher}, Room name : {item.Room}");
                            }


                            break;

                        case (int)Menues.SearchForGroupsByTeacherName:

                            Helper.WriteConsole(ConsoleColor.Blue, "Search group by teacher's name: ");
                            SearchText : string searchTeacherName = Console.ReadLine();

                            List<Group> resultTeachers = groupService.GetAllByTeacherName(searchTeacherName);
                            if (resultTeachers.Count != 0)
                            {

                                foreach (var item in resultTeachers)
                                {
                                    Helper.WriteConsole(ConsoleColor.Green, $"Group id : {item.Id}, Group name : {item.Name}, Teacher name : {item.Teacher}, Room name : {item.Room}");
                                }
                            }
                            else
                            {
                                Helper.WriteConsole(ConsoleColor.Red, "Teacher name not found : ");
                                goto SearchText;
                            }

                         break;

                        case (int)Menues.GetAllGroupsByRoom:

                            Helper.WriteConsole(ConsoleColor.Blue, "Search group by room's name : ");
                           SearchRoom: string searcRoomName = Console.ReadLine();

                            List<Group> resultRooms = groupService.GetAllByRoom(searcRoomName);
                            if (resultRooms.Count != 0)
                            {

                                foreach (var item in resultRooms)
                                {
                                    Helper.WriteConsole(ConsoleColor.Green, $"Group id : {item.Id}, Group name : {item.Name}, Teacher name : {item.Teacher}, Room name : {item.Room}");
                                }
                            }
                            else
                            {
                                Helper.WriteConsole(ConsoleColor.Red, "Room name not found : ");
                                goto SearchRoom;
                            }


                            break;

                        case (int)Menues.SearchMethodForGroupsByName:

                            Helper.WriteConsole(ConsoleColor.Blue, " Search group by name : ");
                            SearchByName: string groupsByName = Console.ReadLine();

                            List<Group> resultsearch = groupService.SearchGroupByNames(groupsByName);
                            if (resultsearch.Count != 0)
                            {

                                foreach (var item in resultsearch)
                                {
                                    Helper.WriteConsole(ConsoleColor.Green, $"Group id : {item.Id}, Group name : {item.Name}, Teacher name : {item.Teacher}, Room name : {item.Room}");
                                }
                            }
                            else
                            {
                                Helper.WriteConsole(ConsoleColor.Red, "Group name not found : ");
                                goto SearchByName;
                            }


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
              " 8 - Search method for groups by name");
        }
    }
}
