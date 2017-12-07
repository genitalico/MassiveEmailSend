using System;

namespace MassiveEmailSend
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadCsv readCsv = new ReadCsv();
            ReadJson readJson = new ReadJson();
            Template template = new Template();

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-c")
                {
                    readCsv.ParseCsv(args[i + 1]);
                }

                if (args[i] == "-j")
                {
                    readJson.ParseJson(args[i + 1]);
                }

                if (args[i] == "-t")
                {
                    template.ReadTemplate(args[i + 1]);

                }
            }

            if (readCsv.Result && readJson.Result && template.Result)
            {
                var send = new SendEmail(readCsv.ListEmail, readJson.JsonModel, template.TemplateText);

                send.SendListEmail();
            }
            else
            {
                Console.WriteLine("Ohh wrong");
            }

        }
    }
}
