using Stuffy.Entity;
using System;

namespace Stuffy.API.Models
{
    public class ConnectionViewModel : IViewModel<Connection>
    {
        public Guid Id { get; set; }
        public NodeViewModel OtherNode { get; set; }
        public string Relationship { get; set; }
        public int ColourCode { get; set; }
        public ConnectionViewModel() 
        {
            Id = Guid.Empty;
            OtherNode = new NodeViewModel();
            Relationship = string.Empty;
            ColourCode = 0;
        }

        public ConnectionViewModel(Connection connection)
        {
            Id = connection.Id;
            Relationship = connection.Relationship;
            ColourCode = connection.ColourCode;
            OtherNode = new NodeViewModel(connection.OtherNode);
        }
        public Connection ToEntity()
        {
            return new Connection
            {
                Id = Id,
                Relationship = Relationship,
                ColourCode = ColourCode,
                OtherNode = OtherNode.ToEntity()
            };
        }
    }
}
