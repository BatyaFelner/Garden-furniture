using Dal.models;
using IDal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Client : IClientDal
    {
        PatioFurnitureContext db;
        public Client(PatioFurnitureContext db)
        {
            this.db = db;
        }
        public async Task<List<Dto.Client>> GetAllAsync()
        {
            return null;
        }

        public async Task<Dto.Client> GetClientByIdAsync(string id)
          {
              var client = await db.Clients.Where(c => c.Id == id).FirstOrDefaultAsync();

           /*   if (client == null)
              {
                  return new Dto.Client();
              }*/

              return converters.client.ToDtoClient(client);
          }

        public async Task<bool> RegisterAsync(Dto.Client clientDto)
        {
        
            var clientEntity = converters.client.ToEntityClient(clientDto);

            var Client = await db.Clients.FirstOrDefaultAsync(c => c.Id == clientEntity.Id || c.Email == clientEntity.Email);

            if (Client != null)
            {
                return false;
            }

           
            await db.Clients.AddAsync(clientEntity);
            await db.SaveChangesAsync();

            return true; 
        }


    }
}
