using GymGenius.Controller;
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
        private string date;
        private string endDate;
        private string description;
        private string? reccurence;
        private List<AExercise> allExercises;

        public ICSUtils() { }

        public ICSUtils(Session session)
        {
            this.summary = "Ma séance de sport GymGenius";
            if (session.date != null)
            {
                DateTime _date = (DateTime)session.date;
                DateTime _endDate = (DateTime)session.date;
                _endDate = _endDate.AddDays(1);
                this.date = _date.ToString("yyyyMMdd");
                this.endDate = _endDate.ToString("yyyyMMdd");
            }
            else
            {
                DateTime now = DateTime.Now;
                this.date = now.ToString("yyyyMMdd");
                this.endDate = now.ToString("yyyyMMdd");
            }
            if (session.recurrenceId > 0)
            {
                this.reccurence = session.GetRecurrenceString();
            }
            this.allExercises = session.exercises;
        }


        // Public function to export session to ICS File

        public void ExportICS()
        {
            this.description = "Séance de sport\\n\n";
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

            icsContent.AppendLine($"SUMMARY:{this.summary}");
            icsContent.AppendLine($"DTSTART;VALUE=DATE:{this.date}");
            icsContent.AppendLine($"DTEND;VALUE=DATE:{this.endDate}");
            icsContent.AppendLine($"DESCRIPTION:{this.description}");
            if (this.reccurence != null)
            {
                icsContent.AppendLine($"RRULE:{this.reccurence};INTERVAL=1;COUNT=25");
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
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save the .ics file";
            saveFileDialog.Filter = "iCalendar files (*.ics)|*.ics|All files (*.*)|*.*";
            saveFileDialog.DefaultExt = "ics";
            saveFileDialog.AddExtension = true;
            bool? result = saveFileDialog.ShowDialog();

            if (result.HasValue && result.Value)
            {
                string selectedFilePath = saveFileDialog.FileName;

                File.WriteAllText(selectedFilePath, icscontent);
            }
        }


        // Public function to import session from ICS File

        public Session? ImportICS()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open the .ics file";
            openFileDialog.Filter = "iCalendar files (*.ics)|*.ics|All files (*.*)|*.*";
            openFileDialog.DefaultExt = "ics";
            openFileDialog.AddExtension = true;
            bool? result = openFileDialog.ShowDialog();

            if (result.HasValue && result.Value)
            {
                string selectedFilePath = openFileDialog.FileName;

                string icsContent = File.ReadAllText(selectedFilePath);

                string allExercises = ParseICSFile(icsContent);
                Session session = CreateSession(allExercises);
                return session;
            }
            return null;
        }

        private string ParseICSFile(string icsContent)
        {
            string[] lines = icsContent.Split('\n');

            bool insideDESCRIPTION = false;
            string allExercises = "";
            foreach (string line in lines)
            {
                string[] pair = line.Split(':');

                if (pair.Length >= 2)
                {
                    string key = pair[0];
                    string value = pair[1];

                    if (key == "DESCRIPTION")
                    {
                        insideDESCRIPTION = true;
                    }
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
            string[] exercisesArray = _allExercises.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            List<string> exerciseNames = new List<string>();
            foreach (string exercise in exercisesArray)
            {
                string cleanedExercise = exercise.Trim();
                cleanedExercise = Regex.Replace(cleanedExercise, @"^\s*\d+\)\s*", "");
                cleanedExercise = cleanedExercise.Replace("\\n", "");

                if (!string.IsNullOrEmpty(cleanedExercise))
                {
                    exerciseNames.Add(cleanedExercise);
                }
            }

            List<AExercise> allExercises = new List<AExercise>();
            foreach (string exerciseName in exerciseNames)
            {
                string exerciseClass = TranslateUtils.GetRessourceName(exerciseName);
                allExercises.Add(CreateExercise(exerciseClass));
            }

            Session session = new Session(allExercises);

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
