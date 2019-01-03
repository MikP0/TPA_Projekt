using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Model.Reflection
{
    public class Tuple3<T1, T2, T3>
    {
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }
        public T3 Item3 { get; set; }

        public static implicit operator Tuple3<T1, T2, T3>(Tuple<T1, T2, T3> t)
        {
            return new Tuple3<T1, T2, T3>()
            {
                Item1 = t.Item1,
                Item2 = t.Item2,
                Item3 = t.Item3
            };
        }

        public static implicit operator Tuple<T1, T2, T3>(Tuple3<T1, T2, T3> t)
        {
            return Tuple.Create(t.Item1, t.Item2, t.Item3);
        }
    }
}
