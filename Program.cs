using System;
using System.IO;

namespace GpioCore
{
    class Program
    {
        static void Main(string[] args)
        {
            bool menu = true;

            var pin26 = new GpioCore(Pin.Gpio26);
            
            while (menu)
            {
                Console.WriteLine("1. Write out pin info");
                Console.WriteLine("2. Open pin 26");
                Console.WriteLine("3. Close pin 26");
                Console.WriteLine("4. Set pin 26 as HIGH");
                Console.WriteLine("5. Set pin 26 as LOW");
                Console.WriteLine("6. Set pin 26 as IN");
                Console.WriteLine("7. Set pin 26 as OUT");               
                Console.WriteLine("press any other key to quit");
                try
                {
                    var key = int.Parse(Console.ReadLine());
                    switch (key)
                    {
                        case 1:
                            Console.WriteLine(pin26.pinId);
                            Console.WriteLine(pin26.pinDirection);
                            Console.WriteLine(pin26.pinState);
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
