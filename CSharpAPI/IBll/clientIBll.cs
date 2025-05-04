using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll
{
    public interface clienttIBll : IBll<Dto.Client>
    {
      Task<Dto.Client> GetClientByIdAsync(string id);
        Task<bool> RegisterAsync(Dto.Client client);

        // Task<int> GetClientByIdAsync(string id);


    }
}
