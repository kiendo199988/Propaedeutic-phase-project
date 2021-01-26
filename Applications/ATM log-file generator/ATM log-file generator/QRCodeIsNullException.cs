using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_log_file_generator
{
    class QRCodeIsNullException : Exception
    {
        public QRCodeIsNullException():base()
        {

        }
        public QRCodeIsNullException(String message) : base(message)
        {

        }
    }
}
