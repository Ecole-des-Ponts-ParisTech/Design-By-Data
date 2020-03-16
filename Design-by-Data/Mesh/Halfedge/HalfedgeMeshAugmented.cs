using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;
using PlanktonGh;

namespace Design_by_Data.Mesh.Halfedge
{
    /// <summary>
    /// A class describing a halfedge mesh with additional properties
    /// </summary>
    class HalfedgeMeshAugmented
    {
        /// <summary>
        /// A PlanktonMesh (half-edge mesh)
        /// </summary>
        public Plankton.PlanktonMesh PMesh { get; set; }
        
        #region Constructors 
        /// <summary>
        /// Constructs a Halfedge augmented mesh from
        /// </summary>
        /// <param name="mesh"></param>
        public HalfedgeMeshAugmented(Rhino.Geometry.Mesh mesh)
        {
            PMesh = new Plankton.PlanktonMesh();
            PMesh = mesh.ToPlanktonMesh();
        }
        #endregion
    }
}
