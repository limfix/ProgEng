using System;

namespace lab06.ProductText
{
    class Product
    {
        public string readyText;
        
        public void Add(string part)
        {
            readyText += part;
        }
    }
}
