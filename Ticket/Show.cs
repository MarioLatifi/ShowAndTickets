using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketAndShow
{//NON DIAMO RESTO
    public class Show
    {
        private string _title;
        private int _ticketNum;
        public DateTime Data { get; private set; }
        public double Price { get; private set; }
        public int TicketNum
        {
            get { return _ticketNum; }
            private set
            {
                if (value < 0) { throw new ArgumentOutOfRangeException("invalid num of seats"); }
                _ticketNum = value;
            }
        }
        public string Title
        {
            get { return _title; }
            private set
            {
                if (string.IsNullOrEmpty(value)) { throw new ArgumentNullException("Invalid title"); }
                _title = value;
            }
        }
        public Ticket[] AvailableTickets { get; private set; }
        public Show(string title, DateTime data, int ticketNum, double price)
        {
            Title = title;
            Data = data;
            TicketNum = ticketNum;
            Price = price;
            AvailableTickets = new Ticket[TicketNum];
            for (int i = 0; i < TicketNum; i++)
            {
                AvailableTickets[i] = new Ticket(Price, i + 1, false);
            }
        }
        public Ticket SellTickets(int seat, double money)
        {
            if (seat < 0 || seat > AvailableTickets.Length) { throw new ArgumentOutOfRangeException("Invalid Seat"); }
            if (money < AvailableTickets[1].Price) { throw new ArgumentOutOfRangeException("Insufficient money"); }
            if (!AvailableTickets[seat - 1].IsSold) { throw new Exception("one or more seats are unavailable"); }
            AvailableTickets[seat - 1].IsSold = true;
            return AvailableTickets[seat - 1];
        }
        public Ticket SellTickets(double money)
        {
            if (money <= AvailableTickets[1].Price) { throw new ArgumentOutOfRangeException("Insufficient money"); }
            bool isSold = false;
            int counter = 0;
            while (!isSold || counter == AvailableTickets.Length)
            {
                if (!AvailableTickets[counter].IsSold)
                {
                    isSold = true;
                    AvailableTickets[counter].IsSold = true;
                }
                counter++;
            }
            if (!isSold) { throw new Exception("There are no seats available"); }
            return AvailableTickets[counter];
        }
        public void SellTickets(int[] seats, double money)
        {
            for (int i = 0; i < seats.Length; i++)
            {
                SellTickets(seats[i]);
                money -= AvailableTickets[0].Price;
            }
        }
        public void SellMultipleTicketsButConsecutive(int qtaOfTickets, double money)
        {
            if (qtaOfTickets <= 0) { throw new ArgumentOutOfRangeException("non è valido il numero di ticket che vuoi comprare"); }
            for (int i = 0; i < qtaOfTickets; i++)
            {
                SellTickets(money);
                money -= AvailableTickets[0].Price;
            }
        }
    }
}
