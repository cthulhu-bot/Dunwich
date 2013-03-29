using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Linq.Expressions;

namespace Dunwich
{
    /**
     * Class:  RVector
     * Description:
     * 
     * */
    class RVector : IEnumerable
    {
        private List<object> values;
        private string name = "test ";
        private RFileWriter rw;

        /**
         * Public constuctor instantiating RFileWriter
         * */
        public RVector()
        {
            values = new List<object>();
            rw = new RFileWriter();
            rw.WriteToRFile(Name + "<- c()\n");
        }

        /**
         * Variable paramater initalizer
         * */
        public RVector(params object[] args)
        {
            values = new List<object>();
            foreach (object o in args) values.Add(o);

            rw = new RFileWriter();
            rw.WriteToRFile(Name + "<- c(");
            for (int i = 0; i < args.Length; i++)
            {
                rw.WriteToRFile(args[i].ToString());
                if (i+1 < args.Length) rw.WriteToRFile(", ");
            }
            rw.WriteToRFile(")\n");
        }

        /**
         * List object collection initalizer
         * */
        public RVector(List<object> values)
        {
            values = new List<object>();
            foreach (object o in values) values.Add(o);

            rw = new RFileWriter();
            rw.WriteToRFile(Name + "<- c(");
            for (int i = 0; i < values.Count; i++)
            {
                rw.WriteToRFile(values[i].ToString());
                if (i + 1 < values.Count) rw.WriteToRFile(", ");
            }
            rw.WriteToRFile(")\n");
        }

        /**
         * Function:    Init
         * Description: Required in order to grab the C# variable name to be passed to the R File
         * */
        public void Init(Expression<Func<RVector>> expr)
        {
            var body = ((MemberExpression)expr.Body);
            this.name = body.Member.Name;
        }

        /**
         * Function:  Add
         * Description:
         * Parameters:
         * */
        public void Add(object value)
        {
            rw.WriteToRFile(Name + "<- c(");
            foreach (object obj in values)
            {
                rw.WriteToRFile(obj + ", ");
            }
            rw.WriteToRFile(value.ToString() + ")\n");
            Values.Add(value);
        }

        /**
         * Function:    Remove
         * Description:
         * Parameters:
         * */
        public void Remove(object value)
        {
            Values.Remove(value);
        }

        // The nested class inheriting the IEnumerator interface is required because the GetEnumerator() method returns
        // an IEnumerator interface and is required in order for this class to be iterable
        private class Enumerator : IEnumerator
        {
            List<object> valuesEnum = null;
            int position = -1;
            public Enumerator(List<object> valuesArg)
            {
                valuesEnum = valuesArg;
            }
            IEnumerator GetEnumerator()
            {
                return (IEnumerator)this;
            }
            public bool MoveNext()
            {
                position++;
                return (position < valuesEnum.Count());
            }
            public void Reset()
            { position = 0; }
            public object Current
            {
                get
                {
                    try
                    {
                        return valuesEnum[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
            }
        } // End IEnumerator nested class

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(Values);
        }

        /**
         * Override multiplication operator to multiply 2 vectors together
         * */
        public static int operator *(RVector r1, RVector r2)
        {
            int sum = 0;
            if (r1.size != r2.size) return -1;
            for (int i = 0; i < r1.size; i++)
            {
                sum = sum + Convert.ToInt32(r1[i]) * Convert.ToInt32(r2[i]);
            }
            return sum;
        }

        public int size
        {
            get { return this.values.Count; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name= value; }
        }

        public List<object> Values
        {
            get { return this.values; }
            set { this.values = value; }
        }

        public object this[int index]
        {
            get
            {
                return Values[index];
            }

            set
            {
                Values[index] = value;
            }
        }
    }

}
