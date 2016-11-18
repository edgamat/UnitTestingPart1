using System;
using System.Collections.Generic;
using System.Linq;

namespace SLAS.CA.Business
{
    public class FileHelper
    {
        /// <summary>
        /// Replaces invalid characters from file names with underscores.
        /// </summary>
        public static string GetSafeFileName(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }

            var safeFileName = fileName;

            var invalidFileNameChars = System.IO.Path.GetInvalidFileNameChars();

            foreach (var c in invalidFileNameChars)
            {
                safeFileName = safeFileName.Replace(c.ToString(), "_");
            }

            return safeFileName;
        }
    }
}
