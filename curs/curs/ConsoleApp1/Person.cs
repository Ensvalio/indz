using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1 {
    abstract class Person {
        private string persName;
        private int persAge;
        private double persHeight;
        
        protected Person() { }
        
        public Person(string persName, int persAge, double persHeight) {
            this.persName = persName;
            this.persAge = persAge;
            this.persHeight = persHeight;
        }

        public virtual void InputPersInfo() {
            do {
                Console.WriteLine("Введіть повне ім'я: ");
                persName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(persName)) {
                    Console.WriteLine("Ім'я не може бути пустим!");
                }
                else if (int.TryParse(persName, out _)) {
                    Console.WriteLine("Ім'я не може бути числом!");
                    persName = string.Empty;
                }
            } while (string.IsNullOrWhiteSpace(persName));

            Console.WriteLine("Введіть вік: ");
            while (!int.TryParse(Console.ReadLine(), out persAge) || persAge <= 0) {
                Console.WriteLine("Невірний формат віку. Будь ласка, введіть додатне число.");
                Console.Write("Введіть вік: ");
            }

            Console.WriteLine("Введіть зріст");
            while (!double.TryParse(Console.ReadLine(), out persHeight) || persHeight <= 0) {
                Console.WriteLine("Невірний формат зросту. Будь ласка, введіть додатне число.");
                Console.Write("Введіть зріст: ");
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
