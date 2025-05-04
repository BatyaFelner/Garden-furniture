using IBll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class funcClient:clienttIBll
    { 

           public IDal.IClientDal delc;

    public funcClient(IDal.IClientDal c)
    {
        this.delc = c;
    }

            public Task<Dto.Client> GetClientByIdAsync(string id)
             {
                 return delc.GetClientByIdAsync(id);
             }

        /*  public Task<int> GetClientByIdAsync(string id)
          {
              return delc.GetClientByIdAsync(id);
          }*/
        public Task<List<Dto.Client>> GetAllAsync()
        {
          
            return delc.GetAllAsync();
        }
        public Task<bool> RegisterAsync(Dto.Client client)
        {

            return delc.RegisterAsync(client);
        }
    }
}
