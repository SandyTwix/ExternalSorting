using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace External_Sorting
{
    public class Film: ICloneable, IComparable<Film>
    {
        Random rand = new Random();

        public string title;
        public int releaseYear;
        public string studio;
        public string director;
        public int duration;
        public bool isRewarded;
        public string[] protagonists;

        public Film()
        {
            title = "";
            releaseYear = 0;
            studio = "";
            director = "";
            duration = 0;
            isRewarded = false;
            protagonists = new string[3];
            for (int i = 0; i < 3; ++i)
            {
                protagonists[i] = "";
            }
        }

        public void WriteToFile(StreamWriter fileToWriteTo)
        {
            fileToWriteTo.Write(FilmToText());
        }

        public void ReadFromFile(StreamReader fileToReadFrom)
        {
            title = fileToReadFrom.ReadLine().Substring(10);
            releaseYear = Int32.Parse(fileToReadFrom.ReadLine().Substring(13));
            studio = fileToReadFrom.ReadLine().Substring(12);
            director = fileToReadFrom.ReadLine().Substring(10);
            duration = Int32.Parse(fileToReadFrom.ReadLine().Substring(21));
            isRewarded = fileToReadFrom.ReadLine().Contains("Да") ? true : false;
           
            string[] sa = fileToReadFrom.ReadLine().Substring(15).Split(new char[] {','}, 3);
                       
            for (int i = 0; i < 3; ++i)
            {
                protagonists[i] = sa[i].Trim();
            }
            fileToReadFrom.ReadLine();
        }

        public string FilmToTextAccordingToTask()
        {            
            return $"Название: {title}" + Environment.NewLine
                 + $"Год выпуска: {releaseYear}" + Environment.NewLine
                 + $"Киностудия: {studio}" + Environment.NewLine + Environment.NewLine;
        }

        public string FilmToText()
        {
            string text;
            text = $"Название: {title}" + Environment.NewLine
                 + $"Год выпуска: {releaseYear}" + Environment.NewLine
                 + $"Киностудия: {studio}" + Environment.NewLine
                 + $"Режиссёр: {director}" + Environment.NewLine
                 + $"Длительность фильма: {duration}" + Environment.NewLine
                 + "Наличие приза: " + (isRewarded ? "Да" : "Нет") + Environment.NewLine
                 + "Главные герои: ";

            for (int i = 0; i < 2; ++i)
            {
                text += protagonists[i] + ", ";
            }
            text += protagonists[2] + Environment.NewLine + Environment.NewLine;

            return text;
        }        

        public void RandomTitleAndYearGeneration()
        {            
            const string chars = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ0123456789";
            title = new string(Enumerable.Repeat(chars, 3).Select(s => s[rand.Next(s.Length)]).ToArray());
            releaseYear = rand.Next(1895, 2021);
            studio = "Какая-то студия " + rand.Next(100);
            director = "Какой-то режиссер " + rand.Next(100);
            duration = rand.Next(300);
            isRewarded = false;
            for (int i = 0; i < 3; ++i)
            {
                protagonists[i] = "Глав. герой " + rand.Next(100);
            }
        }

        public object Clone()
        {
            Film film = new Film();
            film.title = this.title;
            film.releaseYear = this.releaseYear;
            film.studio = this.studio;
            film.director = this.director;
            film.duration = this.duration;
            film.isRewarded = this.isRewarded;

            for (int i = 0; i < 3; ++i)
            {
                film.protagonists[i] = this.protagonists[i];
            }

            return film;
        }

        public int CompareTo(Film film)
        {
            return title.CompareTo(film.title);
        }
    }
}
