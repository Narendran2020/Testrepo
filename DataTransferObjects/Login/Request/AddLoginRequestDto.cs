using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.Login.Request
{
    public class AddLoginRequestDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
