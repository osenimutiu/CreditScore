using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.DemoAttribute
{
    public interface IDemoRetailRepository
    {
        void ApproveAttribute(int param1, string param2);
        void DeclineAttribute(int param1, string param2);
        bool InsertNewCustomerScore(string param1, string param2, string param3, string param4, double param5);
        void ReverseAttribute(int param1);
    }
}
