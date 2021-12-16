#region

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

#endregion

namespace GiteaClient.Core.Assets
{
    public static class GlobalFunc
    {
        public static ObservableCollection<T> ListToObservable<T>(IEnumerable<T> list)
        {
            return new ObservableCollection<T>(list);
        }

        public static ObservableCollection<T> ListToReversedObservable<T>(IEnumerable<T> list)
        {
            return new ObservableCollection<T>(list.Reverse());
        }
    }
}