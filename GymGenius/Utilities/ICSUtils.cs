﻿using GymGenius.Controller;
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
        private string startTime;
        private string endTime;
        private string description;
        private string location;
        private List<AExercise> allExercises;

        public ICSUtils()
        {
        }

        public ICSUtils(string summary, DateTime startTime, DateTime endTime, string location, List<AExercise> allExercises)
        {
            this.summary = summary;
            this.startTime = startTime.ToString("yyyyMMddTHHmmssZ");
            this.endTime = endTime.ToString("yyyyMMddTHHmmssZ");
            this.allExercises = allExercises;
            this.location = location;
        }


        // Fonctions pour exporter un fichier .ics
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

        private void DownloadICSFile(string icscontent)
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


        // Fonctions pour importer un fichier .ics
        public Session? ImportICS()
        {
            // Create an instance of OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Configure the properties of the OpenFileDialog
            openFileDialog.Title = "Open the .ics file";
            openFileDialog.Filter = "iCalendar files (*.ics)|*.ics|All files (*.*)|*.*";
            openFileDialog.DefaultExt = "ics";
            openFileDialog.AddExtension = true;

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
            List<string> exerciseNames = new List<string>();
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
                    break;
                case "Abdominal":
                    return new Crunch();
                    break;
                default:
                    return null;
                    break;
            }
        }
    }
}