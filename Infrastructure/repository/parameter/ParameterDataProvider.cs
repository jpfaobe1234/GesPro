using System.Linq;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.repository.parameter
{
    public class ParameterDataProvider : IParameterDataProvider
    {
        private readonly ApplicationDbContext _context;


        public ParameterDataProvider(ApplicationDbContext context)
        {
            _context = context;
        }

        public (string, string) GetTblParameterValue(string parameterName)
        {
            var parameter = _context.Tblparametres
             .Where(x => x.CleParam.Equals(parameterName, StringComparison.OrdinalIgnoreCase))
             .Select(x => new { x.Param1, x.Param2 })
             .FirstOrDefault();
            if (parameter != null)
            {
                return (parameter.Param1, parameter.Param2);
            }
            return ("", "");
        }

        public async Task<(string, string)> GetTblParameterValueAsync(string parameterName)
        {
            try
            {
                var parameter = await _context.Tblparametres
                    .Where(x => x.CleParam.ToLower() == parameterName.ToLower())
                    .Select(x => new { x.Param1, x.Param2 })
                    .FirstOrDefaultAsync();

                if (parameter != null)
                {
                    return (parameter.Param1, parameter.Param2);
                }
                return ("", "");
            }
            catch (Exception ex) { 
                
                return ("", "");
            
            }
        }

        public async Task<bool> UpdateTblParameterValueAsync(string parameterName, DateTime datenow)
        {
            var parameter = await _context.Tblparametres
                .Where(x => x.CleParam.Equals(parameterName, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefaultAsync();
            if (parameter != null)
            {
                parameter.Param1 = datenow.ToString("yyyy-MM-dd");
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}