using SerialPortLib;

// Create a new SerialPortInput instance
var serialPort = new SerialPortInput();

// Listen to Serial Port events
serialPort.ConnectionStatusChanged += (sender, args) =>
{
    Console.WriteLine($"Connected = {args.Connected}");
};

serialPort.MessageReceived += (sender, args) =>
{
    Console.WriteLine($"Received message: {BitConverter.ToString(args.Data)}");
};

// Set port options (e.g., COM port and baud rate)
serialPort.SetPort("/dev/ttyUSB0", 115200);

// Connect to the serial port
serialPort.Connect();

// Send a message
var message = System.Text.Encoding.UTF8.GetBytes("Hello World!");
serialPort.SendMessage(message);
