using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core.Processing.Data;

public class Operation
{
    public int OperationID { get; set; }
    public string Name { get; set; }
    public int OrderInWhichToPerform { get; set; }
    public byte[] ImageData { get; set; }
    public Device Device { get; set; }
}
public class Device
{
    public int DeviceID { get; set; }
    public string Name { get; set; }
    public DeviceType DeviceType { get; set; }
}
public enum DeviceType
{
    BarcodeScanner,
    Printer,
    Camera,
    SocketTray
}
public class FormField
{
    public string Label { get; set; }
    public string Type { get; set; }
    public string Value { get; set; }
}
public class AddDeviceToOperationViewModel
{
    public Operation Operation { get; set; }
    public Device Device { get; set; }

}