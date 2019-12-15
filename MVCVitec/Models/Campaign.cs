using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCVitec.Models
{
    public class Campaign
    {
        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
        public string CampaignDescription { get; set; }
        public int CampaignPrice { get; set; }
        public int OldPrice { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
