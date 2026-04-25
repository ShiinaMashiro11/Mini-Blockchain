using Microsoft.AspNetCore.Mvc;

namespace Mini_Blockchain.Controllers
{
    public class BlockchainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
