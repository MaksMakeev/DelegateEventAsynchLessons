using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEventAsynchLessons
{
    internal class Subscriber
    {
        private string _name;
        public Subscriber(string name)
        {
            _name = name;
        }

        public void OnDataReceived(string data)
        {
            Console.WriteLine($"Subscriber '{_name}' received data: {data}");
        }
    }
}
