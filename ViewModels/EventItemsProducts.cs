using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test.Models;

namespace Test.ViewModels
{
    public class EventItemsProducts
    {
        public List<EventItem> eventItems { get; set; }
        public List<Product> products { get; set; }
        public int EventId { get; set; }
    }
}