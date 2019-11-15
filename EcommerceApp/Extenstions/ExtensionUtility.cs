using System;
using System.Collections.Generic;
using System.Text;
using EcommerceApp.Entity_Models;

namespace EcommerceApp.Extenstions
{
    static class ExtensionUtility
    {
      public static int Subtract(this Calculator calculator, int firstNumber, int secondNumber)
        {
            
            return firstNumber - secondNumber;
        }
    }
}
