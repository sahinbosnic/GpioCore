# GpioCore
A dotnet core based library for managing GPIO pins on a Raspberry Pi (Linux)
Import GpioCore.cs to your project


### Usage

#### First create a GpioCore object
```
GpioCore gpio = new GpioCore();
```


#### Choose which pins to open
```
// In this example we'll open pin nr 26
gpio.Open(26);
```


#### Set the pin to either listen or send signals (direction)
```
// We set pin 26 to send signals
gpio.Out(26);

// And from here we set the pin to listen for signals.
gpio.In(26);
```


#### Set the pin to either be HIGH or LOW, ON/OFF (value)
```
// Set the pin on high (Send signal)
gpio.High(26);

// Set the pin on low (Stop signal)
gpio.Low(26);
```


### Console application example
```
GpioCore gpio = new GpioCore();

Console.WriteLine("Which pin would you like to turn on?");
int pin = int.Parse(Console.ReadLine());

gpio.Open(pin);
gpio.Out(pin);
gpio.High(pin);
```
