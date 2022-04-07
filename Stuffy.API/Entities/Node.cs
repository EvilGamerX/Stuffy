using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Text.Json.Serialization;

namespace Stuffy.API.Entities
{
    public class Node
    {
        public Guid Id { get; set; }
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
        public Color Colour { get; set; }

        public IEnumerable<Connection> Connections { get; set; }
    }
}