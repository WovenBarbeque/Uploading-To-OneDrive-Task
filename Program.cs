using System;
using Independentsoft.Share;
using System.IO;
using System.Net;

namespace UploadingToOneDrive
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Service service = new Service("https://schoolsnsw-my.sharepoint.com/personal/thomas_bandy_education_nsw_gov_au/", "thomas.bandy@education.nsw.gov.au", "=15oelio+hdYuqc!");

                //Increase timeout to 600000 milliseconds (10 minutes). Useful when uploading large files.
                //Default value is 100000 (100 seconds).
                service.Timeout = 600000;

                FileStream fileStream = new FileStream(@"C:\Users\Thomas Bandy\Desktop\Trig.txt", FileMode.Open);

                using (fileStream)
                {
                    service.CreateFile("/personal/thomas_bandy_education_nsw_gov_au/Documents/Test.docx", fileStream);
                }
            }
            catch (ServiceException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Error: " + ex.ErrorCode);
                Console.WriteLine("Error: " + ex.ErrorString);
                Console.WriteLine("Error: " + ex.RequestUrl);
                Console.Read();
            }
            catch (WebException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.Read();
            }
        }
    }
}
