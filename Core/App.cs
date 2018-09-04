using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace Activity.Core
{
    class App 
    {

        #region Declaration
        #endregion

        #region Constructor
        public App()
        {
        }
        #endregion

        #region HandlerMethod
        #endregion

        #region Method        

        public static string GenerateHashWithSalt(string strPassword, string strSalt) //encrypt
        {
            try
            {
                // merge password and salt together
                string sHashWithSalt = strPassword + strSalt;
                // convert this merged value to a byte array
                byte[] saltedHashBytes = Encoding.UTF8.GetBytes(sHashWithSalt);
                // use hash algorithm to compute the hash
                System.Security.Cryptography.HashAlgorithm algorithm = new System.Security.Cryptography.SHA256Managed();
                // convert merged bytes to a hash as byte array
                byte[] hash = algorithm.ComputeHash(saltedHashBytes);
                // return the has as a base 64 encoded string
                return Convert.ToBase64String(hash);
            }
            catch (InvalidCastException ex)
            {
                throw ex;
            }
        }        

        #endregion        

    }
}