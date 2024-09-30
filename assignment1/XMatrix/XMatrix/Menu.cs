using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Matrix
{
    public class Menu
    { 
        private List<XMatrix> matrices = new List<XMatrix>();
        public Menu() { }

        public void Run()
        {
            int n;
            do
            {
                PrintMenu();
                try
                {
                    n = int.Parse(Console.ReadLine()!);
                }
                catch (System.FormatException) { n = -1; }
                switch (n)
                {
                    case 0:
                        Console.WriteLine("Bye!");
                        break;
                    case 1:
                        GetElement();
                        break;
                    case 2:
                        AddMatrix();
                        break;
                    case 3:
                        PrintMatrix();
                        break;
                    case 4:
                        Sum();
                        break;
                    case 5:
                        Multiply();
                        break;

                }
            } while (n != 0);
        }

        static private void PrintMenu()
        {
            Console.WriteLine("\n*********MENU*********");
            Console.WriteLine("0. - Exit");
            Console.WriteLine("1. - Get an element");
            Console.WriteLine("2. - Add a matrix");
            Console.WriteLine("3. - Print a matrix");
            Console.WriteLine("4. - Add two matrices");
            Console.WriteLine("5. - Multiply two matrices");
            Console.WriteLine("Choose: ");
        }

        
      
        private void GetElement()
        {
            if (matrices.Count == 0)
            {
                Console.WriteLine("You haven't set a matrix");
                return;
            }

            int ind;
            do
            {
                Console.Write("Enter index of the matrix: ");
                bool ok = int.TryParse(Console.ReadLine(), out ind);
                if (!ok || ind <= 0 || ind > matrices.Count)
                {
                    Console.WriteLine("Invalid index");
                }
                else
                {
                    break;
                }
            } while (true);

            ind--; 

            do
            {
                try
                {
                    Console.WriteLine("Enter the index of the row: ");
                    int i = int.Parse(Console.ReadLine()!);
                    Console.WriteLine("Enter the index of the column: ");
                    int j = int.Parse(Console.ReadLine()!);
                    Console.WriteLine($"a[{i},{j}]={matrices[ind][i - 1, j - 1]}");
                    return;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine($"Index must be between 1 and {matrices[ind].Size}");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine($"Index must be between 1 and {matrices[ind].Size}");
                }
            } while (true);
        }

        private void AddMatrix()
        {
            Console.Write("Enter the size of the matrix: ");
            int size = int.Parse(Console.ReadLine()!);
            XMatrix matrix = new XMatrix(size);
            matrices.Add(matrix);
            Console.WriteLine("Matrix added");
        }

        private int index()
        {
            if (matrices.Count == 0)
            {
                Console.WriteLine("You haven't set a matrix");
                return -1;
            }
            int n = 0;
            bool ok;
            do
            {
                Console.Write("Enter index of the matrix: ");
                ok = false;
                try
                {
                    n = int.Parse(Console.ReadLine()!);
                    ok = true;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Integer is expected!");
                }
                if (n <= 0 || n > matrices.Count)
                {
                    ok = false;
                    Console.WriteLine("No such matrix!");
                }
            } while (!ok);
            return n - 1;
        }
        private void PrintMatrix()
        {

            if (matrices.Count == 0)
            {
                Console.WriteLine("You haven't set a matrix");
                return;
            }
            int ind = index();
            Console.Write(matrices[ind].ToString());
        }



        private void Sum()
        {
            if (matrices.Count == 0)
            {
                Console.WriteLine("You haven't set a matrix");
                return;
            }
            if (matrices.Count <= 1)
            {
                Console.WriteLine("There should be at least 2 matrices");
                return;
            }

            int ind1;
            do
            {
                Console.Write("Enter the 1st matrix index: ");
                bool ok = int.TryParse(Console.ReadLine(), out ind1);
                if (!ok || ind1 <= 0 || ind1 > matrices.Count)
                {
                    Console.WriteLine("Invalid index");
                }
                else
                {
                    break;
                }
            } while (true);

            ind1--;

            int ind2;
            do
            {
                Console.Write("Enter the 2nd matrix index: ");
                bool ok = int.TryParse(Console.ReadLine(), out ind2);
                if (!ok || ind2 <= 0 || ind2 > matrices.Count)
                {
                    Console.WriteLine("Invalid index");
                }
                else
                {
                    break;
                }
            } while (true);

            ind2--;
            XMatrix a = matrices[ind1];
            XMatrix b = matrices[ind2];
            if(a.Size != b.Size)
            {
                Console.WriteLine("Invalid size");
                return;
            }
            
            XMatrix sum = a + b ;

            Console.WriteLine(sum);

        }

        private void Multiply()
        {
            if (matrices.Count == 0)
            {
                Console.WriteLine("You haven't set a matrix");
                return;
            }
            if (matrices.Count <= 1)
            {
                Console.WriteLine("There should be at least 2 matrices");
                return;
            }

            int ind1;
            do
            {
                Console.Write("Enter the 1st matrix index: ");
                bool ok = int.TryParse(Console.ReadLine(), out ind1);
                if (!ok || ind1 <= 0 || ind1 > matrices.Count)
                {
                    Console.WriteLine("Invalid index");
                }
                else
                {
                    break;
                }
            } while (true);

            ind1--;

            int ind2;
            do
            {
                Console.Write("Enter the 2nd matrix index: ");
                bool ok = int.TryParse(Console.ReadLine(), out ind2);
                if (!ok || ind2 <= 0 || ind2 > matrices.Count)
                {
                    Console.WriteLine("Invalid index");
                }
                else
                {
                    break;
                }
            } while (true);

            ind2--;
            XMatrix a = matrices[ind1];
            XMatrix b = matrices[ind2];
            if (a.Size != b.Size)
            {
                Console.WriteLine("Invalid size");
                return;
            }

            XMatrix mult = a * b;

            Console.WriteLine(mult);

        }
        

    }
}
 