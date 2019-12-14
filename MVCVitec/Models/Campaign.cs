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
        public string CampaignDescriotion { get; set; }
        public int CampaignPrice { get; set; }
        public string CampaignRules { get; set; }


    }
}
