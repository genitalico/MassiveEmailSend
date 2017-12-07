using System;
using System.Collections.Generic;
using System.Text;

namespace MassiveEmailSend
{
    public class ReadCsv
    {
        #region PrivateVars
        private bool _Result;
        private List<CsvModel> _ListEmail;
        #endregion

        #region Properties
        public bool Result
        {
            get
            {
                return this._Result;
            }
        }

        public List<CsvModel> ListEmail
        {
            get
            {
                return this._ListEmail;
            }
        }
        #endregion

        #region Ctor
        public ReadCsv()
        {

        }
        #endregion

        #region PrivateMethods
        public void ParseCsv(string filePath)
        {
            try
            {
                var linesFile = System.IO.File.ReadAllLines(filePath);

                this._ListEmail = new List<CsvModel>();


                foreach (var line in linesFile)
                {
                    string[] values = line.Split(',');

                    this._ListEmail.Add(new CsvModel()
                    {
                        Email = values[0],
                        Name = values[1]
                    });
                }

                this._Result = true;

            }
            catch(Exception ex)
            {
                this._Result = false;
            }
        }
        #endregion
    }
}
