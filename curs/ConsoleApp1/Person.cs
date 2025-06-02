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
            persAge = int.Parse(Console.ReadLine());

            Console.WriteLine("Введіть зріст");
            persHeight = double.Parse(Console.ReadLine());
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
