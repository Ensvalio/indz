using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Student : Person {
        private List<SchoolMark> marks = new List<SchoolMark>();
        private string studentGrade;

        public Student(string persName, int persAge, double persHeight, string studentGrade)
            : base(persName, persAge, persHeight) {
            this.studentGrade = studentGrade;
            marks = new List<SchoolMark>();
        }

        public void PrintMarks() {
            Console.WriteLine("Список оцінок: ");
            if (marks.Count == 0) {
                Console.WriteLine("Оцінок немає");
                return;
            }

            foreach (var mark in marks) {
                mark.MarkPrint();
            }
        }

        public override void PersonInfo() {
            base.PersonInfo();
            Console.WriteLine($"Клас: {studentGrade}");
            PrintMarks();
        }

        public void AddMark(SchoolMark schoolMark) {
            marks.Add(schoolMark);
        }

        public string GetStudentName() {
            return GetPersName();
        }
        public string GetStudentGrade() {
            return studentGrade;
        }

        public double GetFinalMark(string subject) {
            var subjectMarks = marks.Where(m => m.subject == subject).ToList();
            if (subjectMarks.Count == 0) {
                Console.WriteLine("Оцінок немає");
                return 0;
            }
            
            var examMark = subjectMarks.FirstOrDefault(m => m.type == SchoolMark.MarkType.Экзамен);
            double exam = examMark != null ? (examMark.markValue * 0.25) : 0; 
            
            var regularMarks = subjectMarks.Where(m =>
                m.type == SchoolMark.MarkType.Домашняя ||
                m.type == SchoolMark.MarkType.Самостоятельная ||
                m.type == SchoolMark.MarkType.Контрольная).ToList();
            
            double homeworkPoints = 0;
            double controlPoints = 0;
            double independentPoints = 0;

            foreach (var mark in regularMarks) {
                double points = mark.markValue * 0.25; 
                switch (mark.type) {
                    case SchoolMark.MarkType.Домашняя:
                        homeworkPoints = Math.Max(homeworkPoints, points);
                        break;
                    case SchoolMark.MarkType.Контрольная:
                        controlPoints = Math.Max(controlPoints, points);
                        break;
                    case SchoolMark.MarkType.Самостоятельная:
                        independentPoints = Math.Max(independentPoints, points);
                        break;
                }
            }
            
            double totalPoints = Math.Min(homeworkPoints + controlPoints + independentPoints, 75) + exam;
            return Math.Round(totalPoints, 2);
        }

    }
}
