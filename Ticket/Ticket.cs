namespace TicketAndShow
{
    public class Ticket // perché non internal ^w^ UwU TwT TvT >v<
    {
        public double Price { get; internal set; }
        public int Seat { get; internal set; }
        public bool IsSold { get; internal set; }
        public Ticket(double price, int seat, bool isSold)
        {
            if(price <= 0) { throw new ArgumentOutOfRangeException("invalid price"); }
            Price = price;
            Seat = seat;
            IsSold = isSold;
        }
        public override string ToString()
        {
            return($"{Price}€-{Seat}-{IsSold}");
        }
    }
}
