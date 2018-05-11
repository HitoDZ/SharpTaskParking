using System;
using System.Collections.Generic;

namespace SharpTask1
{
    public class CarType
    {
        List<string> carTypes = new List<string>(){"PASSENGER", "TRUCK", "BUSS", "MOTOCYCLE"};
        enum cTypes{
            PASSENGER, TRUCK, BUSS, MOTOCYCLE
        }
    }
}