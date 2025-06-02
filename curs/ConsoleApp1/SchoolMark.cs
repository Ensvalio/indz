using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class SchoolMark {
        public enum MarkType {
            Домашняя, 
            Контрольная, 
            Самостоятельная, 
            Экзамен, 
            Итоговая
        }
        public string subject { get; private set; }
        public MarkType type { get; private set; }
        public int markValue { get; private set; }

        public SchoolMark(string subject, MarkType type, int markValue) {
            this.subject = subject;
            this.type = type;
            this.markValue = markValue;
            if (markValue < 0 || markValue > 100) {
                throw new ArgumentException("Оцінка не може бути менша за 0 та більша за 100");
            }

            if (string.IsNullOrWhiteSpace(subject)) {
                throw new ArgumentException("Назва предмету не може бути пустою");
            }
        }

        public void MarkPrint()
        {
            Console.WriteLine($"Предмет: {subject}, тип: {type}, Оцінка: {markValue}");
        }
    }

}
