using System.ComponentModel.DataAnnotations;
using Api.Domain.Interfaces;

namespace Api.Infraestrutura.ExternalApi;

public class CdbService: ICdbService {


    private readonly HttpClient _client;

    public CdbService(HttpClient client)
    {
        _client = client;
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.BaseAddress = new Uri("http://api-cdb:8080/");        
    }

    public async Task<CdbOutput> ObterTaxaCdb()
    {
        var response = await _client.GetFromJsonAsync<CdbOutput>("cdb");

        if (response == null)
            throw new Exception("Nenhum cdb foi encontrado");

        return response;
    }
}
