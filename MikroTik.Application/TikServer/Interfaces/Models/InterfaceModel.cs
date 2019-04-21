using System;
using System.Linq.Expressions;
using MikroTik.Domain.ValueObjects;
using tik4net.Objects.Interface;

namespace MikroTik.Application.TikServer.Interfaces.Models
{
    public class InterfaceModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string MacAddress { get; set; }
        public TransferData TransferData { get; set; }
        public bool Running { get; set; }
        public bool Disabled { get; set; }
        public string Comment { get; set; }

        public static Expression<Func<Interface, InterfaceModel>> Projection
        {
            get
            {
                return entity => new InterfaceModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Type = entity.Type,
                    MacAddress = entity.MacAddress,
                    Running = entity.Running,
                    TransferData = new TransferData(entity.TxByte, entity.RxByte),
                    Disabled = entity.Disabled,
                    Comment = entity.Comment
                };
            }
        }

        public static InterfaceModel Create(Interface entity)
        {
            return Projection.Compile().Invoke(entity);
        }
    }
}
