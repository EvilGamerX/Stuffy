using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using Stuffy.Website.Shared.Enums;

namespace Stuffy.Website.Shared.Entities
{
    public class Node
    {
        public Guid Id { get; set; }
        public string? UserId { get; set; }
        public string Name { get; set; }
        public NodeTypeEnum Type { get; set; }
        public string ColourCode { get; set; }
        public string Description { get; set; }

        public ICollection<Connection> Connections { get; set; }

        public Node()
        {
            Id = Guid.Empty;
            Type = NodeTypeEnum.None;
            ColourCode = "#000000";
            Connections = new List<Connection>();
        }

        public Node(Node node)
        {
            Id = node.Id;
            UserId = node.UserId;
            Name = node.Name;
            Type = node.Type;
            ColourCode = node.ColourCode;
            Connections = node.Connections;
            Description = node.Description;
        }
    }
}