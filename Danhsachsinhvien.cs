using System;

namespace Lab01_02
{
    class Student
    {
        private string studentID;
        private string fullName;
        private float averageScore;
        private string faculty;

        public string StudentID { get => studentID; set => studentID = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public float AverageScore { get => averageScore; set => averageScore = value; }
        public string Faculty { get => faculty; set => faculty = value; }

        public Student() { }

        public Student(string studentID, string fullName, float averageScore, string faculty)
        {
            this.studentID = studentID;
            this.fullName = fullName;
            this.averageScore = averageScore;
            this.faculty = faculty;
        }

        public void Input()
        {
            Console.Write("Nhập MSSV: ");
            StudentID = Console.ReadLine();
            Console.Write("Nhập Họ tên: ");
            FullName = Console.ReadLine();
            Console.Write("Nhập Điểm TB: ");
            AverageScore = float.Parse(Console.ReadLine());
            Console.Write("Nhập Khoa: ");
            Faculty = Console.ReadLine();
        }

        public void Show()
        {
            Console.WriteLine("MSSV:{0} | Họ Tên:{1} | Khoa:{2} | ĐiểmTB:{3}",
                this.StudentID, this.FullName, this.Faculty, this.AverageScore);
        }
    }
}
