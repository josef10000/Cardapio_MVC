using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CardapioMVC.Models;
 


public class CaloriasController : Controller
{
    private HttpClient _httpClient;

    public CaloriasController()
    {
        _httpClient = new HttpClient();
    }

    [HttpPost]
    public async Task<IActionResult> ObterCalorias(string descricao)
    {
        string url = $"https://caloriasporalimentoapi.herokuapp.com/api/calorias/?descricao={descricao}";

        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var alimentos = JsonConvert.DeserializeObject<List<CaloriasModel>>(content);

            return View("Calorias", alimentos);
        }

        return View("Error");
    }

    public IActionResult Calorias()
    {
        return View();
    }
}

