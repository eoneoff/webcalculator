using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICalculatorRepository
{
    public interface ICalculatorRepository
    {
        Task<IEnumerable<string>> GetOperations(string ip);
        Task SaveOperation(string ip, string expression);
    }
}
