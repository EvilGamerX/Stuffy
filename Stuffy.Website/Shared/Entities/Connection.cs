using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Stuffy.Website.Shared.Entities
{
    [Serializable]
    public class Connection
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public Guid OtherNodeId { get; set; }
        public virtual Node OtherNode{ get; set; }
        public string Relationship { get; set; }
        public string ColourCode { get; set; }

        public Connection()
        {
            Id = Guid.Empty;
            ParentId = Guid.Empty;
            OtherNode = new Node();
            Relationship = string.Empty;
            ColourCode = "#000000";
        }

        public Connection(Connection connection)
        {
            Id = connection.Id;
            ParentId = connection.ParentId;
            OtherNode = connection.OtherNode;
            Relationship = connection.Relationship;
            ColourCode = connection.ColourCode;
        }
    }
}