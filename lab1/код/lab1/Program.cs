/*
1) Неявное преобразование простых и ссылочных типов, в виде комментариев 
внести в программу таблицу неявных преобразований;
2) Явное преобразование простых и ссылочных типов, в виде комментариев 
внести в программу таблицу явных преобразований;
3) Безопасное приведение ссылочных типов с помощью операторов as и is;
4) Пользовательское преобразование типов Implicit, Explicit;
5) Преобразование с помощью класса Convert и преобразование строки в число с 
помощью методов Parse, TryParse.
6) Написать программу, позволяющую ввод в текстовое поле TextBox только 
символов, задающих правильный формат вещественного числа со знаком.
*/
using System;

namespace lab1
{
    public class Temp_Fahrenheit
    {

        public double value;
        public Temp_Fahrenheit(double value)
        {
            this.value = value;
        }
        public static explicit operator Temp_Celcius(Temp_Fahrenheit tf)
        {
            return new Temp_Celcius((tf.value - 37) * 5 / 9);

        }
    }
    public class Temp_Celcius
    {
        public double value;
        public Temp_Celcius(double value)
        {
            this.value = value;
        }
        public static implicit operator Temp_Fahrenheit(Temp_Celcius tc)
        {
            return new Temp_Fahrenheit(tc.value * 9 / 5 + 32);
        }
    }
    internal class Program
        {
            static void first()
            {
                //            1) Неявное преобразование простых и ссылочных типов, в виде комментариев
                //внести в программу таблицу неявных преобразований;

                int a = 15;
                double b = a;
                Console.WriteLine(b); //15
                /*
                Byte	-> UInt16, Int16 UInt32 Int32 UInt64 Int64 Single Double Decimal
                SByte	-> Int16, , Int32 Single Int64 Double Decimal
                Int16	-> Int32, , Int64 Single, Double Decimal
                UInt16	-> UInt32, Int32, UInt64 Int64 Single Double Decimal
                Char	-> UInt16, UInt32, Int32 UInt64 Int64 Single Double Decimal
                Int32	-> Int64, , Double Decimal
                UInt32	-> Int64, , UInt64 Dou66blDecimal
                Int64	-> Decimal
                UInt64	-> Decimal
                Single	-> Double
                */
                object obj = "Hello World"; // Неявное преобразование строки в object
            }
            static void second()
            {
                //            2) Явное преобразование простых и ссылочных типов, в виде комментариев
                //внести в программу таблицу явных преобразований;
                int a = 257; 
                byte b = (byte)a;
                Console.WriteLine(b); //1
                object obg = "Hi";
                string str = (string)obg;
                Console.WriteLine(str); //Hi
                /*
                sbyte	->byte, ushort, uint, ulong или nuint
                byte	->sbyte
                short	->sbyte, byte, ushort, uint, ulong или nuint
                ushort	->sbyte, byte или short
                int 	->sbyte, byte, short, ushort, uint, ulong или nuint
                uint	->sbyte, byte, short, ushort, int или nint
                long	->sbyte, byte, short, ushort, int, uint, ulong, nint или nuint
                ulong	->sbyte, byte, short, ushort, int, uint, long, nint или nuint
                float	->sbyte, byte, short, ushort, int, uint, long, ulong, decimal, nint или nuint
                double	->sbyte, byte, short, ushort, int, uint, long, ulong, float, decimal, nint или nuint
                decimal	->sbyte, byte, short, ushort, int, uint, long, ulong, float, double, nint или nuint
                nint	->sbyte, byte, short, ushort, int, uint, ulong или nuint
                nuint	->sbyte, byte, short, ushort, int, uint, long или nint
                */
            }
            static void third()
            {
                //3) Безопасное приведение ссылочных типов с помощью операторов as и is;
                object a = 54.4;
                string str = a as string;
                if (str != null)
                {
                    Console.WriteLine($"Это строка: {str}");
                }
                else
                {
                    Console.WriteLine("a не строка "); //a не строка
                }
                if (a is double b)
                {
                    Console.WriteLine($"Это число {b}"); //это число 54,4
                }
                else
                {
                    Console.WriteLine("a не double");
                }

            }
            static void four()
            {
                //4) Пользовательское преобразование типов Implicit, Explicit;

                Temp_Celcius tc = new Temp_Celcius(50);
                Temp_Fahrenheit tf = tc;
                Console.WriteLine(tf.value); //122

                tf.value = 50;
                tc = (Temp_Celcius)tf;
                Console.WriteLine(tc.value);//7,22222222222222

            }
            static void five()
            {
                {
                    string a = "5";
                    int b = Convert.ToInt32(a);
                    Console.WriteLine(b);//5
                }
                {
                    string a = "4";
                    try
                    {
                        int c = int.Parse(a);
                        Console.WriteLine(c);//4
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error");
                    }
                }
                {
                    string a = "f3";
                    int res;
                    bool flag = int.TryParse(a, out res);
                    if (!flag){
                        Console.WriteLine("Error"); //Error
                        return;
                    }
                    Console.WriteLine(res);
                }

            }
            static void Main(string[] args)
            {
                first();
                second();
                third();
                four();
                five();
            }
        }
    
}