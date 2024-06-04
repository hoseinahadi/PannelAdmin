using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Token
{
    public interface IGenerateNewToken
    {
        string GenerateNewToken(int userId);
    }
}
