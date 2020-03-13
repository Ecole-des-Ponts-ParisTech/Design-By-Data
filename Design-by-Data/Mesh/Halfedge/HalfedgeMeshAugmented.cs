using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;
using PlanktonGh;

namespace Design_by_Data.Mesh.Halfedge
{
    class HalfedgeMeshAugmented
    {
        public Plankton.PlanktonMesh PMesh { get; set; }

        #region Constructors 
        public HalfedgeMeshAugmented(Rhino.Geometry.Mesh mesh)
        {
            PMesh = new Plankton.PlanktonMesh();
            PMesh = mesh.ToPlanktonMesh();
        }
        #endregion
    }
}
