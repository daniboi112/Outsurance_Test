using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CSVProcessor
{
    public partial class frmCSVProcessor : Form
    {
        private const string outputFile1Name = @"C:\CSVOutput\OutputTextFile1.txt";
        private const string outputFile2Name = @"C:\CSVOutput\OutputTextFile2.txt";

        public frmCSVProcessor()
        {
            InitializeComponent();

            lblOutputDesc.Text = string.Empty;
        }

        private void btnOpenCSV_Click(object sender, EventArgs e)
        {
            oDlgCSV.Title = "Select CSV File";
            oDlgCSV.Filter = "CSV files|*.csv";
            oDlgCSV.InitialDirectory = @"C:\";
            oDlgCSV.FileName = string.Empty;

            if (oDlgCSV.ShowDialog() == DialogResult.OK)
            {
                string _csvfilename = oDlgCSV.FileName;

                processCSV(_csvfilename);

                lblOutputDesc.Text = "Output Text Files are At\n\n" + outputFile1Name + "\n\n" + outputFile2Name;
            }
        }

        private void processCSV(string csvFileName)
        {
            Dictionary<string, int> _dicFirstNames = new Dictionary<string, int>();
            Dictionary<string, int> _dicLastNames = new Dictionary<string, int>();
            Dictionary<string, int> _dicAddresses = new Dictionary<string, int>();

            List<string> _listFirstNames = new List<string>();
            List<string> _listLastNames = new List<string>();
            List<string> _listAddresses = new List<string>();

            using (TextFieldParser _csvParser = new TextFieldParser(csvFileName))
            {
                _csvParser.TextFieldType = FieldType.Delimited;
                _csvParser.SetDelimiters(",");
                while (!_csvParser.EndOfData)
                {
                    if (_csvParser.LineNumber > 1)
                    {
                        int _colCnt = 1;
                        string[] _row = _csvParser.ReadFields();
                        foreach (string _column in _row)
                        {
                            if (_colCnt == 1) //for FirstName
                            {
                                _listFirstNames.Add(_column);
                            }
                            if (_colCnt == 2) //for LastName
                            {
                                _listLastNames.Add(_column);
                            }
                            if (_colCnt == 3) //for Address
                            {
                                _listAddresses.Add(_column);
                            }

                            _colCnt += 1;
                        }
                    }
                    else
                    {
                        _csvParser.ReadFields();
                    }

                }

                int _cntFirtstNames = 0;
                foreach (string _firstname in _listFirstNames)
                {
                    if (!_dicFirstNames.ContainsKey(_firstname))
                    {
                        _dicFirstNames.Add(_firstname, 1);
                    }
                    else
                    {
                        _cntFirtstNames = _dicFirstNames[_firstname];
                        _cntFirtstNames += 1;
                        _dicFirstNames[_firstname] = _cntFirtstNames;
                    }

                }
                writeFrequencyFirstLastNameOutputFiles(_dicFirstNames);

                int _cntLastNames = 0;
                foreach (string _lastname in _listLastNames)
                {
                    if (!_dicLastNames.ContainsKey(_lastname))
                    {
                        _dicLastNames.Add(_lastname, 1);
                    }
                    else
                    {
                        _cntLastNames = _dicLastNames[_lastname];
                        _cntLastNames += 1;
                        _dicLastNames[_lastname] = _cntLastNames;
                    }

                }
                writeFrequencyFirstLastNameOutputFiles(_dicLastNames);


                int _cntAddresses = 0;
                foreach (string _address in _listAddresses)
                {
                    if (!_dicAddresses.ContainsKey(_address))
                    {
                        _dicAddresses.Add(_address, 1);
                    }
                    else
                    {
                        _cntAddresses = _dicAddresses[_address];
                        _cntAddresses += 1;
                        _dicAddresses[_address] = _cntAddresses;
                    }
                }
                writeFrequencyAddressesOutputFiles(_dicAddresses);
            }
        }

        private void writeFrequencyFirstLastNameOutputFiles(Dictionary<string, int> dic)
        {
            foreach (KeyValuePair<string, int> _dic in dic.OrderByDescending(v => v.Value).OrderBy(k => k.Key))
            {
                if (!System.IO.Directory.Exists(@"C:\CSVOutput\"))
                {
                    Directory.CreateDirectory(@"C:\CSVOutput\");
                }

                using (System.IO.StreamWriter _sw = new System.IO.StreamWriter(outputFile1Name, true))
                {
                    _sw.WriteLine(_dic.Key + ", " + _dic.Value);
                }
            }

            using (System.IO.StreamWriter _sw = new System.IO.StreamWriter(outputFile1Name, true))
            {
                _sw.WriteLine("\n\n");
            }
        }

        private void writeFrequencyAddressesOutputFiles(Dictionary<string, int> dic)
        {
            foreach (KeyValuePair<string, int> _dic in dic.OrderByDescending(v => v.Value).OrderBy(k => k.Key.Split(' ')[1]))
            {
                if (!System.IO.Directory.Exists(@"C:\CSVOutput\"))
                {
                    Directory.CreateDirectory(@"C:\CSVOutput\");
                }

                using (System.IO.StreamWriter _sw = new System.IO.StreamWriter(outputFile2Name, true))
                {
                    _sw.WriteLine(_dic.Key);
                }
            }
        }
    }
}
