# GpioCore
A dotnet core based library for managing GPIO pins on a Raspberry Pi (Linux)
Import GpioCore.cs to your project


### Usage

#### Choose which pins to open
```
// In this example we'll open pin nr 26
GpioCore.Open(26);
```


#### Set the pin to either listen or send signals (direction)
```
// We set pin 26 to send signals
GpioCore.Out(26);

// And from here we set the pin to listen for signals.
GpioCore.In(26);
```


#### Set the pin to either be HIGH or LOW, ON/OFF (value)
```
// Set the pin on high (Send signal)
GpioCore.High(26);

// Set the pin on low (Stop signal)
GpioCore.Low(26);
```


### Console application example
```
Console.WriteLine("Which pin would you like to turn on?");
int pin = int.Parse(Console.ReadLine());

GpioCore.Open(pin);
GpioCore.Out(pin);
GpioCore.High(pin);
```
