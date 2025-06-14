using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1 {
    abstract class Person {
        private string persName;
        private int persAge;
        private double persHeight;
        
        public Person(string persName, int persAge, double persHeight) {
            this.persName = persName;
            this.persAge = persAge;
            this.persHeight = persHeight;
        }

        public virtual void InputPersInfo() {
            Console.WriteLine("Введіть повне ім'я: ");
            persName = Console.ReadLine();

            Console.WriteLine("Введіть вік: ");
            if (!int.TryParse(Console.ReadLine(), out int age)) {
                Console.WriteLine("Невірний формат віку. Встановлено 0.");
                persAge = 0;
            } else {
                persAge = age;
            }

            Console.WriteLine("Введіть зріст");
            if (!double.TryParse(Console.ReadLine(), out double height)) {
                Console.WriteLine("Невірний формат зросту. Встановлено 0.");
                persHeight = 0;
            } else {
                persHeight = height;
            }
        }

        public virtual void PersonInfo() {
            Console.WriteLine($"Повне ім'я: {persName}, вік: {persAge}, зріст: {persHeight}");
        }

        public string GetPersName() {
            return persName;
        }

        public int GetPersAge() {
            return persAge;
        }

        public double GetPersHeight() {
            return persHeight;
        }
    }
}
