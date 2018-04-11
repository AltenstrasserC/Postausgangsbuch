using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterLib
{
    public static class ObservableCollection
    {
        public static ObservableCollection<T> AsObservableCollection<T>(this List<T> list)
        {
            ObservableCollection<T> c = new ObservableCollection<T>();
            foreach (var item in list)
            {
                c.Add(item);
            }
            return c;
        }
    }
}
