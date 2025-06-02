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
            var regMarks = subjectMarks.Where(m =>
                m.type == SchoolMark.MarkType.Домашняя ||
                m.type == SchoolMark.MarkType.Самостоятельная ||
                m.type == SchoolMark.MarkType.Контрольная).ToList();
            double exam = examMark != null ? examMark.markValue : 0;
            double regMarksAvg = regMarks.Count > 0 ? regMarks.Average(m => m.markValue) : 0;

            if (regMarks.Count > 0 && examMark != null) {
                return Math.Round(regMarksAvg * 0.75 + exam * 0.25, 2);
            }
            else if (regMarks.Count > 0) {
                return Math.Round(regMarksAvg * 0.75, 2);
            }
            else {
                return exam;
            }
        }

    }
}
