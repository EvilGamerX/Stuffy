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
        public int ColourCode
        {
            get
            {
                return Colour.ToArgb();
            }
            set
            {
                Colour = Color.FromArgb(value);
            }
        }

        [NotMapped]
        private Color Colour { get; set; }

        public IEnumerable<Connection> Connections { get; set; }

        public Node()
        {
            Id = Guid.Empty;
            Name = string.Empty;
            Type = NodeTypeEnum.None;
            Colour = Color.Empty;
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
        }
    }
}