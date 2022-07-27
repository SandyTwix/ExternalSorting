using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace External_Sorting
{
    class ExternalSorting
    {
        // Многопутевая двухфазная естественная несбалансированная сортировка
        public void Sort(string fileName, int numOfFiles)
        {
            StreamReader[] additionalFilesReaders = new StreamReader[numOfFiles];
            StreamWriter[] additionalFilesWriters = new StreamWriter[numOfFiles];

            int numOfRuns, currentFile, currentRun, nextRun;
            Film currentFilm, predFilm;

            List<FileIndexAndFilm>[] lists = new List<FileIndexAndFilm>[2];
            lists[0] = new List<FileIndexAndFilm>();
            lists[1] = new List<FileIndexAndFilm>();

            FileIndexAndFilm fileAndFilm, minfileAndFilm;

            do
            {
                // Фаза распределения

                // Открываем исходный файл на чтение...
                StreamReader fileToSortReader = new StreamReader(fileName);
                // ... и вспомогательные файлы на запись
                for (int j = 0; j < numOfFiles; ++j)
                {
                    additionalFilesWriters[j] =
                        new StreamWriter("_sortingHelpingFile" + j.ToString() + ".txt", false);
                }
                // Кол-во серий, полученных на очередном проходе
                numOfRuns = 1;
                // Индекс текущего вспомогательного файла
                currentFile = 0;

                // Текущий считанный фильм
                currentFilm = new Film();
                
                // Считываем первый фильм
                currentFilm.ReadFromFile(fileToSortReader);
                // Пока не закончится файл
                while (!fileToSortReader.EndOfStream)
                {
                    // Пока не кончится серия или не закончится файл
                    do
                    {
                        // Записываем фильм в текущий вспомогательный файл
                        currentFilm.WriteToFile(additionalFilesWriters[currentFile]);
                        // Запоминаем записанный фильм чтобы проверить, не кончилась серия
                        predFilm = (Film)currentFilm.Clone();
                        // Считываем следующий фильм
                        currentFilm.ReadFromFile(fileToSortReader);
                    }
                    // Проверяем, не кончилась ли серия и не кончился ли файл
                    while (predFilm.CompareTo(currentFilm) < 1 && !fileToSortReader.EndOfStream);

                    // Если кончился файл...
                    if (fileToSortReader.EndOfStream)
                    {
                        // И при этом серия не прервалась...
                        if (predFilm.CompareTo(currentFilm) < 1)
                        {
                            // ... то записываем последний фильм в тот же вспомогательный файл
                            currentFilm.WriteToFile(additionalFilesWriters[currentFile]);                            
                        }                        
                        else
                        {
                            // Иначе, записываем фильм в следующий вспомогательный файл...
                            currentFilm.WriteToFile(additionalFilesWriters[(currentFile + 1) % numOfFiles]);                            
                            // ... и увеличиваем счетчик кол-ва серий
                            ++numOfRuns;
                        }
                    }
                    // Если файл не кончился...
                    else
                    {
                        // ... то высчитываем индекс следующего вспомогательного файла...
                        currentFile = (currentFile + 1) % numOfFiles;
                        // ... и увеличиваем счетчик кол-ва серий
                        ++numOfRuns;
                    }
                }

                // Закрываем все открытые файлы
                fileToSortReader.Close();
                for (int j = 0; j < numOfFiles; ++j)
                {
                    additionalFilesWriters[j].Close();
                }

                // Условие выхода из сортировки - получена всего одна серия 
                // (то есть в исходном файле не было ни одного неупорядоченного по неубыванию элемента)
                if (numOfRuns == 1)
                {
                    // Удаляем вспомогательный файлы
                    for (int j = 0; j < numOfFiles; ++j)
                    {
                        File.Delete("_sortingHelpingFile" + j.ToString() + ".txt");
                    }
                    // Выходим из сортировки
                    return;
                }
                
                // Если получено больше 1 серии, переходим к фазе слияния

                // Фаза слияния
                
                // Открываем исходный файл на запись...
                StreamWriter fileToSortWriter = new StreamWriter(fileName, false);
                // ... и вспомогательные файлы на чтение
                for (int j = 0; j < numOfFiles; ++j)
                {
                    additionalFilesReaders[j] =
                        new StreamReader("_sortingHelpingFile" + j.ToString() + ".txt");
                }

                // Структура, в которой находится минимальный фильм (по алфавиту относительно названия) 
                // и индекс вспомогательного файла, из которого этот фильм считан
                minfileAndFilm = new FileIndexAndFilm();
                minfileAndFilm.film = new Film();
                
                // Считываем из каждого не пустого вспомогательного файла по фильму
                for (int k = 0; k < numOfFiles; ++k)
                {
                    if (!additionalFilesReaders[k].EndOfStream)
                    {
                        fileAndFilm = new FileIndexAndFilm();
                        fileAndFilm.film = new Film();
                        fileAndFilm.fileIndex = k;                             
                        fileAndFilm.film.ReadFromFile(additionalFilesReaders[k]);
                        // И добавляем его в список с фильмами из текущей серии
                        lists[0].Add(fileAndFilm);
                    }
                }

                // Индекс списка, в котором находится текущая сливаемая серия
                currentRun = 0;
                // Индекс списка, в который мы будем добавлять фильмы, 
                // если считанный фильм будет выходить за пределы текущей сливаемой серии
                nextRun = 1;

                // Пока есть хотя бы один не пустой файл 
                while (!checkIfAllStreamsEnded(additionalFilesReaders))
                {
                    // Пока в серии, которую мы сливаем, есть фильмы
                    while (lists[currentRun].Count != 0)
                    {
                        // Находим минимальный из фильмов
                        minfileAndFilm = lists[currentRun].Min();
                        // Записываем его в исходный файл
                        minfileAndFilm.film.WriteToFile(fileToSortWriter);                        
                        // Удаляем его из сливаемой серии
                        lists[currentRun].Remove(minfileAndFilm);

                        // Если из файла, из которого мы считали минимальный фильм, ещё есть фильмы,...                        
                        if (!additionalFilesReaders[minfileAndFilm.fileIndex].EndOfStream)
                        {
                            fileAndFilm = new FileIndexAndFilm();
                            fileAndFilm.film = new Film();

                            // ... то считываем из него же следующий фильм
                            fileAndFilm.fileIndex = minfileAndFilm.fileIndex;
                            fileAndFilm.film.ReadFromFile(additionalFilesReaders[minfileAndFilm.fileIndex]);

                            // Если считанный фильм выходит за пределы текущей сливаемой серии, ...
                            if (fileAndFilm.film.CompareTo(minfileAndFilm.film) < 0)
                            {
                                // ... то добавляем его в список со следующей серией
                                lists[nextRun].Add(fileAndFilm);
                            }
                            else
                            {
                                // Иначе добавляем его в список с текущей сливаемой серией
                                lists[currentRun].Add(fileAndFilm);
                            }
                        }
                    }

                    // Когда в текущей сливаемой серии не останется ни одного фильма, 
                    // фильмы из следующей серии будут находится в соответсвующем списке
                    currentRun = nextRun;
                    nextRun = (nextRun + 1) % 2;
                }

                // Когда мы считаем все файлы до конца, может оказаться, 
                // что в списке будут оставшиеся не распределенные фильмы 
                // Для них всех...
                while (lists[currentRun].Count != 0)
                {
                    // ... находим минимум ...
                    minfileAndFilm = lists[currentRun].Min();
                    // ... записываем его в исходный файл ... 
                    minfileAndFilm.film.WriteToFile(fileToSortWriter);
                    // ... удаляем его из списка и повторяем процедуру, 
                    // пока не будут распределены все фильмы
                    lists[currentRun].Remove(minfileAndFilm);
                }

                // Закрываем все открытые файлы
                fileToSortWriter.Close();
                for (int j = 0; j < numOfFiles; ++j)
                {
                    additionalFilesReaders[j].Close();
                }
            }
            while (true);
        }

       

        public bool checkIfAllStreamsEnded(StreamReader[] streamReaders)
        {
            for (int i = 0; i < streamReaders.Length; ++i)
            {
                if (!streamReaders[i].EndOfStream)
                {
                    return false;
                }
            }
            return true;
        }

        public struct FileIndexAndFilm : IComparable<FileIndexAndFilm>
        {
            public int fileIndex;
            public Film film;

            public int CompareTo(FileIndexAndFilm f)
            {
                return film.CompareTo(f.film);
            }
        }

        public struct FileIndexAndNumber: IComparable<FileIndexAndNumber>
        {
            public int fileIndex;
            public int number;

            public int CompareTo(FileIndexAndNumber f)
            {
                return number.CompareTo(f.number);
            }
        }

        public FileIndexAndNumber GetMin(List<FileIndexAndNumber> list)
        {
            return list.Min();            
        }

        // Многопутевое двухфазное естественное несбалансированное
        public void SortNumbers(string fileName, int numOfFiles)
        {
            StreamReader[] additionalFilesReaders = new StreamReader[numOfFiles];
            StreamWriter[] additionalFilesWriters = new StreamWriter[numOfFiles];
            int numOfRuns;

            do
            {
                // Фаза распределения
                StreamReader fileToSortReader = new StreamReader(fileName);
                for (int j = 0; j < numOfFiles; ++j)
                {
                    additionalFilesWriters[j] = 
                        new StreamWriter("_sortingHelpingFile" + j.ToString() + ".txt", false);
                }
                numOfRuns = 1;
                int currentFile = 0;
                
                int currentNumber = Convert.ToInt32(fileToSortReader.ReadLine());
                int predNumber;
                while (!fileToSortReader.EndOfStream)
                {                                        
                    do
                    {
                        additionalFilesWriters[currentFile].Write(currentNumber + Environment.NewLine);
                        predNumber = currentNumber;
                        currentNumber = Convert.ToInt32(fileToSortReader.ReadLine());
                    }
                    while (predNumber <= currentNumber && !fileToSortReader.EndOfStream);

                    if (fileToSortReader.EndOfStream)
                    {
                        if (predNumber <= currentNumber)
                        {
                            additionalFilesWriters[currentFile].Write(currentNumber + Environment.NewLine);
                        }                            
                        else
                        {
                            additionalFilesWriters[(currentFile + 1) % numOfFiles].Write(currentNumber + Environment.NewLine);
                            ++numOfRuns;
                        }
                    }                                                 
                    else
                    {
                        currentFile = (currentFile + 1) % numOfFiles;
                        ++numOfRuns;
                    }
                }

                fileToSortReader.Close();
                for (int j = 0; j < numOfFiles; ++j)
                {
                    additionalFilesWriters[j].Close();
                }

                if (numOfRuns == 1)
                {
                    for (int j = 0; j < numOfFiles; ++j)
                    {
                        File.Delete("_sortingHelpingFile" + j.ToString() + ".txt");
                    }
                    return;
                }

                // Фаза слияния
                StreamWriter fileToSortWriter = new StreamWriter(fileName, false);
                for (int j = 0; j < numOfFiles; ++j)
                {
                    additionalFilesReaders[j] = 
                        new StreamReader("_sortingHelpingFile" + j.ToString() + ".txt");
                }

                List<FileIndexAndNumber>[] lists = new List<FileIndexAndNumber>[2];
                lists[0] = new List<FileIndexAndNumber>();
                lists[1] = new List<FileIndexAndNumber>();

                FileIndexAndNumber fileAndNumber = new FileIndexAndNumber();
                FileIndexAndNumber minfileAndNumber;

                for (int k = 0; k < numOfFiles; ++k)
                {
                    if (!additionalFilesReaders[k].EndOfStream)
                    {
                        fileAndNumber.fileIndex = k;
                        fileAndNumber.number = Convert.ToInt32(additionalFilesReaders[k].ReadLine());
                        lists[0].Add(fileAndNumber);
                    }                    
                }

                int currentRun = 0;
                int nextRun = 1;
                while (!checkIfAllStreamsEnded(additionalFilesReaders))
                {                    
                    while (lists[currentRun].Count != 0)
                    {
                        minfileAndNumber = lists[currentRun].Min();//GetMin(lists[currentRun]);
                        fileToSortWriter.WriteLine(minfileAndNumber.number);
                        lists[currentRun].Remove(minfileAndNumber);

                        if (!additionalFilesReaders[minfileAndNumber.fileIndex].EndOfStream)
                        {
                            fileAndNumber.fileIndex = minfileAndNumber.fileIndex;
                            fileAndNumber.number = Convert.ToInt32(additionalFilesReaders[minfileAndNumber.fileIndex].ReadLine());
                            if (fileAndNumber.number < minfileAndNumber.number)
                            {
                                lists[nextRun].Add(fileAndNumber);
                            }
                            else
                            {
                                lists[currentRun].Add(fileAndNumber);
                            }

                        }
                    }

                    currentRun = (currentRun + 1) % 2;
                    nextRun = (nextRun + 1) % 2;
                }

                while (lists[currentRun].Count != 0)
                {
                    minfileAndNumber = lists[currentRun].Min();
                    fileToSortWriter.WriteLine(minfileAndNumber.number);
                    lists[currentRun].Remove(minfileAndNumber);
                }

                fileToSortWriter.Close();
                for (int j = 0; j < numOfFiles; ++j)
                {
                    additionalFilesReaders[j].Close();
                }
            }
            while (true);
        }
    }
}