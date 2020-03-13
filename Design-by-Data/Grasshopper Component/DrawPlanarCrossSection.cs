using System;
using System.Collections.Generic;
using Design_by_Data.Gridshell;
using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Design_by_Data.Grasshopper_Component
{
    public class DrawPlanarCrossSection : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the DrawPlanarCrossSection class.
        /// </summary>
        public DrawPlanarCrossSection()
          : base("DrawPlanarCrossSection", "Draw Cross Section",
              "Draws a cross-section in a given plane",
              "Design by Data", "MANGT")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("Height", "H", "The cross-section height", GH_ParamAccess.item);
            pManager.AddNumberParameter("Width", "B", "The cross-section width", GH_ParamAccess.item);
            pManager.AddNumberParameter("Top Thickness", "tt", "The thickness of the top of the section", GH_ParamAccess.item);
            pManager.AddNumberParameter("Bottom Thickness", "tb", "The thickness of the bottom of the section", GH_ParamAccess.item);
            pManager.AddNumberParameter("Wall Thickness", "ts", "The wall thickness of the side", GH_ParamAccess.item);
            pManager.AddPlaneParameter("Plane", "plane", "The plane to draw the thickness", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddCurveParameter("Section profile", "polyline", "The ", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            double H = 0.0;
            double B = 0.0;
            double tT = 0.0;
            double tB = 0.0;
            double tM = 0.0;
            Plane plane = new Plane();
            DA.GetData(0, ref H);
            DA.GetData(1, ref B);
            DA.GetData(2, ref tT);
            DA.GetData(3, ref tB);
            DA.GetData(4, ref tM);
            DA.GetData(5, ref plane);
            RHCrossSection rH = new RHCrossSection(H, B, tT, tB, tM);
            Curve result = rH.DrawCrossSection();
            // USE THE FOLLOWING COMMAND INSTEAD OF THE PREVIOUS LINE OF CODE ONCE IT IS IMPLEMENTED
            //Curve result =  rH.DrawCrossSection(plane);
            DA.SetData(0, result);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("c4129b8e-8375-4279-9420-b1c9838c987e"); }
        }
    }
}