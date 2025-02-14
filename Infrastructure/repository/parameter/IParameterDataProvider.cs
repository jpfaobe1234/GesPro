namespace Infrastructure.repository.parameter
{
    public interface IParameterDataProvider
    {
        (string, string) GetTblParameterValue(string parameterName);
        Task<(string, string)> GetTblParameterValueAsync(string parameterName);
        Task<bool> UpdateTblParameterValueAsync(string parameterName, DateTime datenow);
    }
}