using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiteaClient.Core.Assets
{
    public static class GlobalFunc
    {
        public static ObservableCollection<T> ListToObservable<T>(ICollection<T> list)
        {
            return new ObservableCollection<T>(list);
        }
    }
}
