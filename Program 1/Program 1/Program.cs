using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_1
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryBook book1 = new LibraryBook("fish", "dog", "alex", 142, 2, "123");
            LibraryMovie m1 = new LibraryMovie("1", "2", 1995, 5, "12345", 60, "person", LibraryMovie.MediaType.CD, LibraryMovie.MPAARating.G);

            LibraryPatron p1 = new LibraryPatron("fizz", "666");

            List<LibraryBook> book = new List<LibraryBook> { book1 };
            List<LibraryMovie> movie = new List<LibraryMovie> { m1 };

            void Print(List<LibraryBook> books)
            {
                foreach (LibraryBook b in books)
                {
                    Console.WriteLine(b);
                    Console.WriteLine();
                }
            }

             void print (List<LibraryMovie> movies)
            {
                foreach (LibraryMovie m in movies)
                {
                    Console.WriteLine(m);
                    Console.WriteLine();
                }
            }

            print(movie);

            m1.CheckOut(p1);

            print(movie);

        }
    }
}
