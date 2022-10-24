
using Stuffy.Website.Shared.Entities;
using Stuffy.Website.Shared.Enums;
using System.Drawing;

namespace Stuffy.Website.Shared.Models
{
    public class NodeViewModel : IViewModel<Node>
    {
        public Guid Id { get; set; }
        public string? UserId {get; set; }
        public string Name { get; set; }
        public NodeTypeEnum Type { get; set; }
        public string ColourCode { get; set; }
        public string Description { get; set; }
        public ICollection<ConnectionViewModel> Connections { get; set; }

        public NodeViewModel() 
        {
            Id = Guid.Empty;
            Type = NodeTypeEnum.None;
            ColourCode = "#000000";
            Connections = new List<ConnectionViewModel>();
        }

        public NodeViewModel(Node node)
        {
            Id = node.Id;
            UserId = node.UserId;
            Name = node.Name;
            Type = node.Type;
            ColourCode = node.ColourCode;
            Description = node.Description;
            Connections = node.Connections.Select(connection => new ConnectionViewModel(connection)).ToList();
        }

        public Node ToEntity()
        {
            return new Node
            {
                Id = Id,
                UserId = UserId,
                Name = Name,
                Type = Type,
                ColourCode = ColourCode,
                Description = Description,
                Connections = Connections.Select(cvm => cvm.ToEntity()).ToList()
            };
        }
    }
}
