using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #endregion

        #region  Properties
        /// <summary>
        /// Gets the parent vertex of the edge
        /// </summary>
        public UVMesh ParentMesh { get { return (_parentmesh); } }
        #endregion

        #region Constructors
        public UVMeshEdge(UVMesh parentMesh, UVMeshVertex start, UVMeshVertex end)
        {
            _start=start;
            _end=end;
            _parentmesh = parentMesh;
        }
        #endregion
    }
}
