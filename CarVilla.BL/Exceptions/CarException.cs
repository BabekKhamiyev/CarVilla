using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVilla.BL.Exceptions;

public class CarException:Exception
{
    public CarException(string message):base(message)
    {

    }
}
