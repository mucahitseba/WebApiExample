using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DAL
{
    public class UsersDAL:BaseDAL
    {
        public Users GetUserByApiKey(string apiKey)
        {
            return db.Users.FirstOrDefault(x => x.UserKey.ToString() == apiKey);
            
        }
    }
}
