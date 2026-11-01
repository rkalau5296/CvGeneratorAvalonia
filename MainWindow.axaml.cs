using System;
using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using CvGeneratorAvalonia.Models;
using CvGeneratorAvalonia.Templates;
using Newtonsoft.Json;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace CvGeneratorAvalonia
{
    public partial class MainWindow : Window
    {
        private string? _selectedFilePath;

        public MainWindow()
        {
            InitializeComponent();
            QuestPDF.Settings.License = LicenseType.Community;
            QuestPDF.Settings.UseSystemFonts = true;
        }

        private async void BtnBrowse_Click(object? sender, RoutedEventArgs e)
        {
            var topLevel = TopLevel.GetTopLevel(this);
            if (topLevel == null) return;

            var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Wybierz plik z danymi CV",
                AllowMultiple = false,
                FileTypeFilter = new[]
                {
                    new FilePickerFileType("Pliki JSON") { Patterns = new[] { "*.json" } }
                }
            });

            if (files.Count > 0)
            {
                _selectedFilePath = files[0].Path.LocalPath;
                TxtFilePath.Text = _selectedFilePath;
                TxtStatus.Text = string.Empty;
            }
        }

        private void BtnGenerate_Click(object? sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedFilePath) || !File.Exists(_selectedFilePath))
            {
                TxtStatus.Foreground = Avalonia.Media.Brushes.Red;
                TxtStatus.Text = "Najpierw wybierz poprawny plik JSON!";
                return;
            }

            try
            {
                string jsonContent = File.ReadAllText(_selectedFilePath);
                var cvData = JsonConvert.DeserializeObject<CvData>(jsonContent);

                if (cvData == null)
                {
                    TxtStatus.Foreground = Avalonia.Media.Brushes.Red;
                    TxtStatus.Text = "Błąd odczytu danych z pliku JSON.";
                    return;
                }

                ICvTemplate selectedTemplate = CbTemplates?.SelectedItem switch
                {
                    ComboBoxItem { Tag: "ModernCream" } => new ModernCreamTemplate(),
                    ComboBoxItem { Tag: "Executive" } => new ExecutiveTemplate(),
                    _ => new ModernCreamTemplate()
                };

                var directory = Path.GetDirectoryName(_selectedFilePath);
                var outputPath = string.IsNullOrEmpty(directory)
                    ? "moje_cv.pdf"
                    : Path.Combine(directory, "moje_cv.pdf");

                var document = new CvDocument(cvData, selectedTemplate);
                document.GeneratePdf(outputPath);

                TxtStatus.Foreground = Avalonia.Media.Brushes.Green;
                TxtStatus.Text = $"Wygenerowano pomyślnie: {outputPath}";
            }
            catch (Exception ex)
            {
                TxtStatus.Foreground = Avalonia.Media.Brushes.Red;
                TxtStatus.Text = $"Błąd: {ex.Message}";
            }
        }
    }
}