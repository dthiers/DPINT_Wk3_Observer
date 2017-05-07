using DPINT_Wk3_Observer.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk3_Observer.ViewModel
{
    public class BaggageDestinationViewModel : ViewModelBase, IObserver<BaggageDestination>
    {
        private IDisposable _unsubscriber;
        private int _flightNumber;
        public int FlightNumber
        {
            get { return _flightNumber; }
            set { _flightNumber = value; RaisePropertyChanged("FlightNumber"); }
        }

        private string _from;
        public string From
        {
            get { return _from; }
            set { _from = value; RaisePropertyChanged("From"); }
        }

        private int? _belt;
        public int? Belt
        {
            get { return _belt; }
            set { _belt = value; RaisePropertyChanged("Belt"); }
        }
        
        public BaggageDestinationViewModel(BaggageDestination destination)
        {
            Belt = destination.Belt;
            From = destination.From;
            FlightNumber = destination.FlightNumber;

            _unsubscriber = destination.Subscribe(this);
        }

        /**
         * Observable roept zijn observers met deze methode aan
         * */
        public void OnNext(BaggageDestination value)
        {
            var val = value;
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        /**
         * Als de observable geen updates meer geeft
         * */
        public void OnCompleted()
        {
            _unsubscriber.Dispose();
        }
    }
}
