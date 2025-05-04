using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.converters
{
    public class client
    {
        public static Dto.Client ToDtoClient(models.Client? c)
        {
           
            if (c == null)
            {
                return new Dto.Client();  
            }

            Dto.Client cNew = new Dto.Client
            {
                Id = c.Id,
                ClientName = c.ClientName,
                Phone = c.Phone,
                Email = c.Email,
                BearthDate = c.BearthDate
            };

            return cNew;
        }


        public static models.Client ToEntityClient(Dto.Client c)
        {
            return new models.Client
            {
                Id = c.Id,
                ClientName = c.ClientName,
                Phone = c.Phone,
                Email = c.Email,
                BearthDate = c.BearthDate
            };
        }
    }
}

