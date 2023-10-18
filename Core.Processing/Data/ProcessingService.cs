namespace Core.Processing.Data;

public class ProcessingService
{
    public static async Task<List<Operation>> GetSampleOperations()
    {
        List<Operation> operations = new List<Operation>
    {
        new Operation
        {
            OperationID = 1,
            Name = "Operation 1",
            OrderInWhichToPerform = 1,
            ImageData = new byte[] { 0x12, 0x34, 0x56 },
            Device =  GetSampleDevices().Result[0]
        },
        new Operation
        {
            OperationID = 2,
            Name = "Operation 2",
            OrderInWhichToPerform = 2,
            ImageData = new byte[] { 0x78, 0x90, 0xAB },
            Device =  GetSampleDevices().Result[1]

        },
        new Operation
        {
            OperationID = 3,
            Name = "Operation 3",
            OrderInWhichToPerform = 3,
            ImageData = new byte[] { 0xCD, 0xEF, 0x01 },
            Device =  GetSampleDevices().Result[2]
        }
    };

        return await Task.FromResult(operations);
    }
    public static async Task<List<Device>> GetSampleDevices()
    {
        List<Device> devices = new List<Device>
    {
        new Device
        {
            DeviceID = 1,
            Name = "Scanner 1",
            DeviceType = DeviceType.BarcodeScanner
        },
        new Device
        {
            DeviceID = 2,
            Name = "Printer 1",
            DeviceType = DeviceType.Printer
        },
        new Device
        {
            DeviceID = 3,
            Name = "Camera 1",
            DeviceType = DeviceType.Camera
        }
        };

        return await Task.FromResult(devices);
    }
}