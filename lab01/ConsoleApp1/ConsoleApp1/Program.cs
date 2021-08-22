using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static int Suma(int a, int b)
        {
            return (a + b);
        }

        static int Resta(int a, int b)
        {
            return (a - b);
        }

        static int Multiplicacion(int a, int b)
        {
            return (a * b);
        }

        static double Division(int a, int b)
        {                            
            double resp = (double)a / b;
            return resp;
        }

        static void Raiz()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("La raiz cuadrada de {0} es {1}", i, Math.Sqrt(i));
            }
        }

        static void Primo()
        {
            int ct, n = 0, i = 1, j;
            while (n < 10)
            {
                j = 1;
                ct = 0;
                while (j <= i)
                {
                    if (i % j == 0)
                        ct++;
                    j++;
                }
                if (ct == 2)
                {
                    Console.WriteLine("El {0} numero primo es: {1}", n+1, i);
                    n++;
                }
                i++;
            }
        }
        static double Temperatura(int value, int type)
        {
            switch (type)
            {
                case 1:
                    double cels = 5 * (double)(value - 32) / 9;
                    return cels;
                case 2:
                    double far = (double)(9 * value / 5) + 32;
                    return far;
                default:
                    return (double)value;
            }
        }

        static void Main(string[] args)
        {
            Console.Title = "Procedimientos y funciones";
            string opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("[1] SUMA DE DOS NÚMEROS");
                Console.WriteLine("[2] RESTA DE DOS NÚMEROS");
                Console.WriteLine("[3] MULTIPLICACION DE DOS NÚMEROS");
                Console.WriteLine("[4] DIVISION DE DOS NÚMEROS");
                Console.WriteLine("[5] IMPRIMIR LA RAIZ CUADRADA DE LOS PRIMERO 10 NÚMEROS");
                Console.WriteLine("[6] IMPRIMIR LOS 10 PRIMEROS NÚMEROS PRIMOS");
                Console.WriteLine("[7] CONVERTIR TEMPERATURA");
                Console.WriteLine("[0] SALIR");
                Console.WriteLine("Ingrese una opción y presione ENTER");

                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        int a;
                        int b;
                        Console.WriteLine("Ingrese el primer número");
                        a = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo número");
                        b = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La suma de {0} y {1} es {2}", a, b, Suma(a,b));
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("Ingrese el primer número");
                        a = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo número");
                        b = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La resta de {0} y {1} es {2}", a, b, Resta(a, b));
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine("Ingrese el primer número");
                        a = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo número");
                        b = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("El producto de {0} y {1} es {2}", a, b, Multiplicacion(a, b));
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Ingrese el primer número");
                        a = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo número");
                        b = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La division de {0} y {1} es {2}", a, b, Division(a, b));
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.WriteLine("Calculando...");
                        Raiz();
                        Console.ReadKey();                        
                        break;
                    case "6":
                        Console.WriteLine("Calculando...");
                        Primo();
                        Console.ReadKey();                        
                        break;
                    case "7":
                        Console.WriteLine("Convertir a Celsius(1) o a Fahrenheit(2)");
                        int type = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el valor a convertir");
                        int value = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La temperatura es {0} ", Temperatura(value,type));
                        Console.ReadKey();
                        break;
                }
            } while (!opcion.Equals("0"));
        }
    }
}
