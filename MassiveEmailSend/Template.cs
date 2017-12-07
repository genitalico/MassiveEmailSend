using System;
using System.Collections.Generic;
using System.Text;

namespace MassiveEmailSend
{
    public class Template
    {
        #region PrivateVars
        public bool _Result;
        public string _TemplateText;
        #endregion

        #region Properties
        public bool Result
        {
            get
            {
                return this._Result;
            }
        }

        public string TemplateText
        {
            get
            {
                return this._TemplateText;
            }
        }
        #endregion

        #region Ctor
        public Template()
        {

        }
        #endregion

        #region PublicMethods
        public void ReadTemplate(string filePath)
        {
            try
            {
                var textFile = System.IO.File.ReadAllText(filePath);

                this._TemplateText = textFile;

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
