using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace Design_by_Data
{
    public class DesignbyDataInfo : GH_AssemblyInfo
  {
    public override string Name
    {
        get
        {
            return "DesignbyData";
        }
    }
    public override Bitmap Icon
    {
        get
        {
            //Return a 24x24 pixel bitmap to represent this GHA library.
            return null;
        }
    }
    public override string Description
    {
        get
        {
            //Return a short string describing the purpose of this GHA library.
            return "";
        }
    }
    public override Guid Id
    {
        get
        {
            return new Guid("c67bd863-c1a5-41f3-91f3-e2393cd29e12");
        }
    }

    public override string AuthorName
    {
        get
        {
            //Return a string identifying you or your company.
            return "Ecole des ponts Paristech";
        }
    }
    public override string AuthorContact
    {
        get
        {
            //Return a string representing your preferred contact details.
            return "";
        }
    }
}
}
