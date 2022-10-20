using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Stuffy.Website.Shared.Entities
{
    [Serializable]
    public class Connection
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        [ForeignKey("Node")]
        public Guid NodeId { get; set; }
        public virtual Node Node { get; set; }
        public string Relationship { get; set; }
        public string ColourCode { get; set; }

        public Connection()
        {
            Id = Guid.Empty;
            ParentId = Guid.Empty;
            NodeId = Guid.Empty;
            Relationship = string.Empty;
            ColourCode = "#000000";
        }

        public Connection(Connection connection)
        {
            Id = connection.Id;
            ParentId = connection.ParentId;
            NodeId = connection.NodeId;
            Relationship = connection.Relationship;
            ColourCode = connection.ColourCode;
        }
    }
}