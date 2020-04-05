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
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nStep"></param>
        /// <param name="lambda">Damping factor, comprised between 0 and 1, 1 is the full laplacian smoothing step</param>
        public void LaplacianSmoothing(int nStep, double lambda)
        {
            
            for (int k = 0; k < nStep; k++)
            {
                List<double> x = new List<double>();
                List<double> y = new List<double>();
                List<double> z = new List<double>();
                for (int i = 0; i < PMesh.Vertices.Count; i++)
                {
                    var neighbours = PMesh.Vertices.GetVertexNeighbours(i);
                    
                    int n = neighbours.Length;
                    var dx = 0.0;
                    var dy = 0.0;
                    var dz = 0.0;
                    if(PMesh.Vertices.IsBoundary(i))
                    {
                        x.Add(PMesh.Vertices[i].X);
                        y.Add(PMesh.Vertices[i].Y);
                        z.Add(PMesh.Vertices[i].Z);
                    }
                    else
                    {
                        for (int j = 0; j < n; j++)
                        {
                            dx += PMesh.Vertices[neighbours[j]].X / n;
                            dy += PMesh.Vertices[neighbours[j]].Y / n;
                            dz += PMesh.Vertices[neighbours[j]].Z / n;
                        }
                        x.Add(lambda * dx + (1 - lambda) * PMesh.Vertices[i].X);
                        y.Add(lambda * dy + (1 - lambda) * PMesh.Vertices[i].Y);
                        z.Add(lambda * dz + (1 - lambda) * PMesh.Vertices[i].Z);
                    }
                }
                for (int i = 0; i < PMesh.Vertices.Count; i++)
                {
                    PMesh.Vertices[i].X = (float)x[i];
                    PMesh.Vertices[i].Y = (float)y[i];
                    PMesh.Vertices[i].Z = (float)z[i];
                }
            }
        }
        public Rhino.Geometry.Mesh ToRhinoMesh()
        {
            return (PMesh.ToRhinoMesh());
        }
        
        #endregion
    }
}
