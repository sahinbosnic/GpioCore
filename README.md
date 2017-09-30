# GpioCore
A dotnet core based library for managing GPIO pins on a Raspberry Pi (Linux)
Import GpioCore.cs to your project


### Usage

#### Choose which pins to open
```c#
// In this example we'll create a GpioCore object
// As default this will just open up the pin and set it to send signals with a value set to LOW (0)
var pin26 = new GpioCore(26);

// This way we both open the pin, set the pin to send signals (OUT) with a value set to LOW (0)
var pin26 = new GpioCore(26, GpioCore.OUT, GpioCore.LOW);

// Once the object is created you can either Open() or Close() it later on
pin26.Open();
pin26.Close();
```


#### Set the pin to either listen or send signals (direction)
```c#
// If you have used the first example above and want to change the direction, 
// you can change it by calling either the In() or Out()

// Changing the pin to listen to signals
pin26.In();

// Changing the pin to send signals
pin26.Out();
```


#### Set the pin to either be HIGH or LOW  (value)
```c#
// Set the pin on High (1)
pin26.High();

// Set the pin on Low (0)
pin26.Low();
```

#### Reading from a pin
```c#
// This function is currently under testing and might not work as intentioned

// Check if the pin returns a value (true/false)
// Expects true to be triggered
if (pin26.Read())
{
    // Do something
}

// Expects false to be triggered
if (!pin26.Read())
{
    // Do something
}
```


#### Console application example
```c#
// Create the object
var pin26 = new GpioCore(26, GpioCore.IN);

// Loop until you find a signal
bool loop = true;
while (loop)
{
    if (pin26.Read())
    {
        // Break the loop
        Console.WriteLine("We got a signal!");
        loop = false;
    }
}
```
