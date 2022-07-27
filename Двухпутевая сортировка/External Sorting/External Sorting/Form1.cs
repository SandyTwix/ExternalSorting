using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace External_Sorting
{
    public partial class Form1 : Form
    {
        // Массив со строками, отображающий заданный формат записи о фильме
        // Используется для проверки файла на соответствие формату
        static readonly string[] RECORD_FORMAT = 
            { "Название: ",
              "Год выпуска: ",
              "Киностудия: ",
              "Режиссёр: ",
              "Длительность фильма: ",
              "Наличие приза: ",
              "Главные герои: ",
              ""};

        string fileName = "";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void CreateMenuButton_Click(object sender, EventArgs e)
        {
            fileName = "";
            sourceFileTextBox.Clear();
            AddFilmButton_Click(sender, e);
        }

        // Проверка файла на соответствие формату
        private bool IsValidFile(string fileName)
        {
            StreamReader fileToCheck = new StreamReader(fileName);
            bool valid = true;

            while (!fileToCheck.EndOfStream && valid)
            {
                for (int i = 0; i < RECORD_FORMAT.Length && valid; ++i)
                {
                    valid = fileToCheck.ReadLine().StartsWith(RECORD_FORMAT[i]);
                }
            }

            fileToCheck.Close();
            return valid;
        }

        private void OpenMenuButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                if (IsValidFile(openFileDlg.FileName))
                {
                    fileName = openFileDlg.FileName;
                    sourceFileTextBox.Text = File.ReadAllText(fileName);                   
                }
                else
                {
                    MessageBox.Show("Записи в файле не соответствуют заданной форме");
                }
            }
        }

        private void AddFilmButton_Click(object sender, EventArgs e)
        {
            Film filmToAdd = new Film();
            Form2 form2 = new Form2(filmToAdd);
            form2.Owner = this;
            form2.ShowDialog();
            if (form2.DialogResult == DialogResult.OK)
            {
                sourceFileTextBox.Text += filmToAdd.FilmToText();                
            }
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            if (sourceFileTextBox.Text.Length == 0)
            {
                MessageBox.Show("Исходный файл пуст");
                return;
            }
            resultTextBox.Text = "";
            if (fileName == "")
            {
                MessageBox.Show("Перед сортировкой сохраните файл");
                SaveMenuButton_Click(sender, e);
            }
            else
            {
                File.WriteAllText(fileName, sourceFileTextBox.Text);
            }
            string s = fileName.Substring(fileName.LastIndexOf("\\") + 1).Replace(".txt", "");
            MessageBox.Show("Оригинал отсортированного файла будет доступен в файле "
                                                                                 + s + "Original.txt");
            int numOfFiles = 
                Convert.ToInt32(Interaction.InputBox("Введите желаемое кол-во " +
                                                              " вспомогательных файлов (от 2 до n):"));
            
            StreamWriter streamWriter = new StreamWriter(s + "Original.txt", false);
            streamWriter.Write(sourceFileTextBox.Text);
            streamWriter.Close();            
            ExternalSorting externalSorting = new ExternalSorting();
            externalSorting.Sort(fileName, numOfFiles);
            resultTextBox.Text = File.ReadAllText(fileName);
            stopwatch.Stop();
            textBoxTime.Text = stopwatch.Elapsed.TotalSeconds.ToString();
        }       

        private void TaskButton_Click(object sender, EventArgs e)
        {
            if (sourceFileTextBox.Text.Length == 0)
            {
                MessageBox.Show("Исходный файл пуст");
                return;
            }
            resultTextBox.Text = "";
            if (fileName == "")
            {
                MessageBox.Show("Перед сортировкой сохраните файл");
                SaveMenuButton_Click(sender, e);
            }
            else
            {
                File.WriteAllText(fileName, sourceFileTextBox.Text);
            }
            string s = fileName.Substring(fileName.LastIndexOf("\\") + 1).Replace(".txt", "");
            MessageBox.Show("Оригинал отсортированного файла будет доступен в файле "
                                                                                 + s + "Original.txt");
            int numOfFiles =
                Convert.ToInt32(Interaction.InputBox("Введите желаемое кол-во " +
                                                              " вспомогательных файлов (от 2 до n):"));

            int startYear =
                Convert.ToInt32(Interaction.InputBox("Введите стартовый год выпуска фильмов:"));
            int endYear =
                Convert.ToInt32(Interaction.InputBox("Введите последний год выпуска фильмов:"));

            StreamWriter streamWriter = new StreamWriter(s + "Original.txt", false);
            streamWriter.Write(sourceFileTextBox.Text);
            streamWriter.Close();
            ExternalSorting externalSorting = new ExternalSorting();            
            externalSorting.Sort(fileName, numOfFiles);

            StreamReader streamReader = new StreamReader(fileName);
            Film film = new Film();
            
            do
            {
                film.ReadFromFile(streamReader);
                if (film.releaseYear >= startYear && film.releaseYear <= endYear)
                {
                    resultTextBox.Text += film.FilmToTextAccordingToTask();
                }
            }
            while (!streamReader.EndOfStream);
            
            streamReader.Close();
        }

        private void SaveMenuButton_Click(object sender, EventArgs e)
        {
            if (fileName == "")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                    
                fileName = saveFileDialog.FileName;
                File.WriteAllText(fileName, sourceFileTextBox.Text);                
                MessageBox.Show("Файл сохранен");
            }
            else
            {
                File.WriteAllText(fileName, sourceFileTextBox.Text);
                MessageBox.Show("Файл сохранен");
            }
        }

        private void fillRandomlyButton_Click(object sender, EventArgs e)
        {
            int numOfFilms = Convert.ToInt32(Interaction.InputBox("Введите желаемое кол-во фильмов:"));

            sourceFileTextBox.Clear();
            Film film = new Film();
            for (int i = 0; i < numOfFilms; ++i)
            {
                film.RandomTitleAndYearGeneration();
                sourceFileTextBox.Text += film.FilmToText();
            }
        }
    }
}
