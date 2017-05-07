using DPINT_Wk3_Observer.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk3_Observer.ViewModel
{
    public abstract class CollectionObserverViewModel<T> : ViewModelBase where T : class
    {
        private ObservableCollection<T> _collection;

        public CollectionObserverViewModel(ObservableCollection<T> collection)
        {
            _collection = collection;
            _collection.CollectionChanged += Collection_CollectionChanged;

            Initialize();
            foreach (var item in collection)
            {
                OnAdd(item);
            }
        }

        protected abstract void Initialize();

        private void Collection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                OnAdd(e.NewItems[0] as T);
            else if (e.Action == NotifyCollectionChangedAction.Remove)
                OnRemove(e.OldItems[0] as T);
        }

        protected abstract void OnAdd(T subject);
        protected abstract void OnRemove(T subject);

        public override void Cleanup()
        {
            base.Cleanup();
            _collection.CollectionChanged -= Collection_CollectionChanged;
        }
    }
}
