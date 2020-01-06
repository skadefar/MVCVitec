using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCVitec.ApiLogic;
using MVCVitec.Data;
using MVCVitec.Models;

namespace MVCVitec.Controllers
{
    public class CampaignsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CampaignConnection connect;
        private readonly ProductConnection connectProduct;

        public CampaignsController(ApplicationDbContext context, ProductConnection productConnection, CampaignConnection campaignConnection)
        {
            connect = campaignConnection;
            connectProduct = productConnection;
            _context = context;
        }

        // GET: Campaigns
        public async Task<IActionResult> Index()
        {
            List<Campaign> campaigns = connect.GetData();
            return View(campaigns);
        }

        // GET: Campaigns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign = await _context.Campaigns.FirstOrDefaultAsync(x => x.CampaignId == id);

            if (campaign == null)
            {
                return NotFound();
            }

            return View(campaign);
        }

        // GET: Campaigns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Campaigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CampaignId,CampaignName,CampaignDescription,CampaignPrice,CampaignRules")] Campaign campaign)
        {
            if (ModelState.IsValid)
            {
                //var selectedProduct = campaign.Products;
                //campaign.OldPrice = selectedProduct;
                string response = connect.PostData(campaign);
                return RedirectToAction(nameof(Index));
            }
            return View(campaign);
        }

        // GET: Campaigns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign = connect.GetData().Find(x => x.CampaignId == id);
            if (campaign == null)
            {
                return NotFound();
            }
            return View(campaign);
        }

        // POST: Campaigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CampaignId,CampaignName,CampaignDescriotion,CampaignPrice,CampaignRules")] Campaign campaign)
        {
            if (id != campaign.CampaignId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    connect.PostData(campaign);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampaignExists(campaign.CampaignId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(campaign);
        }

        // GET: Campaigns/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign = connect.DeleteData(id);
            if (campaign == null)
            {
                return NotFound();
            }

            return View(campaign);
        }

        // POST: Campaigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var campaign = connect.GetData().Find(x => x.CampaignId == id);
            connect.DeleteData(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CampaignExists(int id)
        {
            return connect.GetData().Any(e => e.CampaignId == id);
        }
        //public ActionResult SelectProduct()
        //{
        //    List<Product> listOfProducts = _context.Products.ToList();

        //    List<SelectListItem> products = new List<SelectListItem>();

        //    foreach (Product p in listOfProducts)
        //    {
        //        products.Add(new SelectListItem { Text = "Produkt", Value = p.Name });
        //    }

        //    ViewBag.CampaignProduct = products;
        //    return View();
        //}
    }
}
