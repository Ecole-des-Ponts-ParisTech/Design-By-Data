using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Design_by_Data.Mesh.Halfedge;

namespace Design_by_Data.Grasshopper_Component
{
    public class LaplacianSmoothing : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the LaplacianSmoothing class.
        /// </summary>
        public LaplacianSmoothing()
          : base("LaplacianSmoothing", "LapSmooth",
              "Laplcian smoothing of a mesh",
              "Design by Data", "MANGT")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddMeshParameter("mesh", "mesh", "a mesh", GH_ParamAccess.item);
            pManager.AddIntegerParameter("nStep", "nStep", "nStep", GH_ParamAccess.item);
            pManager.AddNumberParameter("Lambda", "L", "Damping value", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddMeshParameter("mesh", "mesh", "a mesh", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Rhino.Geometry.Mesh inputmesh = new Rhino.Geometry.Mesh();
            double lambda = 0.0;
            int n = 0;
            DA.GetData(0, ref inputmesh);
            DA.GetData(1, ref n);
            DA.GetData(2, ref lambda);
            HalfedgeMeshAugmented mesh = new HalfedgeMeshAugmented(inputmesh);
            mesh.LaplacianSmoothing(n, lambda);
            DA.SetData(0, mesh.ToRhinoMesh());
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
            get { return new Guid("c1ef1998-ab5c-47c9-8b72-aa45806e2292"); }
        }
    }
}