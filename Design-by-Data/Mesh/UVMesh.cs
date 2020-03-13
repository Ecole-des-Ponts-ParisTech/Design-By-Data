using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace Design_by_Data.Mesh
{
    public class UVMesh
    {
        #region Fields
        /// <summary>
        /// The number of faces in the U direction
        /// </summary>
        private int _nU;
        /// <summary>
        /// The number of faces in the V direction
        /// </summary>
        private int _nV;
        /// <summary>
        /// Boolean stating if the surface is periodic in the U direction
        /// </summary>
        private bool _isclosedU;
        /// <summary>
        /// Boolean stating if the surface is periodic in the V direction
        /// </summary>
        private bool _isclosedV;
        #endregion

        #region Properties
        /// <summary>
        /// Vertices as a list of UVMeshVertex
        /// </summary>
        public List<UVMeshVertex> Vertices { get; set; }
        /// <summary>
        /// Faces as a list of UVMeshFace
        /// </summary>
        public List<UVMeshFace> Faces { get; set; }
        /// <summary>
        /// Edges as list of UVMeshEdge
        /// </summary>
        public List<UVMeshEdge> Edges { get; set; }
        /// <summary>
        /// Gets a boolean stating if the mesh is closed (periodic) in the U direction
        /// </summary>
        public bool IsClosedU { get { return (_isclosedU); } }
        /// <summary>
        /// Gets a boolean stating if the mesh is closed (periodic) in the V direction
        /// </summary>
        public bool IsClosedV { get { return (_isclosedV); } }
        /// <summary>
        /// The number of face subdivisions in the U direction
        /// </summary>
        public int NU { get { return (_nU); } }
        /// <summary>
        /// The number of face subdivisions in the V direction
        /// </summary>
        public int NV { get { return (_nV); } }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a UVMesh
        /// </summary>
        /// <param name="nU">Number of faces in the U direction</param>
        /// <param name="nV">Number of faces in the V direction</param>
        /// <param name="points">List of points </param>
        /// <param name="isClosedU">Boolean stating whether the mesh is periodic along U</param>
        /// <param name="isClosedV">Boolean stating whether the mesh is perdiodic along V</param>
        public UVMesh(int nU, int nV, List<Point3d> points, bool isClosedU, bool isClosedV)
        {
            _nU = nU;
            _nV = nV;
            _isclosedU = isClosedU;
            _isclosedV = isClosedV;
            Vertices = new List<UVMeshVertex>();
            Faces = new List<UVMeshFace>();
            for (int i = 0; i < points.Count; i++)
            {
                var vertex = new UVMeshVertex(points[i], i);
                Vertices.Add(vertex);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add all the faces of the mesh
        /// </summary>
        public void AddFaces()
        {
            for (int i = 0; i < (NU * NV); i++)
            {
                Faces.Add(new UVMeshFace(i, this));
            }
        }
        public void AddEdges()
        {
            for (int i = 0; i < (NV+1); i++)
            {
                //Edges.Add(new UVMeshEdge(this,));
                
            }
        }
        #endregion
    }
}
