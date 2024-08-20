using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        protected abstract IEnumerable<object> GetAtomicValue();
        public bool Equals(ValueObject? other)
        {
            if(other == null||other.GetType()!=GetType()) return false;

            var thisValue = GetAtomicValue().GetEnumerator();
            var otheValue = other.GetAtomicValue().GetEnumerator();
            while (thisValue.MoveNext() && otheValue.MoveNext())
            {
                if (thisValue.Current != null &&
                    !thisValue.Current.Equals(otheValue.Current)) return false;
            }
            return thisValue.MoveNext() && otheValue.MoveNext();
        }
        public override bool Equals(object? obj)
        {
            return Equals(obj as ValueObject);
        }
        public override int GetHashCode()
        {
            return GetAtomicValue()
                    .Select(x=>x!=null?x.GetHashCode():0)
                    .Aggregate((x,y)=>x^y);
        }
        public static bool operator ==(ValueObject left,ValueObject right)
        {
            return left.Equals(right)&left!=null;
        }
        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !(left==right);
        }

    }
}
