using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.HealthRecordManagement.Contracts.Events.UserExist
{
    public class UserExistResponse
    {
        public string IdNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Exists { get; set; }

    }
}
