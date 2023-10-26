using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.IO;

namespace _5x5shafler
{
    class GoogleSheet
    {
        static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static readonly string ApplicationName = "Current Legislators";
        static readonly string SpreadsheetId = "1lE-rWPkKL-lOpxzlzTTLr2SjisAcNq3wc5TSdi07VBU";
        static readonly string sheet = "AVG";
        static SheetsService service;
        public static void ReadGoogleSheet()
        {
            GoogleCredential credential;
            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(Scopes);
            }

            service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            ReadEntries();
        }

        static void ReadEntries()
        {
            var range = $"{sheet}!A2:C50";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(SpreadsheetId, range);

            var response = request.Execute();
            IList<IList<object>> values = response.Values;
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    double opScore;
                    var score = row[0].ToString().Replace(".", ",");
                    if (Double.TryParse(score, out opScore))
                    {
                        GlobalVariables.AllSheetPlayers.Add(row[2].ToString(), opScore);
                    }                    
                }
            }
            else
            {
                Console.WriteLine("No data found.");
            }
        }
    }
}