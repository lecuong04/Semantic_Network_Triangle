using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Semantic_Network_Triangle.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public SemanticNetworkTriangle Triangle { get; set; } = new SemanticNetworkTriangle();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPostSubmit(double cA = 0, double cB = 0, double cC = 0, double ea = 0, double eb = 0, double ec = 0, double aS = 0, double hA = 0, double hB = 0, double hC = 0, double cP = 0, double pR = 0, double iR = 0)
        {
            Triangle.A = cA;
            Triangle.B = cB;
            Triangle.C = cC;
            Triangle.a = ea;
            Triangle.b = eb;
            Triangle.c = ec;
            Triangle.S = aS;
            Triangle.hA = hA;
            Triangle.hB = hB;
            Triangle.hC = hC;
            Triangle.P = cP;
            Triangle.R = pR;
            Triangle.r = iR;
            Triangle.Calculate();
            return Page();
        }

        public IActionResult OnPostReset()
        {
            Triangle = new SemanticNetworkTriangle();
            return Page();
        }
    }
}
