using System;

namespace GpioCore
{
    class Program
    {
        static void Main(string[] args)
        {
            bool menu = true;
            var pin26 = new GpioCore(26, GpioCore.OUT, GpioCore.LOW);
            
            while (menu)
            {
                Console.WriteLine("1. Reinstantiate GpioCore object on pin 26");
                Console.WriteLine("2. Open pin 26");
                Console.WriteLine("3. Close pin 26");
                Console.WriteLine("4. Set pin 26 as HIGH");
                Console.WriteLine("5. Set pin 26 as LOW");
                Console.WriteLine("5. Set pin 26 as IN");
                Console.WriteLine("5. Set pin 26 as OUT");
                Console.WriteLine("8. Write out info");
                Console.WriteLine("press any other key to quit");
                try
                {
                    var key = int.Parse(Console.ReadLine());
                    switch (key)
                    {
                        case 1:
                            pin26 = new GpioCore(26, GpioCore.OUT, GpioCore.LOW);
                        break;

                        case 2:
                            pin26.Open();
                        break;

                        case 3:
                            pin26.Close();
                        break;

                        case 4:
                            pin26.High();
                        break;

                        case 5:
                            pin26.Low();
                        break;

                        case 6:
                            pin26.In();
                        break;

                        case 7:
                            pin26.Out();
                        break;

                        case 8:
                            Console.WriteLine(pin26.PinId.ToString());
                            Console.WriteLine(pin26.Direction);
                            Console.WriteLine(pin26.Value.ToString());
                        break;

                        default:
                            menu = false;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
