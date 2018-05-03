using FileReader;
using FileReaderCLI.Enum;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FileReaderCLI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fileTypeCBX.ItemsSource = System.Enum.GetValues(typeof(FileType)).Cast<FileType>();
            fileTypeCBX.SelectedItem = FileType.TEXT;

            roleCBX.ItemsSource = System.Enum.GetValues(typeof(Role)).Cast<Role>();
            roleCBX.SelectedItem = Role.None;
        }

        private void loadFileBTN_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();

            var fileType = (FileType)fileTypeCBX.SelectedValue;
            var encrypted = encryptedCBX.IsChecked.HasValue && encryptedCBX.IsChecked.Value;
            var role = (Role)roleCBX.SelectedValue;

            switch (fileType)
            {
                case FileType.TEXT:
                    dlg.DefaultExt = ".txt";
                    dlg.Filter = "TEXT Files (*.txt)|*.txt";
                    break;
                case FileType.XML:
                    dlg.DefaultExt = ".xml";
                    dlg.Filter = "XML Files (*.xml)|*.xml";
                    break;
                case FileType.JSON:
                    dlg.DefaultExt = ".json";
                    dlg.Filter = "JSON Files (*.json)|*.json";
                    break;
            }

            var result = dlg.ShowDialog();

            if (result == true)
            { 
                string filePath = dlg.FileName;
                ReadFile(filePath, fileType, encrypted, role);
            }
        }

        private void ReadFile(string path, FileType fileType, bool isEncrypted, Role role)
        {
            var fileReader = new FileReader.FileReader();
            var paragraph = new Paragraph();

            switch (fileType)
            {
                case FileType.TEXT:
                    paragraph.Inlines.Add(fileReader.ReadTextFile(path, isEncrypted, role));
                    break;
                case FileType.XML:
                    paragraph.Inlines.Add(fileReader.ReadXmlFile(path, role, isEncrypted));
                    break;
                case FileType.JSON:
                    paragraph.Inlines.Add(fileReader.ReadJsonFile(path, role, isEncrypted));
                    break;
            }

            FlowDocument document = new FlowDocument(paragraph);
            FlowDocReader.Document = document;
        }
    }
}
