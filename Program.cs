using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace EmailConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"Config.json";

            string folderName = @"Temp";

            if (!System.IO.Directory.Exists(folderName))
            {
                System.IO.Directory.CreateDirectory(folderName);
            }

            JArray tempalteConfig  = JArray.Parse(File.ReadAllText(filePath));

            foreach(var config in tempalteConfig)
            {
                string clientId = config["client"].ToString();

                foreach (var status in config["statuses"])
                {
                    foreach(var program in config["programs"])
                    {
                        foreach(var language in config["languages"])
                        {
                            folderName = $"{folderName}/{clientId}";

                            if (!System.IO.Directory.Exists(folderName))
                            {
                                System.IO.Directory.CreateDirectory(folderName);
                            }                            
                            
                            string fileName = $"{clientId}_{program.ToString().Replace(" ","_")}_{status.ToString()}_{language.ToString()}.html";
                            string pathString = System.IO.Path.Combine(folderName, fileName);
                            System.IO.File.Create(pathString);
                        }

                         folderName = @"Temp";
                    }
                   
                }
            }

        }
    }
}