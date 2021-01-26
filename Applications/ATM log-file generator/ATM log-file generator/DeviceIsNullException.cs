using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_log_file_generator
{
    class DeviceIsNullException:Exception
    {
        public DeviceIsNullException():base()
        {

        }
        public DeviceIsNullException(String message):base(message)
        {

        }
    }
}
