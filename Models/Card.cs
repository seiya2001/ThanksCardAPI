using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThanksCardAPI.Models
{
    public class Card
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Title { get; set; }
        public string Date { get; set; }
        public long Content { get; set; }
        public string Like { get; set; }
    }
}
