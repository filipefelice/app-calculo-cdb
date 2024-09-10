using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Infraestrutura;
using MediatR;

namespace Api.UseCases;

public class CalcularCdbUseCase(
    CalcularCdbRequestValidator validator, ICdbService cdbServiceClient) : IRequestHandler<CalcularCdbRequest, CalcularCdbResponse>
{
    private readonly CalcularCdbRequestValidator _validator = validator;
    private readonly ICdbService _cdbServiceClient = cdbServiceClient;

    public async Task<CalcularCdbResponse> Handle(CalcularCdbRequest request, CancellationToken cancellationToken)
    {
        var validator = _validator.Validate(request);

        if (!validator.IsValid)
        {
            throw new ValidationErrorException(validator.Errors);
        }

        var cdb = await _cdbServiceClient.ObterTaxaCdb();

        var calculoDb = new CalcularCdb(request.ValorAporteInicial, request.QuantidadeMeses, cdb.Cdi, cdb.TaxaBancaria);        
        
        var result = new CalcularCdbResponse
        {
            ValorBruto = calculoDb.ValorBruto,
            ValorLiquido = calculoDb.ValorLiquido,
            Desconto = calculoDb.ObterValorDesconto()
        };

        return result;
    }    
}
