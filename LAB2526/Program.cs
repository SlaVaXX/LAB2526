using System.Reflection.Metadata;

namespace LAB2526
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            Rectangle<float> FloatRec = new Rectangle<float>();
            Rectangle<double> DoubleRec = new Rectangle<double>();
            Rectangle<decimal> DecimalRec = new Rectangle<decimal>();
            string CurrentRec = "";
            for (int i = 0;;)
            {
                string Temp = "";
                Console.WriteLine("\nВведіть доступну команду:\n(new - створити новий прямокутник)\n(end - завершити виконання програми)");
                if (i > 0)
                {
                    Console.WriteLine("length - довжина сторін прямокутника)\n(coordinates - координати точок прямокутника)\n(area - площа прямокутника)\n(perimeter - периметр прямокутника)");
                }

                Temp = Console.ReadLine();
                if (Temp == "new")
                {
                    Console.WriteLine("Введіть тип даних для прямокутника\n(допустимі типи: float, double, decimal");
                    Temp = Console.ReadLine();
                    if (Temp == "float")
                    {
                        try
                        {
                            InitFloatRec(ref FloatRec);
                            i++;
                            CurrentRec = "float";
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else if (Temp == "double")
                    {
                        try
                        {
                            InitDoubleRec(ref DoubleRec);
                            i++;
                            CurrentRec = "double";
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else if (Temp == "decimal")
                    {
                        try
                        {
                            InitDecimalRec(ref DecimalRec);
                            i++;
                            CurrentRec = "decimal";
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
                else if (Temp == "length" && i > 0)
                {
                    if (CurrentRec == "float")
                    {
                        Console.WriteLine($"\nДовжина лівої сторони = {Math.Round(FloatRec.GetLeftSideLength,1)}");
                        Console.WriteLine($"\nДовжина верхньої сторони = {Math.Round(FloatRec.GetTopSideLength,1)}");
                        Console.WriteLine($"\nДовжина правої сторони = {Math.Round(FloatRec.GetRightSideLength,1)}");
                        Console.WriteLine($"\nДовжина нижньої сторони = {Math.Round(FloatRec.GetBottomSideLength,1)}");
                    }
                    else if (CurrentRec == "double")
                    {
                        Console.WriteLine($"\nДовжина лівої сторони = {Math.Round(DoubleRec.GetLeftSideLength,1)}");
                        Console.WriteLine($"\nДовжина верхньої сторони = {Math.Round(DoubleRec.GetTopSideLength,1)}");
                        Console.WriteLine($"\nДовжина правої сторони = {Math.Round(DoubleRec.GetRightSideLength,1)}");
                        Console.WriteLine($"\nДовжина нижньої сторони = {Math.Round(DoubleRec.GetBottomSideLength,1)}");
                    }
                    else if (CurrentRec == "decimal")
                    {
                        Console.WriteLine($"\nДовжина лівої сторони = {Math.Round(DecimalRec.GetLeftSideLength,1)}");
                        Console.WriteLine($"\nДовжина верхньої сторони = {Math.Round(DecimalRec.GetTopSideLength,1)}");
                        Console.WriteLine($"\nДовжина правої сторони = {Math.Round(DecimalRec.GetRightSideLength,1)}");
                        Console.WriteLine($"\nДовжина нижньої сторони = {Math.Round(DecimalRec.GetBottomSideLength,1)}");
                    }
                }
                else if (Temp == "coordinates" && i > 0)
                {
                    if (CurrentRec == "float")
                    {
                        FloatRec.PrintCoordinates();
                    }
                    else if (CurrentRec == "double")
                    {
                        DoubleRec.PrintCoordinates();
                    }
                    else if (CurrentRec == "decimal")
                    {
                        DecimalRec.PrintCoordinates();
                    }
                }
                else if (Temp == "area" && i > 0)
                {
                    if (CurrentRec == "float")
                    {
                        Console.WriteLine($"\nПлоща прямокутника = {FloatRec.Area()}");
                    }
                    else if (CurrentRec == "double")
                    {
                        Console.WriteLine($"\nПлоща прямокутника = {DoubleRec.Area()}");
                    }
                    else if (CurrentRec == "decimal")
                    {
                        Console.WriteLine($"\nПлоща прямокутника = {DecimalRec.Area()}");
                    }
                }
                else if (Temp == "perimeter" && i > 0)
                {
                    if (CurrentRec == "float")
                    {
                        Console.WriteLine($"\nПериметр прямокутника = {FloatRec.Perimeter()}");
                    }
                    else if (CurrentRec == "double")
                    {
                        Console.WriteLine($"\nПериметр прямокутника = {DoubleRec.Perimeter()}");
                    }
                    else if (CurrentRec == "decimal")
                    {
                        Console.WriteLine($"\nПериметр прямокутника = {DecimalRec.Perimeter()}");
                    }
                }
                else if (Temp == "clear")
                {
                    Console.Clear();
                }
                else if (Temp == "end")
                {
                    break;
                }
            }
        }

        private static void InitFloatRec(ref Rectangle<float> FloatRec)
        {
            float TopLeftX = 0, TopLeftY = 0, BottomLeftX = 0, BottomLeftY = 0, BottomRightX = 0, BottomRightY = 0;
            try
            {
                Console.Write("\nВведіть координату X для лівої верхньої координати: ");
                TopLeftX = float.Parse(Console.ReadLine());
                Console.Write("\nВведіть координату Y для лівої верхньої координати: ");
                TopLeftY = float.Parse(Console.ReadLine());

                Console.Write("\nВведіть координату X для лівої нижньої координати: ");
                BottomLeftX = float.Parse(Console.ReadLine());
                Console.Write("\nВведіть координату Y для лівої нижньої координати: ");
                BottomLeftY = float.Parse(Console.ReadLine());

                Console.Write("\nВведіть координату X для правої нижньої координати: ");
                BottomRightX = float.Parse(Console.ReadLine());
                Console.Write("\nВведіть координату Y для правої нижньої координати: ");
                BottomRightY = float.Parse(Console.ReadLine());
                FloatRec = Rectangle<float>.NewRectangle(TopLeftX, TopLeftY, BottomLeftX, BottomLeftY, BottomRightX, BottomRightY);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new Exception("Некоректні дані!");
                // 
            }
        }

        private static void InitDoubleRec(ref Rectangle<double> DoubleRec)
        {
            double TopLeftX = 0, TopLeftY = 0, BottomLeftX = 0, BottomLeftY = 0, BottomRightX = 0, BottomRightY = 0;
            try
            {
                Console.Write("\nВведіть координату X для лівої верхньої координати: ");
                TopLeftX = double.Parse(Console.ReadLine());
                Console.Write("\nВведіть координату Y для лівої верхньої координати: ");
                TopLeftY = double.Parse(Console.ReadLine());

                Console.Write("\nВведіть координату X для лівої нижньої координати: ");
                BottomLeftX = double.Parse(Console.ReadLine());
                Console.Write("\nВведіть координату Y для лівої нижньої координати: ");
                BottomLeftY = double.Parse(Console.ReadLine());

                Console.Write("\nВведіть координату X для правої нижньої координати: ");
                BottomRightX = double.Parse(Console.ReadLine());
                Console.Write("\nВведіть координату Y для правої нижньої координати: ");
                BottomRightY = double.Parse(Console.ReadLine());
                DoubleRec = Rectangle<double>.NewRectangle(TopLeftX, TopLeftY, BottomLeftX, BottomLeftY, BottomRightX, BottomRightY);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new Exception("Некоректні дані!");
            }
        }

        private static void InitDecimalRec(ref Rectangle<decimal> FloatRec)
        {
            decimal TopLeftX = 0, TopLeftY = 0, BottomLeftX = 0, BottomLeftY = 0, BottomRightX = 0, BottomRightY = 0;
            try
            {
                Console.Write("\nВведіть координату X для лівої верхньої координати: ");
                TopLeftX = decimal.Parse(Console.ReadLine());
                Console.Write("\nВведіть координату Y для лівої верхньої координати: ");
                TopLeftY = decimal.Parse(Console.ReadLine());

                Console.Write("\nВведіть координату X для лівої нижньої координати: ");
                BottomLeftX = decimal.Parse(Console.ReadLine());
                Console.Write("\nВведіть координату Y для лівої нижньої координати: ");
                BottomLeftY = decimal.Parse(Console.ReadLine());

                Console.Write("\nВведіть координату X для правої нижньої координати: ");
                BottomRightX = decimal.Parse(Console.ReadLine());
                Console.Write("\nВведіть координату Y для правої нижньої координати: ");
                BottomRightY = decimal.Parse(Console.ReadLine());
                FloatRec = Rectangle<decimal>.NewRectangle(TopLeftX, TopLeftY, BottomLeftX, BottomLeftY, BottomRightX, BottomRightY);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new Exception("Некоректні дані!");
            }
        }
    }
}