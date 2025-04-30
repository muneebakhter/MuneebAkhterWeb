using Api.Models;
using Azure.Data.Tables;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Configuration;

namespace Api.Functions;

public class GetAgenciesFunction
{
    private readonly TableClient _table;

    public GetAgenciesFunction(IConfiguration cfg) =>
        _table = new TableClient(cfg["TABLE_CONN"], "Agencies");

    [Function("GetAgencies")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "agencies")]
        HttpRequestData req)
    {
        var list = _table
            .Query<AgencyEntity>(filter: "PartitionKey eq 'AGENCY'")
            .Select(e => e.ToAgencyData())
            .ToList();

        var res = req.CreateResponse(System.Net.HttpStatusCode.OK);
        await res.WriteAsJsonAsync(list);
        return res;
    }
}
