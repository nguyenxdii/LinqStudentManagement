using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagement
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>
            {
                new Student{ Id =1,  Name = "Ti",    Age = 12},
                new Student{ Id =2,  Name = "Suu",   Age = 14},
                new Student{ Id =3,  Name = "Dan",   Age = 16},
                new Student{ Id =4,  Name = "Mao",   Age = 18},
                new Student{ Id =5,  Name = "Thin",  Age = 20},
                new Student{ Id =6,  Name = "Ty",    Age = 11},
                new Student{ Id =7,  Name = "Ngo",   Age = 13},
                new Student{ Id =8,  Name = "Mui",   Age = 15},
                new Student{ Id =9,  Name = "AThan",  Age = 17},
                new Student{ Id =10, Name = "Dau",   Age = 19},
                new Student{ Id =11, Name = "Tuat",  Age = 21},
                new Student{ Id =12, Name = "Hoi",   Age = 22},
                new Student{ Id =13,  Name = "An",    Age = 22},
                new Student{ Id =13,  Name = "Anh",    Age = 13},
            };

            while (true)
            {

                Console.WriteLine("-------------Menu-------------");
                Console.WriteLine("1. In toan bo danh sach hoc sinh");
                Console.WriteLine("2. In danh sach hoc sinh tuoi tu 15-18");
                Console.WriteLine("3. In hoc sinh co ten bat dau bang chu A");
                Console.WriteLine("4. Tong tuoi cua tat ca hoc sinh");
                Console.WriteLine("5. Hoc sinh co tuoi lon nhat");
                Console.WriteLine("6. Sap xep tuoi hoc sinh tu thap den cao");
                Console.WriteLine("0. Exit");
                Console.Write("Chon: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "0")
                {
                    break;
                }

                switch (choice)
                {
                    case "1":
                        PrintAllStudents(students);
                        break;

                    case "2":
                        PrintStudentsAge15to18(students);
                        break;

                    case "3":
                        PrintStudentsNameStartsWithA(students);
                        break;

                    case "4":
                        CalTotalAge(students);
                        break;
                    case "5":
                        FindMaxAge(students);
                        break;
                    case "6":
                        SortStudentsByAgeAscending(students);
                        break;
                }
            }

            // 1. in toàn bộ danh sách student
            static void PrintAllStudents(List<Student> students)
            {
                var allStudent = from s in students // duyệt từng phần tử trong student
                                 select s;
                Console.WriteLine("----------------------------");
                Console.WriteLine("1. Danh sach hoc sinh: ");
                Console.WriteLine("----------------------------");

                int c = 1;

                foreach (var s in allStudent)
                {
                    Console.WriteLine($"Hoc sinh thu {c}: ");
                    c++;
                    Console.WriteLine($"Ma so hoc sinh: {s.Id}");
                    Console.WriteLine($"Ten hoc sinh: {s.Name}");
                    Console.WriteLine($"Tuoi: {s.Age}");
                    Console.WriteLine();
                }
            }

            // 2. tuoi tu 18-25
            static void PrintStudentsAge15to18(List<Student> students)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine("2. Danh sach hoc sinh tuoi tu 15-18: ");
                Console.WriteLine("-------------------");

                var result = from s in students
                             where s.Age >= 15 && s.Age <= 18   // chỉ giữ lại >= 15 && <= 18
                             select s;

                int c = 1;
                foreach (var s in result)
                {
                    Console.WriteLine($"Hoc sinh thu {c}: ");
                    c++;
                    Console.WriteLine($"Ma so hoc sinh: {s.Id}");
                    Console.WriteLine($"Ten hoc sinh: {s.Name}");
                    Console.WriteLine($"Tuoi: {s.Age}");
                    Console.WriteLine();
                }
            }

            // 3. in hoc sinh co ten bat dau bang chu A
            static void PrintStudentsNameStartsWithA(List<Student> students)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine("Danh sach hoc sinh co ten bat dau tu chu A: ");
                Console.WriteLine("-------------------");

                var result = from s in students
                                 // tên băt đầu bằng A, StringComparison.OrdinalIgnoreCase không phân biệt hoa thường
                             where s.Name.StartsWith("A", StringComparison.OrdinalIgnoreCase)
                             select s;
                int c = 1;
                foreach (var s in result)
                {
                    Console.WriteLine($"Hoc sinh thu {c}: ");
                    c++;
                    Console.WriteLine($"Ma so hoc sinh: {s.Id}");
                    Console.WriteLine($"Ten hoc sinh: {s.Name}");
                    Console.WriteLine($"Tuoi: {s.Age}");
                    Console.WriteLine();
                }
            }

            // 4. tong tuoi cua tat ca hoc sinh
            static void CalTotalAge(List<Student> students)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine("Danh sach tong tuoi cua tat ca hoc sinh: ");
                Console.WriteLine("-------------------");

                var result = from s in students
                                 // test
                                 // where s.Id % 2 != 0 
                                 // chỉ lấy tuổi
                             select s.Age;

                int totalAge = result.Sum();

                Console.WriteLine("Tong tuoi cua tat ca hoc sinh:");
                Console.WriteLine($"Tong = {totalAge}");
                Console.WriteLine();
            }

            // 5. gia` dau` nhat
            static void FindMaxAge(List<Student> students)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine("Hoc sinh co tuoi lon nhat: ");
                Console.WriteLine("-------------------");

                var result = from s in students
                                 // chỉ lấy tuổi
                             select s.Age;

                // tìm giá trị lớn nhất trong ds
                int maxAge = result.Max();

                // duyệt lại 1 lần nữa
                var oldest = from s in students
                                 // giữ lại ai bằng với maxAge
                             where s.Age == maxAge
                             select s;

                int c = 1;

                foreach (var s in oldest)
                {
                    Console.WriteLine($"Hoc sinh thu {c}: ");
                    c++;
                    Console.WriteLine($"Ma so hoc sinh: {s.Id}");
                    Console.WriteLine($"Ten hoc sinh: {s.Name}");
                    Console.WriteLine($"Tuoi: {s.Age}");
                    Console.WriteLine();
                }
            }

            // 6. sap xep theo tuoi tang dan
            static void SortStudentsByAgeAscending(List<Student> students)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine("Danh sach hoc sinh tuoi tu thap den cao");
                Console.WriteLine("-------------------");

                var result = from s in students
                                 // sắp xếp danh sách từ nhỏ đến lớn, ngược lại descending
                             orderby s.Age ascending
                             // giữ nguyên sau khi sắp xếp
                             select s;
                int c = 1;
                foreach (var s in result)
                {
                    Console.WriteLine($"Hoc sinh thu {c}: ");
                    c++;
                    Console.WriteLine($"Ma so hoc sinh: {s.Id}");
                    Console.WriteLine($"Ten hoc sinh: {s.Name}");
                    Console.WriteLine($"Tuoi: {s.Age}");
                    Console.WriteLine();
                }
            }
        }
    }
}