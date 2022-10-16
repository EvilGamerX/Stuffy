using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Stuffy.Entity
{
    [Serializable]
    public class Connection
    {
        public Guid Id { get; set; }
        public Node OtherNode { get; set; }
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
            OtherNode = new Node();
            Relationship = string.Empty;
            Colour = Color.Empty;
        }

        public Connection(Connection connection) 
        {
            Id = connection.Id;
            OtherNode = connection.OtherNode;
            Relationship = connection.Relationship;
            ColourCode = connection.ColourCode;
        }
    }
}