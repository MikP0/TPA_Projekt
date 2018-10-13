using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Model.Reflection
{
    [DataContract]
    public class Tuple4<T1, T2, T3, T4>
    {
        [DataMember]
        public T1 Item1 { get; set; }
        [DataMember]
        public T2 Item2 { get; set; }
        [DataMember]
        public T3 Item3 { get; set; }
        [DataMember]
        public T4 Item4 { get; set; }

        public static implicit operator Tuple4<T1, T2, T3, T4>(Tuple<T1, T2, T3, T4> t)
        {
            return new Tuple4<T1, T2, T3, T4>()
            {
                Item1 = t.Item1,
                Item2 = t.Item2,
                Item3 = t.Item3,
                Item4 = t.Item4
            };
        }

        public static implicit operator Tuple<T1, T2, T3, T4>(Tuple4<T1, T2, T3, T4> t)
        {
            return Tuple.Create(t.Item1, t.Item2, t.Item3, t.Item4);
        }
    }
}
