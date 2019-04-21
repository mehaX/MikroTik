using MediatR;

namespace MikroTik.Application.Devices.Commands
{
    public class RenameDeviceCommand : IRequest<Unit>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }
}
