using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PetBot
{
    class GpioCore
    {
        public void Open(int pinid)
        {
            if (!Directory.Exists("/sys/class/gpio/gpio" + pinid))
            {
                Console.WriteLine("...about to open pin " + pinid);
                File.WriteAllText("/sys/class/gpio/export", pinid.ToString());
            }
            else if (!Directory.Exists("/sys/class/gpio/gpio" + pinid))
            {
                Console.WriteLine("...pin " + pinid + " is already open");
            }
        }

        public void Close(int pinid)
        {
            if (Directory.Exists("/sys/class/gpio/gpio" + pinid))
            {
                Console.WriteLine("...about to close pin " + pinid);
                File.WriteAllText("/sys/class/gpio/unexport", pinid.ToString());
            }
            else if (!Directory.Exists("/sys/class/gpio/gpio" + pinid))
            {
                Console.WriteLine("...pin " + pinid + " is already closed");
            }
        }

        public void High(int pinid)
        {
            if (Directory.Exists("/sys/class/gpio/gpio" + pinid))
            {
                //Set value 1
                File.WriteAllText("/sys/class/gpio/gpio" + pinid.ToString() + "/value", 1.ToString());
            }
            else if (!Directory.Exists("/sys/class/gpio/gpio" + pinid))
            {
                Console.WriteLine("Error.. cant change value, " + pinid + " is closed");
            }
        }
        public void Low(int pinid)
        {
            if (Directory.Exists("/sys/class/gpio/gpio" + pinid))
            {
                //Set value 0
                File.WriteAllText("/sys/class/gpio/gpio" + pinid.ToString() + "/value", 0.ToString());
            }
            else if (!Directory.Exists("/sys/class/gpio/gpio" + pinid))
            {
                Console.WriteLine("Error.. cant change value, " + pinid + " is closed");
            }
        }

        public void In(int pinid)
        {
            if (Directory.Exists("/sys/class/gpio/gpio" + pinid))
            {
                //Set direction 'in'
                File.WriteAllText("/sys/class/gpio/gpio" + pinid.ToString() + "/direction", "in");
            }
            else if (!Directory.Exists("/sys/class/gpio/gpio" + pinid))
            {
                Console.WriteLine("Error.. cant change direction, " + pinid + " is closed");
            }
        }

        public void Out(int pinid)
        {
            if (Directory.Exists("/sys/class/gpio/gpio" + pinid))
            {
                //Set direction 'out'
                File.WriteAllText("/sys/class/gpio/gpio" + pinid.ToString() + "/direction", "out");
            }
            else if (!Directory.Exists("/sys/class/gpio/gpio" + pinid))
            {
                Console.WriteLine("Error.. cant change direction, " + pinid + " is closed");
            }
 
        }

        public void ScanOpenPins()
        {
            //Dont use yet, not functional due to random pin layout
            Console.WriteLine("Scanning for open pins...");
            for(int i = 1; i <= 40; i++)
            {
                if (Directory.Exists("/sys/class/gpio/gpio" + i))
                {
                    Console.Write("Gpio Pin " + i );
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" OPEN");
                    Console.ResetColor();
                }
            }
        }
    }
}
