// Follow this project on Github https://github.com/sahinbosnic/GpioCore
// Contributors: 
// { Sahin Bosnic : sahin@bosnic.se }

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GpioCore
{
    public enum Pin {
        /*First Row*/ Gpio2 = 2, Gpio3 = 3, Gpio4 = 4, Gpio17 = 17, Gpio27 = 27, Gpio22 = 22, Gpio10 = 10, Gpio9 = 9, Gpio11 = 11, Gpio5 = 5, Gpio6 = 6, Gpio13 = 13, Gpio19 = 19, Gpio26 = 26,
        /*Second Row*/ Gpio14 = 14, Gpio15 = 15, Gpio18 = 18, Gpio23 = 23, Gpio24 = 24, Gpio25 = 25, Gpio8 = 8, Gpio7 = 7, Gpio12 = 12, Gpio16 = 16, Gpio20 = 20, Gpio21 = 21
    };
    public enum Direction { Out = 0, In = 1};
    public enum PinState { Low = 0, High = 1};

    public class GpioCore
    {
        public Pin pinId;
        public Direction pinDirection;
        public PinState pinState;
        private bool pinOpen = true;

        public GpioCore(Pin newPinId, Direction newDirection = Direction.Out, PinState newPinState = PinState.Low)
        {
            pinId = newPinId;
            pinDirection = newDirection;
            pinState = newPinState;

            //Check if gpio pin is already open
            if (!Directory.Exists($"/sys/class/gpio/gpio{pinId}"))
            {
                Console.WriteLine($"Opening pin {pinId}");
                File.WriteAllText("/sys/class/gpio/export", ((int)pinId).ToString());
            }
            else if (!Directory.Exists($"/sys/class/gpio/gpio{((int)pinId).ToString()}"))
            {
                Console.WriteLine($"Pin {pinId} is already open");
            }

            //Set direction
            if (pinDirection == Direction.Out) { Out(); }
            else if (pinDirection == Direction.In) { In(); }

            //Set value
            if (pinState == PinState.High) { High(); }
            else if (pinState == PinState.Low) { Low(); }
        }

        // Should be open after object init as default
        //Open pin
        public void Open()
        {
            if (!pinOpen)
            {
                Console.WriteLine($"Opening pin {pinId}");
                File.WriteAllText("/sys/class/gpio/export", ((int)pinId).ToString());
                pinOpen = true;
            } else { Console.WriteLine($"Pin {pinId} is already open!"); }
        }

        //Close pin
        public void Close()
        {
            if (pinOpen)
            {
                Console.WriteLine($"Closing pin {pinId}");
                File.WriteAllText("/sys/class/gpio/unexport", ((int)pinId).ToString());
                pinOpen = false;
            } else { Console.WriteLine($"Pin {pinId} is already closed!"); }
        }

        //Set pin value to HIGH (1)
        public void High()
        {
            Console.WriteLine($"Seting pin {pinId} value to HIGH");
            File.WriteAllText($"/sys/class/gpio/gpio{((int)pinId).ToString()}/value", 1.ToString());
            pinState = PinState.High;
        }

        //Set pin value to LOW (0)
        public void Low()
        {
            Console.WriteLine($"Seting pin {pinId} value to LOW");
            File.WriteAllText($"/sys/class/gpio/gpio{((int)pinId).ToString()}/value", 0.ToString());
            pinState = PinState.Low;
        }

        //Set pin direction to IN
        public void In()
        {
            Console.WriteLine($"Seting pin {pinId} Direction to In");
            File.WriteAllText($"/sys/class/gpio/gpio{((int)pinId).ToString()}/direction", "in");
            pinDirection = Direction.In;
        }

        //Set pin direction to OUT
        public void Out()
        {
            Console.WriteLine($"Seting pin {pinId} Direction to Out");
            File.WriteAllText($"/sys/class/gpio/gpio{((int)pinId).ToString()}/direction", "out");
            pinDirection = Direction.Out;
        }

        //Read value from pin, either 0 or 1
        public bool Read()
        {
            string value = File.ReadAllText($"/sys/class/gpio/gpio{((int)pinId).ToString()}/value");

            //Maybe not the fastest solution, but works for now..
            if (value.Contains("0")) { return false; }

            return true;
        }
    }
}
