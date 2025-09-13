using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab01_02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Hiển thị danh sách sinh viên");
                Console.WriteLine("3. Sinh viên khoa CNTT");
                Console.WriteLine("4. Sinh viên có điểm TB >= 5");
                Console.WriteLine("5. Sắp xếp theo điểm TB tăng dần");
                Console.WriteLine("6. Sinh viên CNTT có điểm TB >= 5");
                Console.WriteLine("7. Sinh viên CNTT có điểm TB cao nhất");
                Console.WriteLine("8. Thống kê xếp loại");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng (0-8): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(studentList);
                        break;
                    case "2":
                        DisplayStudentList(studentList);
                        break;
                    case "3":
                        DisplayStudentsByFaculty(studentList, "CNTT");
                        break;
                    case "4":
                        DisplayStudentsWithHighAverageScore(studentList, 5);
                        break;
                    case "5":
                        SortStudentsByAverageScore(studentList);
                        break;
                    case "6":
                        DisplayStudentsByFacultyAndScore(studentList, "CNTT", 5);
                        break;
                    case "7":
                        DisplayStudentsWithHighestAverageScoreByFaculty(studentList, "CNTT");
                        break;
                    case "8":
                        CountStudentsByGrade(studentList);
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Kết thúc chương trình.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            }
        }

        static void AddStudent(List<Student> studentList)
        {
            Console.WriteLine("=== Nhập thông tin sinh viên ===");
            Student student = new Student();
            student.Input();
            studentList.Add(student);
            Console.WriteLine("Thêm sinh viên thành công!");
        }

        static void DisplayStudentList(List<Student> studentList)
        {
            Console.WriteLine("=== Danh sách sinh viên ===");
            foreach (Student student in studentList)
                student.Show();
        }

        static void DisplayStudentsByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine($"=== Sinh viên khoa {faculty} ===");
            var students = studentList.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase));
            foreach (var s in students) s.Show();
        }

        static void DisplayStudentsWithHighAverageScore(List<Student> studentList, float minDTB)
        {
            Console.WriteLine($"=== Sinh viên có điểm TB >= {minDTB} ===");
            var students = studentList.Where(s => s.AverageScore >= minDTB);
            foreach (var s in students) s.Show();
        }

        static void SortStudentsByAverageScore(List<Student> studentList)
        {
            Console.WriteLine("=== Danh sách sắp xếp theo điểm TB tăng dần ===");
            var sorted = studentList.OrderBy(s => s.AverageScore).ToList();
            foreach (var s in sorted) s.Show();
        }

        static void DisplayStudentsByFacultyAndScore(List<Student> studentList, string faculty, float minDTB)
        {
            Console.WriteLine($"=== Sinh viên khoa {faculty} có điểm TB >= {minDTB} ===");
            var students = studentList.Where(s => s.AverageScore >= minDTB
                                               && s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase));
            foreach (var s in students) s.Show();
        }

        static void DisplayStudentsWithHighestAverageScoreByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine($"=== Sinh viên khoa {faculty} có điểm TB cao nhất ===");
            var maxScore = studentList.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase))
                                      .Max(s => s.AverageScore);
            var topStudents = studentList.Where(s => s.AverageScore == maxScore && s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase));
            foreach (var s in topStudents) s.Show();
        }

        static void CountStudentsByGrade(List<Student> studentList)
        {
            Console.WriteLine("=== Thống kê xếp loại sinh viên ===");
            var result = studentList.GroupBy(s =>
            {
                if (s.AverageScore >= 9) return "Xuất sắc";
                else if (s.AverageScore >= 8) return "Giỏi";
                else if (s.AverageScore >= 7) return "Khá";
                else if (s.AverageScore >= 5) return "Trung bình";
                else if (s.AverageScore >= 4) return "Yếu";
                else return "Kém";
            })
            .Select(g => new { Grade = g.Key, Count = g.Count() });

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Grade}: {item.Count} sinh viên");
            }
        }
    }
}
