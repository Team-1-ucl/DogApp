using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogApp.Shared.EntityModelsTrack;

namespace DogApp.Shared.EntityModelsAuth
{
    public class User 
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}
