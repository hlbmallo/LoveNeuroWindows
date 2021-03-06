using NerveCentreW10.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;

namespace NerveCentreW10.Helpers
{
    public class FileIOHelper
    {
        //Read the content from Json file 
        public List<QuizClass> ReadFromDefaultFile(string fileName)
        {
            List<QuizClass> lstContent = new List<QuizClass>();
            try
            {
                /*   
                    Need to make sure using ConfigureAwait, GetAwaiter to avoid any file access errors 
                    Once the file is opened can use ReadTextAsync again with GetAwaiver as snow below  
                    Conver the text to JsonArray and then deserialize into the object of our own format using DataContractJsonSerializer as below 
                    For more details refer https://www.suchan.cz/2014/07/file-io-best-practices-in-windows-and-phone-apps-part-1-available-apis-and-file-exists-checking/ 
                */
                Uri appUri = new Uri(fileName);//File name should be prefixed with 'ms-appx:///Assets/* 
                StorageFile anjFile = StorageFile.GetFileFromApplicationUriAsync(appUri).AsTask().ConfigureAwait(false).GetAwaiter().GetResult();
                string jsonText = FileIO.ReadTextAsync(anjFile).AsTask().ConfigureAwait(false).GetAwaiter().GetResult();
                var jsonSerializer = new DataContractJsonSerializer(typeof(QuizClass));
                JsonArray anjarray = JsonArray.Parse(jsonText);
                foreach (JsonValue oJsonVal in anjarray)
                {
                    JsonObject oJsonObj = oJsonVal.GetObject();
                    using (MemoryStream jsonStream = new MemoryStream(Encoding.Unicode.GetBytes(oJsonObj.ToString())))
                    {
                        QuizClass oContent = (QuizClass)jsonSerializer.ReadObject(jsonStream);
                        lstContent.Add(oContent);
                    }
                }
            }
            catch (Exception exp)
            {
                
            }
            return lstContent;
        }
    }
}
