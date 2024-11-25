using PackingHub.Models;

namespace PackingHub.HelperMethods
{
    public class RouteWithAddressArray:Models.Route
    {
        public Address[] addresses;
        public Transport transport;

        public RouteWithAddressArray(Models.Route route, Address[] addresses, Transport transport)
        {
            this.RouteNumber = route.RouteNumber;
            this.AddressesNumbers=route.AddressesNumbers;
            this.ArrivalDate = route.ArrivalDate;
            this.Comments = route.Comments;
            this.DepartureDate = route.DepartureDate;
            this.Transport=route.Transport;
            this.Comments = route.Comments;
            this.addresses=addresses;
            this.transport=transport;
            this.Length=route.Length;
        }
    }
}
