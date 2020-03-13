using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace Design_by_Data.Gridshell
{
        public interface ICrossSection
        {
            #region Properties
            /// <summary>
            /// The cross-section area
            /// </summary>
            double Area { get; }
            /// <summary>
            /// Secondary moment of inertia along the weak axis (x)
            /// </summary>
            double InertiaXx { get; }
            /// <summary>
            /// Secondary moment of inertia along the strong axis (y)
            /// </summary>
            double InertiaYy { get; }
            /// <summary>
            /// The offset along the Y-axis (strong axis)
            /// </summary>
            double OffsetY { get; }
            /// <summary>
            /// The offset along the X-axis (weak axis)
            /// </summary>
            double OffsetX { get; }
            #endregion

            #region Methods
            /// <summary>
            /// Draws the appearant contour of the cross-section in the XY plane. Drawing is made so that the center of gravity of the contour is the point (0,0,0)
            /// </summary>
            /// <returns>A curve</returns>
            Curve DrawCrossSection();
            /// <summary>
            /// Draws the appearant contour of the cross section in a user-specified plane. Drawing is made so that the center of gravity of the contour is the plane origin.
            /// </summary>
            /// <param name="plane">A plane containing the cross-section</param>
            /// <returns></returns>
            Curve DrawCrossSection(Plane plane);
            #endregion
        }
}
