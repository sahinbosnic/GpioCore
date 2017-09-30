// Follow this project on Github https://github.com/sahinbosnic/GpioCore
// Contributors: 
// { Sahin Bosnic : sahin@bosnic.se }

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GpioCore
{
    public class GpioCore
    {
        public int PinId { get; set; }
        public string Direction { get; set; }
        public int Value { get; set; }

        public const string IN = "in";
        public const string OUT = "out";
        public const int HIGH = 1;
        public const int LOW = 0;

        //Constructor, build and opens up pins
        public GpioCore(int pinId, string direction = OUT, int value = LOW)
        {
            PinId = pinId;
            Direction = direction;
            Value = value;

            //Check if gpio pin is already open
            if (!Directory.Exists($"/sys/class/gpio/gpio{PinId}"))
            {
                Console.WriteLine($"Opening pin {PinId}");
                File.WriteAllText("/sys/class/gpio/export", PinId.ToString());

                //Set direction
                if (Direction == OUT) { Out(); }
                else if (Direction == IN) { In(); }

                //Set value
                if (Value == HIGH) { High(); }
                else if (Value == LOW) { Low(); }
            }
            else if (!Directory.Exists($"/sys/class/gpio/gpio{PinId}"))
            {
                Console.WriteLine($"Pin {PinId} is already open, try configuring it instead");
            }
        }

        // Should be open after object init as default
        //Open pin
        public void Open()
        {
            Console.WriteLine($"Opening pin {PinId}");
            File.WriteAllText("/sys/class/gpio/export", PinId.ToString());
        }

        //Close pin
        //MAKE SURE TO DISPOSE THE OBJECT, Once closed the other functions might cause crashes if used
        //If you still need the pin, try setting the value to LOW instead
        public void Close()
        {
            Console.WriteLine($"Closing pin {PinId}");
            File.WriteAllText("/sys/class/gpio/unexport", PinId.ToString());
        }

        //Set pin value to HIGH (1)
        public void High()
        {
            Console.WriteLine($"Seting pin {PinId} value to HIGH");
            File.WriteAllText($"/sys/class/gpio/gpio{PinId}/value", HIGH.ToString());
            Value = HIGH;
        }

        //Set pin value to LOW (0)
        public void Low()
        {
            Console.WriteLine($"Seting pin {PinId} value to LOW");
            File.WriteAllText($"/sys/class/gpio/gpio{PinId}/value", LOW.ToString());
            Value = LOW;
        }

        //Set pin direction to IN
        public void In()
        {
            Console.WriteLine($"Seting pin {PinId} Direction to In");
            File.WriteAllText($"/sys/class/gpio/gpio{PinId}/direction", IN);
            Direction = IN;
        }

        //Set pin direction to OUT
        public void Out()
        {
            Console.WriteLine($"Seting pin {PinId} Direction to Out");
            File.WriteAllText($"/sys/class/gpio/gpio{PinId}/direction", OUT);
            Direction = OUT;
        }

        //Read value from pin, either 0 or 1
        public bool Read()
        {
            string value = File.ReadAllText($"/sys/class/gpio/gpio{PinId}/value");

            //Maybe not the fastest solution, but works for now..
            if (value.Contains("0")) { return false; }

            return true;
        }

        //Deconstructor to dispose the object and close the pin properly
        ~GpioCore()
        {
            //Close pin to avoid unnecessary bugs or errors
            Close();
            Console.WriteLine($"Deconstructor has cleaned up and closed pin {PinId}");
        }
    }
}
