using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Stuffy.Entity
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

        public Connection() 
        {
            Id = Guid.Empty;
            ParentId = Guid.Empty;
            NodeId = Guid.Empty;
            Relationship = string.Empty;
            Colour = Color.Empty;
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