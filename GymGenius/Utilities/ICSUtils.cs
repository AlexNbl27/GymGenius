using GymGenius.Controller;
using GymGenius.Controllers;
using GymGenius.Models;
using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace GymGenius.Utilities
{
    public class ICSUtils
    {
        private string summary;
        private readonly string date;
        private readonly string endDate;
        private string description;
        private readonly string? reccurence;
        private readonly List<AExercise> allExercises;

        public ICSUtils() { }

        public ICSUtils(Session session)
        {
            summary = "Ma séance de sport GymGenius";
            if (session.date != null)
            {
                DateTime _date = (DateTime)session.date;
                DateTime _endDate = (DateTime)session.date;
                _endDate = _endDate.AddDays(1);
                date = _date.ToString("yyyyMMdd");
                endDate = _endDate.ToString("yyyyMMdd");
            }
            else
            {
                DateTime now = DateTime.Now;
                date = now.ToString("yyyyMMdd");
                endDate = now.ToString("yyyyMMdd");
            }
            if (session.recurrenceId > 0)
            {
                reccurence = session.GetRecurrenceString();
            }
            allExercises = session.exercises;
        }


        // Fonctions pour exporter un fichier .ics
        public void ExportICS()
        {
            description = "Séance de sport\\n\n";
            int index = 0;

            foreach (AExercise exercise in allExercises)
            {
                index++;
                description += " " + index + ") " + exercise.Name + "\\" + "n";

                // Check if it's not the last exercise
                if (index < allExercises.Count)
                {
                    description += "\n";
                }
            }

            string icscontent = CreateICSFile();
            DownloadICSFile(icscontent);
        }

        private string CreateICSFile()
        {
            StringBuilder icsContent = new();

            icsContent.AppendLine("BEGIN:VCALENDAR");
            icsContent.AppendLine("VERSION:2.0");
            icsContent.AppendLine("BEGIN:VEVENT");

            icsContent.AppendLine($"SUMMARY:{summary}");
            icsContent.AppendLine($"DTSTART;VALUE=DATE:{date}");
            icsContent.AppendLine($"DTEND;VALUE=DATE:{endDate}");
            icsContent.AppendLine($"DESCRIPTION:{description}");
            if (reccurence != null)
            {
                icsContent.AppendLine($"RRULE:{reccurence};INTERVAL=1;COUNT=25");
            }
            icsContent.AppendLine("BEGIN:VALARM");
            icsContent.AppendLine("TRIGGER:-PT15M");
            icsContent.AppendLine("DESCRIPTION:Reminder");
            icsContent.AppendLine("ACTION:DISPLAY");
            icsContent.AppendLine("END:VALARM");

            icsContent.AppendLine("END:VEVENT");
            icsContent.AppendLine("END:VCALENDAR");

            return icsContent.ToString();
        }


        private void DownloadICSFile(string icscontent)
        {
            // Create an instance of SaveFileDialog
            SaveFileDialog saveFileDialog = new()
            {
                // Configure the properties of the SaveFileDialog
                Title = "Save the .ics file",
                Filter = "iCalendar files (*.ics)|*.ics|All files (*.*)|*.*",
                DefaultExt = "ics",
                AddExtension = true
            };

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


        // Fonctions pour importer un fichier .ics
        public Session? ImportICS()
        {
            // Create an instance of OpenFileDialog
            OpenFileDialog openFileDialog = new()
            {
                // Configure the properties of the OpenFileDialog
                Title = "Open the .ics file",
                Filter = "iCalendar files (*.ics)|*.ics|All files (*.*)|*.*",
                DefaultExt = "ics",
                AddExtension = true
            };

            // Show the dialog and check if the user clicked "Open"
            bool? result = openFileDialog.ShowDialog();

            if (result.HasValue && result.Value)
            {
                // Get the full path of the selected file
                string selectedFilePath = openFileDialog.FileName;

                // Read the content of the file
                string icsContent = File.ReadAllText(selectedFilePath);

                string allExercises = ParseICSFile(icsContent);
                Session session = CreateSession(allExercises);
                return session;
            }
            return null;
        }

        private string ParseICSFile(string icsContent)
        {
            // Split the content into lines
            string[] lines = icsContent.Split('\n');

            bool insideDESCRIPTION = false;
            string allExercises = "";
            // Loop through the lines
            foreach (string line in lines)
            {
                // Split the line into key/value pair
                string[] pair = line.Split(':');

                // Check if the line is valid
                if (pair.Length >= 2)
                {
                    // Get the key and value
                    string key = pair[0];
                    string value = pair[1];

                    // Check if the key is "DESCRIPTION"
                    if (key == "DESCRIPTION")
                    {
                        insideDESCRIPTION = true;
                    }
                    // Check if the key is "SUMMARY"
                    else if (key == "SUMMARY")
                    {
                        summary = value;
                    }
                }
                else if (insideDESCRIPTION)
                {
                    string value = pair[0];
                    allExercises += value + "\n";
                }
            }
            return allExercises;
        }

        private Session CreateSession(string _allExercises)
        {
            // Split the input string by newline character ("\n")
            string[] exercisesArray = _allExercises.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            // Extract only the exercise names
            List<string> exerciseNames = [];
            foreach (string exercise in exercisesArray)
            {
                // Remove leading and trailing whitespaces
                string cleanedExercise = exercise.Trim();

                // Remove leading numbers and whitespace
                cleanedExercise = Regex.Replace(cleanedExercise, @"^\s*\d+\)\s*", "");

                // Remove "\\n" from the exercise names
                cleanedExercise = cleanedExercise.Replace("\\n", "");

                // Add the cleaned exercise name to the list (if not empty)
                if (!string.IsNullOrEmpty(cleanedExercise))
                {
                    exerciseNames.Add(cleanedExercise);
                }
            }

            List<AExercise> allExercises = [];
            foreach (string exerciseName in exerciseNames)
            {
                string exerciseClass = TranslateUtils.GetRessourceName(exerciseName);
                allExercises.Add(CreateExercise(exerciseClass));
            }

            Session session = new(allExercises);

            return session;
        }

        private AExercise? CreateExercise(string exerciseName)
        {
            switch (exerciseName)
            {
                case "PushUps":
                    return new PushUps();
                case "Crunch":
                    return new Crunch();
                case "Dips":
                    return new Dips();
                case "BenchPress":
                    return new BenchPress();
                case "InclinedBenchPress":
                    return new InclinedBenchPress();
                case "ForeheadBar":
                    return new ForeheadBar();
                case "PulleyTricepsExtensions":
                    return new PulleyTricepsExtensions();
                case "CableMiddleFly":
                    return new CableMiddleFly();
                case "SideElevation":
                    return new SideElevation();
                case "FrontalElevation":
                    return new FrontalElevation();
                case "BirdElevation":
                    return new BirdElevation();
                case "MilitaryPress":
                    return new MilitaryPress();
                case "InvertedPecDeck":
                    return new InvertedPecDeck();
                case "FacePull":
                    return new FacePull();
                case "HorizontalDraft":
                    return new HorizontalDraft();
                case "Deadlift":
                    return new Deadlift();
                case "BicepsCurl":
                    return new BicepsCurl();
                case "CurlRotation":
                    return new CurlRotation();
                case "PulleyCurl":
                    return new PulleyCurl();
                case "Squat":
                    return new Squat();
                case "LegPress":
                    return new LegPress();
                case "Slots":
                    return new Slots();
                case "LegExtension":
                    return new LegsExtensions();
                case "LegFlexion":
                    return new LegsFlexions();
                case "CalfPress":
                    return new CalfPress();
                case "PullUps":
                    return new PullUps();
                case "Treadmill":
                    return new Treadmill();
                case "Rowing":
                    return new Rowing();
                case "Stairs":
                    return new Stairs();
                case "Elliptical":
                    return new Elliptical();
                default:
                    return null;
            }
        }
    }
}
