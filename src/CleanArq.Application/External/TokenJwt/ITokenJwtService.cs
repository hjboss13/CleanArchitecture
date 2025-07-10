using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArq.Application.External.TokenJwt
{
    public interface ITokenJwtService
    {
        string Execute(string idUser);
    }
}
