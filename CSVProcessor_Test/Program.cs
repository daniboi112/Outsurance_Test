using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using CSVProcessor;

namespace CSVProcessor_Test
{
    class Program
    {
        static frmCSVProcessor form;

        static void Main(string[] args)
        {
            form = new frmCSVProcessor();

            //Assert.AreEqual("success", form.processCSV(@"C:\sandbox\Outsurance\data.csv"));
            Assert.AreEqual("success", form.processCSV(@"C:\sandbox\Outsurance\CSVProcessor\data.csv"));

            Dictionary<string, int> _dicFirstNames = new Dictionary<string, int>();
            _dicFirstNames.Add("Dintwe", 2);
            _dicFirstNames.Add("Daniel", 5);
            _dicFirstNames.Add("Lee", 1);
            _dicFirstNames.Add("Candice", 4);

            Dictionary<string, int> _dicLastNames = new Dictionary<string, int>();
            _dicLastNames.Add("Mohutsioa", 8);
            _dicLastNames.Add("Benson", 5);
            _dicLastNames.Add("Borole", 4);

            Dictionary<string, int> _dicAddresses = new Dictionary<string, int>();
            _dicAddresses.Add("112 Lemonwood Stree", 1);
            _dicAddresses.Add("3827 Unit Extension", 6);
            _dicAddresses.Add("57 Ale Avenue", 2);

            Assert.AreEqual("success", form.writeFrequencyFirstLastNameOutputFiles(_dicFirstNames));

            Assert.AreEqual("success", form.writeFrequencyFirstLastNameOutputFiles(_dicLastNames));

            Assert.AreEqual("success", form.writeFrequencyAddressesOutputFiles(_dicAddresses));
        }
    }
}
