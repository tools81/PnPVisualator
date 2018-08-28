using System;
using System.Collections.Generic;
using System.Text;

namespace Pen_and_Paper_Visualator.Class
{
    class TradeObject
    {
        public string firstParty { get; set; }
        public string secondParty { get; set; }
        public List<Guid> firstPartyItems { get; set; }
        public List<Guid> secondPartyItems { get; set; }
        public string itemName { get; set; }
        public int itemCost { get; set; }
        public Guid itemID { get; set; }
        public string message { get; set; }
        public string character { get; set; }
        public string itemType { get; set; }
    }
}
