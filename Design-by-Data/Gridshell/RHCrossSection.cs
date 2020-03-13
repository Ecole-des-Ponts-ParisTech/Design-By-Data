using System;
using System.Collections.Generic;
using Rhino.Geometry;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_by_Data.Gridshell
{
    /// <summary>
    /// This class contains informations about a Rectangular Hollow section
    /// </summary>
    /// <inheritdoc cref="ICrossSection">
    public class RHCrossSection : ICrossSection, IEquatable<RHCrossSection>
    {
        #region Properties
        /// <summary>
        /// The height of the rectangular hollow cross section in document units.
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double TopThickness { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double BottomThickness { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double MiddleThickness { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Width { get; set; }
        /// <summary>
        /// Gets the position of the center of gravity of the section
        /// </summary>

        #endregion

        #region ICrossSection Properties

        public double Area => throw new NotImplementedException();

        public double InertiaXx => throw new NotImplementedException();

        public double InertiaYy => throw new NotImplementedException();
        public double OffsetY { get { return (1.0 / (TopThickness + BottomThickness) * (TopThickness * (Height - TopThickness / 2.0) - BottomThickness * (Height - BottomThickness / 2.0))); } }

        public double OffsetX => throw new NotImplementedException();
        #endregion

        #region Constructor
        public RHCrossSection(double height, double width, double topthickness, double bottomthickness, double middlethickness)
        {
            Height = height;
            Width = width;
            TopThickness = topthickness;
            BottomThickness = bottomthickness;
            MiddleThickness = middlethickness;
        }
        #endregion

        #region Methods
        public List<PolylineCurve> ToPolylines()
        {
            List<PolylineCurve> result = new List<PolylineCurve>();
            List<Point3d> points = new List<Point3d>();
            #region Create the first polyline
            //Point A
            points.Add(new Point3d(-Width / 2.0, -Height / 2.0, 0));
            //Point B
            points.Add(new Point3d(Width / 2.0, -Height / 2.0, 0));
            //Point C
            points.Add(new Point3d(Width / 2.0, Height / 2.0, 0));
            //Point D
            points.Add(new Point3d(-Width / 2.0, Height / 2.0, 0));
            //Point A
            points.Add(new Point3d(-Width / 2.0, -Height / 2.0, 0));
            PolylineCurve polyline = new PolylineCurve(points);
            #endregion

            points.Clear();
            #region Create the second polyline
            //Point A
            points.Add(new Point3d(-(Width - MiddleThickness) / 2.0, -(Height - BottomThickness) / 2.0, 0));
            //Point B
            points.Add(new Point3d((Width - MiddleThickness) / 2.0, -(Height - BottomThickness) / 2.0, 0));
            //Point C
            points.Add(new Point3d((Width - MiddleThickness) / 2.0, (Height - TopThickness) / 2.0, 0));
            //Point D
            points.Add(new Point3d(-(Width - MiddleThickness) / 2.0, (Height - TopThickness) / 2.0, 0));
            //Point A
            points.Add(new Point3d(-(Width - MiddleThickness) / 2.0, -(Height - BottomThickness) / 2.0, 0));
            PolylineCurve polylineInner = new PolylineCurve(points);
            #endregion
            result.Add(polyline);
            result.Add(polylineInner);
            return (result);
        }
        public List<PolylineCurve> ToPolylines(Plane plane)
        {
            List<PolylineCurve> result = new List<PolylineCurve>();
            //Make your implementation HERE
            return (result);
        }
        #endregion

        #region Methods ICrossSection
        public Curve DrawCrossSection()
        {
            PolylineCurve poly = this.ToPolylines()[0];
            return (poly);
        }
        public Curve DrawCrossSection(Plane plane)
        {
            PolylineCurve poly = this.ToPolylines(plane)[0];
            return (poly);
        }

        public bool Equals(RHCrossSection other)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
