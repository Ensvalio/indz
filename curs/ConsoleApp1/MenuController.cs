using System;
using System.Collections.Generic;

namespace ConsoleApp1 {
    public class MenuController {
        private List<Student> students = new List<Student>();
        private List<Teacher> teachers = new List<Teacher>();

        public void Run() {
            bool exit = false;
            while (!exit) {
                Console.Clear();
                Console.WriteLine("===== Управління школою =====");
                Console.WriteLine("1. Додати учня");
                Console.WriteLine("2. Додати вчителя");
                Console.WriteLine("3. Додати оцінку учневі");
                Console.WriteLine("4. Інформація про учня");
                Console.WriteLine("5. Інформація про вчителя");
                Console.WriteLine("6. Додати учня вчителю");
                Console.WriteLine("7. Розрахувати підсумкову оцінку учня");
                Console.WriteLine("8. Список усіх учнів");
                Console.WriteLine("9. Список усіх учителів");
                Console.WriteLine("0. Вихід");
                Console.Write("Виберіть дію: ");

                try {
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice) {
                        case 1: AddStudent(); break;
                        case 2: AddTeacher(); break;
                        case 3: AddMarkToStudent(); break;
                        case 4: ShowStudentInfo(); break;
                        case 5: ShowTeacherInfo(); break;
                        case 6: AssignStudentToTeacher(); break;
                        case 7: CalculateFinalMark(); break;
                        case 8: ShowAllStudents(); break;
                        case 9: ShowAllTeachers(); break;
                        case 0: exit = true; break;
                        default: Pause("Неправильний вибір."); break;
                    }
                }
                catch {
                    Pause("Неправильне введення.");
                }
            }
        }

        private void Pause(string message = "Натисніть будь-яку клавішу...") {
            Console.WriteLine(message);
            Console.ReadKey();
        }

        private void AddStudent() {
            Console.Clear();
            Console.WriteLine("===== Додавання нового учня =====");
            Console.Write("Введіть повне ім'я учня: ");
            string name = Console.ReadLine();

            try {
                Console.Write("Введіть вік: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Введіть зріст (в см): ");
                double height = double.Parse(Console.ReadLine());

                Console.Write("Введіть клас учня: ");
                string grade = Console.ReadLine();

                students.Add(new Student(name, age, height, grade));
                Pause("Учень успішно доданий.");
            }
            catch {
                Pause("Некоректне введення даних.");
            }
        }

        private void AddTeacher() {
            Console.Clear();
            Console.WriteLine("===== Додавання нового вчителя =====");
            Console.Write("Введіть повне ім'я вчителя: ");
            string name = Console.ReadLine();

            try {
                Console.Write("Введіть вік: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Введіть зріст (в см): ");
                double height = double.Parse(Console.ReadLine());

                Console.Write("Введіть предмет вчителя: ");
                string subject = Console.ReadLine();

                teachers.Add(new Teacher(name, age, height, subject));
                Pause("Вчитель успішно доданий.");
            }
            catch {
                Pause("Некоректне введення даних.");
            }
        }

        private void AddMarkToStudent() {
            if (students.Count == 0) {
                Pause("Немає доданих учнів.");
                return;
            }
            if (teachers.Count == 0) {
                Pause("Не можна додати оцінку, немає вчителів.");
                return;
            }

            Console.Clear();
            Console.WriteLine("===== Додавання оцінки учневі =====");
            ShowStudentsList();

            try {
                Console.Write("Введіть номер учня: ");
                int studentIndex = int.Parse(Console.ReadLine());
                if (!IsValidIndex(studentIndex, students.Count)) throw new Exception();

                Student student = students[studentIndex - 1];

                List<string> subjects = new List<string>();
                foreach (var teacher in teachers) {
                    string subj = teacher.GetSubject();
                    if (!string.IsNullOrWhiteSpace(subj) && !subjects.Contains(subj))
                        subjects.Add(subj);
                }

                if (subjects.Count == 0) {
                    Pause("Немає доступних предметів для оцінки.");
                    return;
                }

                Console.WriteLine("Виберіть предмет:");
                for (int i = 0; i < subjects.Count; i++) {
                    Console.WriteLine($"{i + 1}. {subjects[i]}");
                }

                Console.Write("Введіть номер предмету: ");
                int subjectIndex = int.Parse(Console.ReadLine());
                if (!IsValidIndex(subjectIndex, subjects.Count)) throw new Exception();

                string subject = subjects[subjectIndex - 1];

                Console.WriteLine("Виберіть тип оцінки:\n1. Домашня\n2. Контрольна \n3. Самостійна \n4. Іспит \n5. Підсумкова");
                Console.Write("Введіть тип оцінки:");
                int typeChoice = int.Parse(Console.ReadLine());
                if (typeChoice < 1 || typeChoice > 5) throw new Exception();

                Console.Write("Введіть оцінку (від 0 до 100): ");
                int markValue = int.Parse(Console.ReadLine());
                if (markValue < 0 || markValue > 100) throw new Exception();

                SchoolMark mark = new SchoolMark(subject, (SchoolMark.MarkType)(typeChoice - 1), markValue);
                student.AddMark(mark);
                Pause("Оцінку успішно додано.");
            }
            catch {
                Pause("Помилка при додаванні оцінки.");
            }
        }

        private void ShowStudentInfo() {
            if (students.Count == 0) {
                Pause("Немає доданих учнів.");
                return;
            }

            Console.Clear();
            Console.WriteLine("===== Інформація про учня =====");
            ShowStudentsList();

            try {
                Console.Write("Введіть номер учня: ");
                int index = int.Parse(Console.ReadLine());
                if (!IsValidIndex(index, students.Count)) throw new Exception();

                Console.Clear();
                students[index - 1].PersonInfo();
                Pause();
            }
            catch {
                Pause("Некоректний номер учня.");
            }
        }

        private void ShowTeacherInfo() {
            if (teachers.Count == 0) {
                Pause("Немає доданих вчителів.");
                return;
            }

            Console.Clear();
            Console.WriteLine("===== Інформація про вчителя =====");
            ShowTeachersList();

            try {
                Console.Write("Введіть номер вчителя: ");
                int index = int.Parse(Console.ReadLine());
                if (!IsValidIndex(index, teachers.Count)) throw new Exception();

                Console.Clear();
                teachers[index - 1].PersonInfo();
                teachers[index - 1].PrintStudents();
                Pause();
            }
            catch {
                Pause("Некоректний номер вчителя.");
            }
        }

        private void AssignStudentToTeacher() {
            if (students.Count == 0 || teachers.Count == 0) {
                Pause("Недостатньо даних.");
                return;
            }

            Console.Clear();
            Console.WriteLine("===== Призначення учня вчителю =====");
            ShowStudentsList();

            try {
                Console.Write("Введіть номер учня: ");
                int studentIndex = int.Parse(Console.ReadLine());
                if (!IsValidIndex(studentIndex, students.Count)) throw new Exception();

                ShowTeachersList();
                Console.Write("Введіть номер вчителя: ");
                int teacherIndex = int.Parse(Console.ReadLine());
                if (!IsValidIndex(teacherIndex, teachers.Count)) throw new Exception();

                var student = students[studentIndex - 1];
                var teacher = teachers[teacherIndex - 1];
                teacher.AddStudent(student);
                Pause($"Учень {student.GetStudentName()} впризначений вчителю {teacher.GetPersName()}.");
            }
            catch {
                Pause("Помилка при призначенні учня вчителю.");
            }
        }

        private void CalculateFinalMark() {
            if (students.Count == 0) {
                Pause("Немає учнів.");
                return;
            }

            if (teachers.Count == 0) {
                Pause("Немає вчителів, неможливо визначити предмети.");
                return;
            }

            Console.Clear();
            Console.WriteLine("===== Підсумкова оцінка =====");
            ShowStudentsList();

            try {
                Console.Write("Введіть номер учня: ");
                int index = int.Parse(Console.ReadLine());
                if (!IsValidIndex(index, students.Count)) throw new Exception();

                var student = students[index - 1];

                List<string> subjects = new List<string>();
                foreach (var teacher in teachers) {
                    string subj = teacher.GetSubject();
                    if (!string.IsNullOrWhiteSpace(subj) && !subjects.Contains(subj))
                        subjects.Add(subj);
                }

                if (subjects.Count == 0) {
                    Pause("Немає доступних предметів для розрахунку оцінки.");
                    return;
                }

                Console.WriteLine("Виберіть предмет:");
                for (int i = 0; i < subjects.Count; i++) {
                    Console.WriteLine($"{i + 1}. {subjects[i]}");
                }

                Console.Write("Введіть номер предмету: ");
                int subjectIndex = int.Parse(Console.ReadLine());
                if (!IsValidIndex(subjectIndex, subjects.Count)) throw new Exception();

                string subject = subjects[subjectIndex - 1];

                double finalMark = student.GetFinalMark(subject);
                Pause($"Загальна оцінка по {subject}: {finalMark}");
            }
            catch {
                Pause("Помилка при розрахунку підсумкової оцінки.");
            }
        }

        private void ShowAllStudents() {
            Console.Clear();
            Console.WriteLine("===== Усі учні =====");
            if (students.Count == 0) {
                Console.WriteLine("Немає учнів.");
            }
            else ShowStudentsList();
            Pause();
        }

        private void ShowAllTeachers() {
            Console.Clear();
            Console.WriteLine("===== Все учителя =====");
            if (teachers.Count == 0) {
                Console.WriteLine("Немає вчителів.");
            }
            else ShowTeachersList();
            Pause();
        }

        private void ShowStudentsList() {
            for (int i = 0; i < students.Count; i++) {
                Console.WriteLine($"{i + 1}. {students[i].GetStudentName()}, клас: {students[i].GetStudentGrade()}");
            }
        }

        private void ShowTeachersList() {
            for (int i = 0; i < teachers.Count; i++) {
                Console.WriteLine($"{i + 1}. {teachers[i].GetPersName()}, предмет: {teachers[i].GetSubject()}");
            }
        }

        private bool IsValidIndex(int index, int count) => index > 0 && index <= count;
    }
}
