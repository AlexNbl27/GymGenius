using System.IO;
using System.Text;
using GymGenius.Models;
using Microsoft.Win32;

namespace GymGenius.Utilities
{
    public class ICS
    {
        private string summary;
        private string startTime;
        private string endTime;
        private string description;
        private string location;
        private List<AExercise> allExercises;

        /*public ICS (string summary, DateTime startTime, DateTime endTime, string description, string location)
        {
            this.summary = summary;
            this.startTime = startTime.ToString("yyyyMMddTHHmmssZ");
            this.endTime = endTime.ToString("yyyyMMddTHHmmssZ");
            this.description = description;
            this.location = location;
        }*/

        public ICS (string summary, DateTime startTime, DateTime endTime, string location, List<AExercise> allExercises)
        {
            this.summary = summary;
            this.startTime = startTime.ToString("yyyyMMddTHHmmssZ");
            this.endTime = endTime.ToString("yyyyMMddTHHmmssZ");
            this.allExercises = allExercises;
            this.location = location;
        }

        public void testICS()
        {
            string icscontent = CreateICSFile();
            DownloadICSFile(icscontent);
        }

        public void ExportICS()
        {
            this.description = "Séance de sport:\\n\n";
            int index = 0;

            foreach (AExercise exercise in allExercises)
            {
                index++;
                this.description += " " + index + ") " + exercise.Name + "\\" + "n";
        
                // Check if it's not the last exercise
                if (index < allExercises.Count)
                {
                    this.description += "\n";
                }
            }

            string icscontent = CreateICSFile();
            DownloadICSFile(icscontent);
        }

        private string CreateICSFile()
        {
            StringBuilder icsContent = new StringBuilder();

            icsContent.AppendLine("BEGIN:VCALENDAR");
            icsContent.AppendLine("VERSION:2.0");
            icsContent.AppendLine("BEGIN:VEVENT");

            // Event details
            icsContent.AppendLine($"SUMMARY:{this.summary}");
            icsContent.AppendLine($"DTSTART:{this.startTime}");
            icsContent.AppendLine($"DTEND:{this.endTime}");
            icsContent.AppendLine($"DESCRIPTION:{this.description}");
            icsContent.AppendLine($"LOCATION:{this.location}");

            // Other optional properties (you can add more as needed)
            icsContent.AppendLine("BEGIN:VALARM");
            icsContent.AppendLine("TRIGGER:-PT15M");
            icsContent.AppendLine("DESCRIPTION:Reminder");
            icsContent.AppendLine("ACTION:DISPLAY");
            icsContent.AppendLine("END:VALARM");

            icsContent.AppendLine("END:VEVENT");
            icsContent.AppendLine("END:VCALENDAR");

            return icsContent.ToString();
        }

        public void DownloadICSFile(string icscontent)
        {
            // Create an instance of SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Configure the properties of the SaveFileDialog
            saveFileDialog.Title = "Save the .ics file";
            saveFileDialog.Filter = "iCalendar files (*.ics)|*.ics|All files (*.*)|*.*";
            saveFileDialog.DefaultExt = "ics";
            saveFileDialog.AddExtension = true;

            // Show the dialog and check if the user clicked "Save"
            bool? result = saveFileDialog.ShowDialog();

            if (result.HasValue && result.Value)
            {
                // Get the full path of the selected file
                string selectedFilePath = saveFileDialog.FileName;

                // Write the content to the file
                File.WriteAllText(selectedFilePath, icscontent);

                Console.WriteLine($"File saved as .ics: {selectedFilePath}");
            }
        }
    }
}
