
using Infrastructure.repository.parameter;

namespace Application.Services.Parameter
{
    public class ParameterService : IParameterService
    {
        private readonly IParameterDataProvider _parameterProvider;

        public ParameterService(IParameterDataProvider parameterProvider)
        {
            _parameterProvider = parameterProvider;
        }

        public (string, string) GetTblParameterValue(string parameterName)
        {
            return _parameterProvider.GetTblParameterValue(parameterName);
        }

        public async Task<(string, string)> GetTblParameterValueAsync(string parameterName)
        {
            return await _parameterProvider.GetTblParameterValueAsync(parameterName);
        }

        public async Task<bool> UpdateTblParameterValueAsync(string parameterName, DateTime datenow)
        {
            return await _parameterProvider.UpdateTblParameterValueAsync(parameterName, datenow);
        }
    }
}