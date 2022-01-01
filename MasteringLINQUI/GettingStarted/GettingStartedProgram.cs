using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasteringLINQUI.GettingStarted
{
    public class Params : IEnumerable<int>
    {
        private int a, b, c;

        public Params(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public IEnumerator<int> GetEnumerator()
        {
            yield return a;
            yield return b;
            yield return c;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Person
    {
        private string firstName, middleName, lastName;

        public Person(string firstName, string middleName, string lastName)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
        }

        public IEnumerable<string> Names
        {
            get
            {
                yield return firstName;
                yield return middleName;
                //yield break; --> stop the iteration
                yield return lastName;
            }
        }
    }

    public class GettingStartedProgram
    {
        public static void Run()
        {
            var p = new Params(1, 2, 3);

            foreach (var x in p)
            {
                Console.WriteLine(x);
            }

            var person = new Person("Manuel", "Vicente", "Perez");
            foreach (var name in person.Names)
            {
                Console.WriteLine(name);
            }
        }

        public static IEnumerable<int> Merge(IEnumerable<int> a, IEnumerable<int> b)
        {
            return a.Except(b);
        }

        public static int Poly(int x, IEnumerable<int> coeffs)
        {
            int exp = coeffs.Count() - 1;
            return coeffs.Aggregate(0, (acc, b) => acc + b * (int)Math.Pow(x, exp--));
        }
    }
}
