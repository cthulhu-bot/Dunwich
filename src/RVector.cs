﻿using System;
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
        private string name;

        public RVector()
        {
            this.values = new List<object>();
        }

        /**
         * Function:    Init
         * Description: Required in order to grab the C# variable name to be passed to the R File
         * */
        public void Init(Expression<Func<RVector>> expr)
        {
            var body = ((MemberExpression)expr.Body);
            //Console.WriteLine("VectorName = {0}", body.Member.Name);
            //this.name = body.Member.Name;
            new RFuncs().WriteCommand(body.Member.Name + "\n");
        }

        /**
         * Function:  Add
         * Description:
         * Parameters:
         * */
        public void Add(object value)
        {
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