using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using TicketAndShow;
namespace TickedAndShowTest
{

    [TestClass]
    public class ShowTest
    {
        DateTime date1 = DateTime.Now;

        [TestMethod]
        public void SellTickets_WithOneAvailableSeat_ShouldReturnTheTicketOfTheCorrispondendSeat()
        {
            Show show1 = new Show("giovanni rana", date1, 123, 200.3);
            //{Price}€-{Seat}-{IsSold}
            Assert.AreEqual<string> ("203.3€-1-true", show1.SellTickets(204.0));//non ha senso dia errore, ritorna ticket che attraverso il to string dovrebbe essere cosi'
        }
    }
}