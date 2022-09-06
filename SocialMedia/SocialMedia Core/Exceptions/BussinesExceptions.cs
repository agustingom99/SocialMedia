using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia_Core.Exceptions
{
    public class BussinesExceptions : Exception
    {
        public BussinesExceptions()
        {

        }

        public BussinesExceptions(string message) : base (message)
        {
                
        }
    }
}
