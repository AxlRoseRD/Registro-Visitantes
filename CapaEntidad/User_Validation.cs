using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class User_Validation
    {
        private bool username = false;
        private bool password = false;
        private bool admin = false;

        public bool Username { get => username; set => username = value; }
        public bool Password { get => password; set => password = value; }
        public bool Admin { get => admin; set => admin = value; }
    }
}
