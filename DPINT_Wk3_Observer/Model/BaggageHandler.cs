using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk3_Observer.Model
{
    public class BaggageHandler : ObservableCollection<BaggageDestination>
    {

        public BaggageHandler()
        {
            //
        }

        // Called to indicate all baggage is now unloaded.
        public void IncomingFlight(int flightNo, string from)
        {
            var destination = new BaggageDestination(flightNo, from, null);
            base.Add(destination);
        }

        public void AssignBelt(int flightNo, int beltNo)
        {
            var destination = base.Items.FirstOrDefault(i => i.FlightNumber == flightNo);
            if(destination != null)
            {
                destination.Belt = beltNo;
            }
        }

        public void ClearBelt(int flightNo)
        {
            var destination = base.Items.FirstOrDefault(i => i.FlightNumber == flightNo);
            if (destination != null) { 
                // TODO: Straks ook de destination Disposen (dan worden de juiste seintjes gegeven)
                base.Remove(destination);
            }
        }
    }
}
