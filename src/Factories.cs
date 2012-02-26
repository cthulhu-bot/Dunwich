using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Dunwich
{
    /**
     * Deprecated in favor of the RVector class which implements the IEnumerable interface
     * */

    //class RVector : AbstractRVector
    //{
    //    int _size = 0;
    //    string _name = "";
    //    List<object> _container = new List<object>();

    //    public override int size
    //    {
    //        get { return _size; }
    //        set { _size = value; }
    //    }

    //    public override string name
    //    {
    //        get { return _name; }
    //        set { _name = value; }
    //    }

    //    public override List<object> container
    //    {
    //        get { return _container; }
    //        set { _container = value; }
    //    }

    //    public override void add(object item)
    //    {
    //        this.container.Add(item);
    //    }

    //    public override bool remove(object item)
    //    {
    //        try
    //        {
    //            this.container.Remove(item);
    //            return true;
    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e.Message);
    //            return false;
    //        }
    //    }
    //}

    //class RVectorFactory : AbstractRVectorFactory
    //{
    //    public override AbstractRVector GetRVector()
    //    {
    //        return new RVector();
    //    }
    //}

    class RArrayFactory : RArrayFactoryInf
    {
    }

    class RMatrixFactory : RMatrixFactoryInf
    {
    }
}
