namespace Application.Services.Parameter
{
    public interface IParameterService
    {
        (string, string) GetTblParameterValue(string parameterName);
        Task<(string, string)> GetTblParameterValueAsync(string parameterName);
        Task<bool> UpdateTblParameterValueAsync(string parameterName, DateTime datenow);
    }
}