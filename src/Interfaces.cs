using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dunwich
{
    abstract class AbstractRVectorFactory
    {
        public abstract AbstractRVector GetRVector();
    }

    abstract class AbstractRVector
    {
        // Container for the Vector values
        public abstract List<object> container { get; set; }

        public abstract int size { get; set; }
        public abstract void add(object item);
        public abstract Boolean remove(object item);
        public abstract string name { get; set; }
    }

    abstract class RArrayFactoryInf
    {
    }

    abstract class RArrayInf
    {
    }

    abstract class RMatrixFactoryInf
    {
    }

    abstract class RMatrixInf
    {
    }
}
