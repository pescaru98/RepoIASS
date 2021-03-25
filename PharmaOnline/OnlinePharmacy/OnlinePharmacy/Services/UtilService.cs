using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace OnlinePharmacy.Services
{
    public class UtilService
    {
        public byte[] convertStreamToByteArray(Stream pictureStream)
        {
            byte[] bytes = new byte[pictureStream.Length + 10];
            int numBytesToRead = (int)pictureStream.Length;
            int numBytesRead = 0;
            while (numBytesToRead > 0)
            {
                int n = pictureStream.Read(bytes, numBytesRead, 10);
                numBytesRead += n;
                numBytesToRead -= n;
            }
            pictureStream.Close();

            return bytes;
        }


        public bool checkNameIsPicture(string uploadedFileName)
        {
            string[] pictureFormats = { "jpg", "jpeg", "png", "bmp" };
            string[] splitName = uploadedFileName.Split('.');
            foreach (string format in pictureFormats)
            {
                if (splitName[splitName.Length - 1] == format)
                    return true;
            }
            return false;
        }

        public string convertIntArrayToStringWithDelimitator(int[] array)
        {
            string returnedString = "";
            for(int i = 0; i < array.Length; i++)
            {
                returnedString += array[i] + ",";
            }
            return returnedString.Substring(0, returnedString.Length - 1);
        }
    }
}