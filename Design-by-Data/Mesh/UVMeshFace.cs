using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_by_Data.Mesh
{
    public class UVMeshFace
    {
        #region Fields
        private UVMesh _uvMesh;
        private int _index;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the parent mesh of the face
        /// </summary>
        public UVMesh ParentMesh { get { return (_uvMesh); } }
        /// <summary>
        /// Gets the index of the face
        /// </summary>
        public int Index { get { return (_index); } }
        #endregion

        #region Constructors
        public UVMeshFace(int index, UVMesh mesh)
        {
            _index = index;
            _uvMesh = mesh;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Returns a boolean stating if the face is on a boundary
        /// </summary>
        /// <returns></returns>
        public bool isOnBoundary()
        {
            //The mesh is closed in U and V direction, it has no boundaries
            if ((_uvMesh.IsClosedU) & (_uvMesh.IsClosedV))
            {

                return (false);
            }
            //The mesh is closed in the U direction, only possibilities are faces in the first and last row
            else if (_uvMesh.IsClosedU)
            {
                return ((Index / _uvMesh.NU == 0) | (Index / _uvMesh.NU == _uvMesh.NV));
            }
            else if (_uvMesh.IsClosedV)
            {
                return ((Index % (_uvMesh.NU + 1) == 0) | (Index / (_uvMesh.NU + 1) == _uvMesh.NU));
            }
            else
            {
                return ((Index / _uvMesh.NU == 0) | (Index / _uvMesh.NU == _uvMesh.NV) | (Index % (_uvMesh.NU + 1) == 0) | (Index % (_uvMesh.NU + 1) == _uvMesh.NU));
            }
        }
        public List<UVMeshVertex> GetFaceVertices()
        {
            List<UVMeshVertex> result = new List<UVMeshVertex>();
            if ((!_uvMesh.IsClosedU) & (!_uvMesh.IsClosedV))
            {
                //Row index of the face
                int i = _index / _uvMesh.NU;
                //Column index of the face
                int j = _index % _uvMesh.NU;
                result.Add(_uvMesh.Vertices[i * (_uvMesh.NU + 1) + j]);
                result.Add(_uvMesh.Vertices[i * (_uvMesh.NU + 1) + j + 1]);
                result.Add(_uvMesh.Vertices[(i + 1) * (_uvMesh.NU + 1) + j + 1]);
                result.Add(_uvMesh.Vertices[(i + 1) * (_uvMesh.NU + 1) + j]);
            }
            return (result);
        }
        #endregion
    }
}
