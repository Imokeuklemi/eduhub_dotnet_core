using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using eduhub.Models;
using SelectPdf;


namespace eduhubApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
   //private readonly IGeneratePdf _generatePdf;

    public HomeController(ILogger<HomeController> logger)
    {
   
        _logger = logger;
    }

    public IActionResult Index(string getPdf)
    {
       
       return View();
    }
    public IActionResult getPdf(string htmlString)
    {
    var mobileView = new HtmlToPdf();
        mobileView.Options.WebPageWidth = 480;
 
        var tabletView = new HtmlToPdf();
        tabletView.Options.WebPageWidth = 1024;
 
        var fullView = new HtmlToPdf();
        fullView.Options.WebPageWidth = 1920;
 
        var pdf = mobileView.ConvertUrl("https://www.roundthecode.com/");
        pdf.Append(tabletView.ConvertUrl("https://www.roundthecode.com/"));
        pdf.Append(fullView.ConvertUrl("https://www.roundthecode.com/"));
 
        var pdfBytes = pdf.Save();
 
        return File(pdfBytes, "application/pdf");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
