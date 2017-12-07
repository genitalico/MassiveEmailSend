using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MassiveEmailSend
{
    public class ReadJson
    {
        #region PrivateVars
        private bool _Result;
        private JsonModel _JsonModel;
        #endregion

        #region Properties
        public bool Result
        {
            get
            {
                return this._Result;
            }
        }

        public JsonModel JsonModel
        {
            get
            {
                return this._JsonModel;
            }
        }
        #endregion

        #region Ctor
        public ReadJson()
        {
            
        }
        #endregion


        #region PublicMethods
        public void ParseJson(string filePath)
        {
            try
            {
                var textFile = System.IO.File.ReadAllText(filePath);

                this._JsonModel = JsonConvert.DeserializeObject<JsonModel>(textFile);

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
