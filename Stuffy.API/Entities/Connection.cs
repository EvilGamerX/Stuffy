using System;
using System.Drawing;

namespace Stuffy.API.Entities
{
    [Serializable]
    public class Connection
    {
        public Guid Id { get; set; }
        public Node OtherNode { get; set; }
        public string Relationship { get; set; }
        public Color Colour { get; }
    }
}