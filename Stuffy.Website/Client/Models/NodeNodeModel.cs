using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;
using Stuffy.Website.Shared.Models;

namespace Stuffy.Website.Client.Models
{
    public class NodeNodeModel : NodeModel
    {
        public NodeViewModel Data { get; set; }
        public NodeNodeModel() 
        {
            Data = new NodeViewModel();
        }
        public NodeNodeModel(NodeViewModel data)
        {
            Data = data;
        }
        public NodeNodeModel(Point position) : base(position) 
        {
            Data = new NodeViewModel();
        }

        public NodeNodeModel(double x, double y) : base(new Point(x, y))
        {
            Data = new NodeViewModel();
        }

        public NodeNodeModel(double x, double y, NodeViewModel data) : base(new Point(x, y))
        {
            Data = data;
        }
    }
}
