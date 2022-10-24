using Stuffy.Website.Shared.Entities;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Text.Json.Serialization;

namespace Stuffy.Website.Shared.Models
{
    public class ConnectionViewModel : IViewModel<Connection>
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public virtual NodeViewModel? Parent { get; set; }
        public Guid OtherNodeId{ get; set; }
        public virtual NodeViewModel OtherNode { get; set; }
        public string Relationship { get; set; }
        public string ColourCode { get; set; }
        public ConnectionViewModel() 
        {
            Id = Guid.Empty;
            ParentId = Guid.Empty;
            OtherNodeId = Guid.Empty;
            OtherNode = new NodeViewModel();
            Relationship = string.Empty;
            ColourCode = "#000000";
        }

        public ConnectionViewModel(Connection connection)
        {
            Id = connection.Id;
            ParentId = connection.ParentId;
            OtherNodeId = connection.OtherNodeId;
            Relationship = connection.Relationship;
            ColourCode = connection.ColourCode;
            OtherNode = new NodeViewModel(connection.OtherNode);
        }
        public Connection ToEntity()
        {
            return new Connection
            {
                Id = Id,
                ParentId = ParentId,
                Relationship = Relationship,
                ColourCode = ColourCode,
                OtherNodeId = OtherNodeId
            };
        }
    }
}
