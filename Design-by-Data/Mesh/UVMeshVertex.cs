using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace Design_by_Data.Mesh
{
    public class UVMeshVertex : IEquatable<UVMeshVertex>
    {
        #region Fields
        private int _index;
        #endregion

        #region Properties
        /// <summary>
        /// Position of the vertex as a Point3d
        /// </summary>
        public Point3d Position { get; set; }
        /// <summary>
        /// Normal at the vertex as a Vector3d
        /// </summary>
        public Vector3d Normal { get; set; }
        /// <summary>
        /// Get the node index
        /// </summary>
        public int Index { get { return (_index); } }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructs a UVMeshVertex from a point
        /// </summary>
        /// <param name="point"></param>
        public UVMeshVertex(Point3d point)
        {
            Point3d point3d = new Point3d(point);
            Vector3d vector3d = new Vector3d(0.0, 0.0, 1.0);
            Position = point3d;
            Normal = vector3d;
        }
        /// <summary>
        /// Constructs a UVMeshVertex from a point and an index
        /// </summary>
        /// <param name="point"></param>
        /// <param name="index"></param>
        public UVMeshVertex(Point3d point, int index)
        {
            Point3d point3d = new Point3d(point);
            Vector3d vector3d = new Vector3d(0.0, 0.0, 1.0);
            Position = point3d;
            Normal = vector3d;
            _index = index;
        }
        #endregion

        #region IEquatable<UVMeshVertex
        public bool Equals(UVMeshVertex other)
        {
            return ((this.Position == other.Position) & (this.Normal == other.Normal));
        }
        #endregion
    }
}
