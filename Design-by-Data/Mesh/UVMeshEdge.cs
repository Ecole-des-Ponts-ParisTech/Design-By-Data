using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace Design_by_Data.Mesh
{
    public class UVMeshEdge
    {
        #region Fields
        /// <summary>
        /// The parent mesh of the edge
        /// </summary>
        private UVMesh _parentmesh;
        /// <summary>
        /// The starting vertex of the edge
        /// </summary>
        private UVMeshVertex _start;
        /// <summary>
        /// The end vertex of the edge
        /// </summary>
        private UVMeshVertex _end;
        private int _index;
        #endregion

        #region  Properties
        /// <summary>
        /// Gets the parent vertex of the edge
        /// </summary>
        public UVMesh ParentMesh { get { return (_parentmesh); } }
        /// <summary>
        /// Gets the edge index
        /// </summary>
        public int Index { get { return (_index); } }
        public UVMeshVertex Start { get { return (_start); } }
        public UVMeshVertex End { get { return (_end); } }
        #endregion

        #region Constructors
        public UVMeshEdge(UVMesh parentMesh, UVMeshVertex start, UVMeshVertex end, int index)
        {
            _start = start;
            _end = end;
            _parentmesh = parentMesh;
            _index = index;
        }
        #endregion

        #region Method
        public Line ToLine()
        {
            return (new Line(Start.Position, End.Position));
        }
        #endregion
    }
}
