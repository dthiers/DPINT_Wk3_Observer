using DPINT_Wk3_Observer.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk3_Observer.ViewModel
{
    public class ArrivalsViewModel : CollectionObserverViewModel<BaggageDestination>
    {
        public ObservableCollection<BaggageDestinationViewModel> BaggageViewModelDestinations { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged("Name"); }
        }

        /**
         * baggeDestinations is een BaggageHandler
         * */
        public ArrivalsViewModel(ObservableCollection<BaggageDestination> baggageHandler)
            : base(baggageHandler)
        {
            //
        }

        public void UpdateDestinations(IEnumerable<BaggageDestination> updatedDestinations)
        {
            // added / changed

            // removed
            var toRemove = from bi in BaggageViewModelDestinations
                           where !updatedDestinations.Any(ui => ui.FlightNumber == bi.FlightNumber)
                           select bi;

            foreach (var remove in toRemove.ToList())
            {
                BaggageViewModelDestinations.Remove(remove);
            }

        }

        protected override void Initialize()
        {
            BaggageViewModelDestinations = new ObservableCollection<BaggageDestinationViewModel>();
        }

        protected override void OnAdd(BaggageDestination subject)
        {
            // 
            this.BaggageViewModelDestinations.Add(new BaggageDestinationViewModel(subject));
        }

        protected override void OnRemove(BaggageDestination subject)
        {
            //
            var toRemove = BaggageViewModelDestinations.Where(bvm => bvm.FlightNumber == subject.FlightNumber).FirstOrDefault();
            BaggageViewModelDestinations.Remove(toRemove);

            /**
             * 
             * */
            base.Cleanup();
        }
    }
}
