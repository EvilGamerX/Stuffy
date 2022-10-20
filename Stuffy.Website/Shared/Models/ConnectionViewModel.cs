using Stuffy.Website.Shared.Entities;

namespace Stuffy.Website.Shared.Models
{
    public class ConnectionViewModel : IViewModel<Connection>
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public NodeViewModel Node { get; set; }
        public string Relationship { get; set; }
        public int ColourCode { get; set; }
        public ConnectionViewModel() 
        {
            Id = Guid.Empty;
            ParentId = Guid.Empty;
            Node = new NodeViewModel();
            Relationship = string.Empty;
            ColourCode = 0;
        }

        public ConnectionViewModel(Connection connection)
        {
            Id = connection.Id;
            ParentId = connection.ParentId;
            Relationship = connection.Relationship;
            ColourCode = connection.ColourCode;
            Node = new NodeViewModel() { Id = connection.NodeId };
        }
        public Connection ToEntity()
        {
            return new Connection
            {
                Id = Id,
                ParentId = ParentId,
                Relationship = Relationship,
                ColourCode = ColourCode,
                NodeId = Node.Id
            };
        }
    }
}
