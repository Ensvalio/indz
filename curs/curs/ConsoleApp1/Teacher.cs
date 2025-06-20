using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Teacher : Person {
        private string subject;
        private List<Student> students;
        
        public Teacher(string persName, int persAge, double persHeight, string subject)
            : base(persName, persAge, persHeight) {
            this.subject = subject;
            students = new List<Student>();
        }
        
        public Teacher() : base() {
            students = new List<Student>();
        }
        
        public override void InputPersInfo(){
            base.InputPersInfo();
            do {
                Console.Write("Введіть предмет вчителя: ");
                subject = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(subject)) {
                    Console.WriteLine("Предмет не може бути пустим!");
                }
                else if (int.TryParse(subject, out _)) {
                    Console.WriteLine("Предмет не може бути числом!");
                    subject = string.Empty;
                }
            } while (string.IsNullOrWhiteSpace(subject));
        }
        
        public override void PersonInfo()
        {
            base.PersonInfo();
            Console.WriteLine($"Предмет: {subject}");
            Console.WriteLine($"Кількість учнів: {students.Count}");
        }
        
        public void AddStudent(Student student)
        {
            if (student != null && !students.Contains(student))
            {
                students.Add(student);
            }
        }
        
        public void RemoveStudent(Student student)
        {
            students.Remove(student);
        }
        
        public List<Student> GetStudents()
        {
            return students;
        }
        
        public void PrintStudents()
        {
            Console.WriteLine($"Список учнів викладача {GetPersName()} з предмету {subject}:");
            if (students.Count == 0)
            {
                Console.WriteLine("Учнів немає");
                return;
            }

            foreach (var student in students)
            {
                Console.WriteLine($"{student.GetStudentName()}, класс: {student.GetStudentGrade()}");
            }
        }
        
        public string GetSubject()
        {
            return subject;
        }
        
        public double GetAverageMark()
        {
            List<int> allMarks = new List<int>();
            foreach (var student in students) {
                List<SchoolMark> studentMarks = student.GetMarks();
                foreach (var mark in studentMarks) {
                    if (mark.subject == subject) {
                        allMarks.Add(mark.markValue);
                    }
                }
            }

            if (allMarks.Count == 0) {
                Console.WriteLine("Вчитель ще не виставив оцінки");   
            }
            return allMarks.Average();
        }
    }
}
