using ClassLibraryLab10;
using System.Xml.Linq;
namespace laba____11
{
    internal class Program
    {
        /// <summary>
        /// Среднее количество струн в гитарах
        /// </summary>
        /// <returns></returns>
        static double GetAvarageStringsNumber(Queue<MusicalInstrument> q)
        {
            double sum = 0;
            double count = 0;
            foreach (MusicalInstrument item in q)
            {
                if (item is Guitar g)
                {
                    sum += g.StringsNumber;
                    count++;
                }
            }
            return sum / count;
        }

        /// <summary>
        /// Сумма струн в электрогитарах с фиксированным источником питания
        /// </summary>
        /// <returns></returns>
        static int GetStringsNumberSum(Queue<MusicalInstrument> q)
        {
            int sum = 0;
            foreach (MusicalInstrument item in q)
            {
                ElectricGuitar e = item as ElectricGuitar;
                if ((e != null) && (e.PowerSupply == "Фиксированный источник питания"))
                {
                    sum += e.StringsNumber;
                }
            }
            return sum;
        }

        /// <summary>
        /// Максимальное количество клавиш в фортепиаоно с октавной раскладкой
        /// </summary>
        /// <returns></returns>
        static int GetMaxKeysNumber(Queue<MusicalInstrument> q)
        {
            int max = 0;
            foreach (MusicalInstrument item in q)
            {
                if (typeof(Piano) == item.GetType())
                {
                    Piano p = item as Piano;
                    if (p.KeyLayout == "Октавная")
                    {
                        if (p.KeysNumber > max)
                            max = p.KeysNumber;
                    }
                }
            }
            return max;
        }

        /// <summary>
        /// Сумма струн в гмтарах
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        static double GetSumStringsNumber<T>(SortedSet<T> s)
        {
            double sum = 0;
            foreach (T item in s)
            {
                if (item is Guitar g)
                {
                    sum += g.StringsNumber;
                }
            }
            return sum ;
        }

        /// <summary>
        /// Сумма струн в электрогитарах с USB
        /// </summary>
        /// <returns></returns>
        static int GetStringElectricGuitar<T>(SortedSet<T> s)
        {
            int sum = 0;
            foreach (T item in s)
            {
                ElectricGuitar e = item as ElectricGuitar;
                if ((e != null) && (e.PowerSupply == "USB"))
                {
                    sum += e.StringsNumber;
                }
            }
            return sum;
        }

        /// <summary>
        /// Максимальное количество клавиш в фортепиаоно сщ шкальной раскладкой
        /// </summary>
        /// <returns></returns>
        static int GetMaxKeysNumberInSet<T>(SortedSet<T> s)
        {
            int max = 0;
            foreach (T item in s)
            {
                if (typeof(Piano) == item.GetType())
                {
                    Piano p = item as Piano;
                    if (p.KeyLayout == "Шкальная")
                    {
                        if (p.KeysNumber > max)
                            max = p.KeysNumber;
                    }
                }
            }
            return max;
        }

        /// <summary>
        /// Функция поиска элемента в массиве
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <param name="elementToSearcg"></param>
        /// <returns></returns>
        static int Search<T>(SortedSet<T> s, T elementToSearcg)
        {
            T[] array = s.ToArray();
            int pos = Array.BinarySearch(array, elementToSearcg);
            return pos;
        }

        static void Main(string[] args)
        {
            MusicalInstrument m1 = new MusicalInstrument("Арфа", 45);
            MusicalInstrument m2 = new MusicalInstrument("Виолончель", 85);
            MusicalInstrument m3 = new MusicalInstrument("Скрипка", 44);
            MusicalInstrument m4 = new MusicalInstrument("Барабан", 85);

            Guitar g1 = new Guitar();
            g1.IRandomInit();
            Guitar g2 = new Guitar();
            g2.IRandomInit();

            ElectricGuitar e1 = new ElectricGuitar();
            e1.IRandomInit();
            ElectricGuitar e2 = new ElectricGuitar();
            e2.IRandomInit();

            Piano p1 = new Piano();
            p1.IRandomInit();
            Piano p2 = new Piano();
            p2.IRandomInit();

            int answer;
            bool isConvertAns;

            do
            {
                Console.WriteLine("1. Универсальная коллекция Queue");
                Console.WriteLine("2. Обобщенная коллекция SortedSet");
                Console.WriteLine("3. Измерение времени выполнения");
                Console.WriteLine("0. Закончить работу");
                Console.WriteLine();

                do
                {
                    isConvertAns = int.TryParse(Console.ReadLine(), out answer);
                    if (!isConvertAns)
                        Console.WriteLine("Число введено неправильно. Введите число еще раз");
                } while (!isConvertAns);

                switch(answer)
                {
                    case 1: // коллекция Queue
                        {
                            int ans;
                            bool isConvert;

                            Queue<MusicalInstrument> queue = new Queue<MusicalInstrument>();
                            int capacity = queue.Count;

                            do
                            {
                                Console.WriteLine();
                                Console.WriteLine("1. Создание очереди");
                                Console.WriteLine("2. Добавление объекта");
                                Console.WriteLine("3. Удаление объекта");
                                Console.WriteLine("4. Запросы");
                                Console.WriteLine("5. Клонирование очереди");
                                Console.WriteLine("6. Сортировка очереди");
                                Console.WriteLine("7. Поиск элемента в очереди");
                                Console.WriteLine("8. Печать очереди");
                                Console.WriteLine("0. Назад");

                                do
                                {
                                    isConvert = int.TryParse(Console.ReadLine(), out ans);
                                    if (!isConvert)
                                        Console.WriteLine("Число введено неправильно. Введите число еще раз");
                                } while (!isConvert);

                                switch(ans)
                                {
                                    case 1: // Создание очереди
                                        {
                                            Console.WriteLine("=== Создание очереди ===");
                                            queue = new Queue<MusicalInstrument>( new MusicalInstrument[] { m1, m2, g1, g2, e1, e2, p1, p2});
                                            capacity = queue.Count;
                                            Console.WriteLine("Очередь сформирована");
                                            break;
                                        }
                                    case 2: //Добавление объекта
                                        {
                                            Console.WriteLine("=== Добавление объекта ===");
                                            MusicalInstrument instrumentToAdd = new MusicalInstrument();
                                            instrumentToAdd.Init();
                                            if (instrumentToAdd == null)
                                                throw new Exception("Элемент пустой");
                                            if (queue.Count < capacity)
                                                queue.Enqueue(instrumentToAdd);
                                            else
                                            {
                                                capacity *= 2;
                                                Queue<MusicalInstrument> temp = new Queue<MusicalInstrument> (capacity);
                                                foreach (MusicalInstrument item in queue)
                                                {
                                                    temp.Enqueue(item);
                                                }
                                                temp.Enqueue(instrumentToAdd);
                                                queue.Clear();
                                                foreach (MusicalInstrument item in temp)
                                                {
                                                    queue.Enqueue(item);
                                                }
                                                Console.WriteLine($"Элемент '{instrumentToAdd}' добавлен");
                                            }
                                            break;
                                        }
                                    case 3: //Удаление объекта
                                        {
                                            Console.WriteLine("=== Удаление объекта ===");

                                            MusicalInstrument instrToDelete = new MusicalInstrument();
                                            instrToDelete = g1;

                                            if (!queue.Contains(instrToDelete))
                                            {
                                                Console.WriteLine("Элемент не найден");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Элемент найден");
                                                Queue<MusicalInstrument> temp = new Queue<MusicalInstrument>();
                                                while (queue.Count > 0)
                                                {
                                                    MusicalInstrument item = queue.Dequeue();
                                                    if (!item.Equals(instrToDelete))
                                                        temp.Enqueue(item);
                                                    else
                                                        Console.WriteLine($"Удаляем {instrToDelete}");
                                                }
                                                queue = temp;
                                            }
                                            if (capacity / 2 >= queue.Count)
                                                capacity /= 2;
                                            break;
                                        }
                                    case 4: //Запросы
                                        {
                                            Console.WriteLine("=== Запросы ===");
                                            double avarageStringsNumber = GetAvarageStringsNumber(queue);
                                            Console.WriteLine($"Среднее количество струн всех гитар: {avarageStringsNumber.ToString("0.00")}");
                                            Console.WriteLine();

                                            int stringsNumberSum = GetStringsNumberSum(queue);
                                            Console.WriteLine($"Количество струн всех электрогитар c фиксированным источником питания: {stringsNumberSum}");
                                            Console.WriteLine();

                                            int maxKeysNumber = GetMaxKeysNumber(queue);
                                            Console.WriteLine($"Максимальное количество клавиш на фортепиано с октавной раскладкой: {maxKeysNumber}");
                                            Console.WriteLine();
                                            break;
                                        }
                                    case 5: //Клонирование очереди
                                        {
                                            Console.WriteLine("=== Клонирование очереди ===");
                                            Queue<MusicalInstrument> clonedQueue = new Queue<MusicalInstrument>();
                                            foreach (var item in queue)
                                            {
                                                if (item is Guitar)
                                                {
                                                    clonedQueue.Enqueue(item.Clone() as Guitar);
                                                }
                                                else if (item is ElectricGuitar)
                                                {
                                                    clonedQueue.Enqueue(item.Clone() as ElectricGuitar);
                                                }
                                                else if (item is Piano)
                                                {
                                                    clonedQueue.Enqueue(item.Clone() as Piano);
                                                }
                                                else if (item is MusicalInstrument)
                                                {
                                                    clonedQueue.Enqueue(item.Clone() as MusicalInstrument);
                                                }
                                            }
                                            foreach (var cloneElement in clonedQueue)
                                            {
                                                Console.WriteLine(cloneElement);
                                            }
                                            break;
                                        }
                                    case 6: //Сортировка очереди
                                        {
                                            Console.WriteLine("=== Сортировка очереди ===");
                                            MusicalInstrument[] array = queue.ToArray();
                                            Array.Sort(array);
                                            Queue<MusicalInstrument> sortedQueue = new Queue<MusicalInstrument>(array);
                                            foreach (MusicalInstrument item in sortedQueue)
                                            {
                                                Console.WriteLine(item); ;
                                            }
                                            break;
                                        }

                                    case 7: //Поиск элемента в очереди
                                        {
                                            Console.WriteLine("=== Поиск элемента в очереди ===");
                                            int index = 0;
                                            MusicalInstrument elementToSearch = new MusicalInstrument();
                                            elementToSearch = p2;

                                            if (queue == null || elementToSearch == null)
                                                throw new Exception("Очередь или элемент пустой");
           
                                            if (queue.Contains(elementToSearch))
                                            {
                                                Console.WriteLine("Элемент есть в очереди");
                                                foreach (var item in queue)
                                                {
                                                    if (item.Equals(elementToSearch))
                                                        Console.WriteLine($"Элемент {elementToSearch} находится на {index+1} месте");
                                                    index++;
                                                }                                             
                                            }
                                            else
                                                Console.WriteLine("Элемента нет в очереди");
                                            break;
                                        }

                                    case 8: //Печать очереди
                                        {
                                            Console.WriteLine("=== Печать очереди ===");
                                            foreach (MusicalInstrument item in queue)
                                            {
                                                Console.WriteLine(item);
                                            }
                                            Console.WriteLine($"В очереди {queue.Count} элементов");
                                            Console.WriteLine($"Емкость: {capacity}");
                                            break;
                                        }
                                }

                            } while (ans != 0);

                            break;
                        }
                    case 2:
                        {
                            SortedSet<MusicalInstrument> set = new SortedSet<MusicalInstrument>();
                            int capacity = set.Count;
                            int ans2;
                            bool isConvert2;

                            do
                            {
                                Console.WriteLine("1. Создание отсортированного множества");
                                Console.WriteLine("2. Добавление объекта");
                                Console.WriteLine("3. Удаление объекта");
                                Console.WriteLine("4. Запросы");
                                Console.WriteLine("5. Клонирование множества");
                                Console.WriteLine("6. Поиск элемента в множестве");
                                Console.WriteLine("7. Печать множества");
                                Console.WriteLine("0. Назад");
                                Console.WriteLine();

                                do
                                {
                                    isConvert2 = int.TryParse(Console.ReadLine(), out ans2);
                                    if (!isConvert2)
                                        Console.WriteLine("Число введено неправильно. Введите число еще раз");
                                } while (!isConvert2);

                                switch (ans2)
                                {
                                    case 1: // Создание отсортированного множества
                                        {
                                            Console.WriteLine("=== Создание отсортированного множества ===");
                                            set = new SortedSet<MusicalInstrument>(new MusicalInstrument[] { m1, m2, m3, m4, g1, e1, p1 });
                                            capacity = set.Count;
                                            Console.WriteLine("Множество сформировано");
                                            Console.WriteLine();
                                            break;
                                        }
                                    case 2: // Добавление объекта
                                        {
                                            Console.WriteLine("=== Добавление объекта в множество ===");
                                            MusicalInstrument elementToAdd = new MusicalInstrument();
                                            elementToAdd.Init();
                                            if (elementToAdd == null) // проверка на пустоту элемента
                                                throw new Exception("Элемент пуст");
                                            if (set.Count < capacity)
                                            {
                                                if (!set.Contains(elementToAdd)) // Проверка существовая элемента в множестве  
                                                {
                                                    set.Add(elementToAdd);
                                                    Console.WriteLine($"Элемент {elementToAdd} добавлен");
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"Элемент ' {elementToAdd} ' уже существует в множестве");
                                                }
                                            }
                                            else
                                            {
                                                capacity *= 2;
                                                if (!set.Contains(elementToAdd)) // Проверка существования элемента в множестве  
                                                {
                                                    SortedSet<MusicalInstrument> temp = new SortedSet<MusicalInstrument>();
                                                    foreach (MusicalInstrument element in set)
                                                    {
                                                        temp.Add(element);
                                                    }
                                                    temp.Add(elementToAdd);
                                                    set.Clear();
                                                    foreach (MusicalInstrument item in temp)
                                                    {
                                                        set.Add(item);
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"Элемент ' {elementToAdd} ' уже существует в множестве");
                                                }
                                            }
                                            break;
                                        }
                                    case 3: // Удаление объекта
                                        {
                                            Console.WriteLine("=== Удаление объекта из множества ===");
                                            MusicalInstrument elementToDelete = new MusicalInstrument();
                                            elementToDelete.Init();
                                            if (!set.Contains(elementToDelete)) // проверка на существования элемента в множестве
                                            {
                                                Console.WriteLine("Элемент не найден");
                                            }
                                            else
                                            {
                                                set.Remove(elementToDelete);
                                                Console.WriteLine($"Удаленный элемент: {elementToDelete}");
                                                Console.WriteLine();                            
                                            }
                                            if (capacity / 2 >= set.Count)
                                                capacity /= 2;
                                            break;
                                        }
                                    case 4: // Запросы
                                        {
                                            Console.WriteLine("=== Запросы ===");
                                            double avarageStringsNumber = GetSumStringsNumber(set);
                                            Console.WriteLine($"Количество струн всех гитар: {avarageStringsNumber.ToString("0.00")}");
                                            Console.WriteLine();

                                            int stringsNumberSum = GetStringElectricGuitar(set);
                                            Console.WriteLine($"Количество струн всех электрогитар c USB: {stringsNumberSum}");
                                            Console.WriteLine();

                                            int maxKeysNumber = GetMaxKeysNumberInSet(set);
                                            Console.WriteLine($"Максимальное количество клавиш на фортепиано со шкальной раскладкой: {maxKeysNumber}");
                                            Console.WriteLine();
                                            break;
                                        }
                                    case 5: // Клонирование множества
                                        {
                                            Console.WriteLine("=== Клонирование множества ===");
                                            SortedSet<MusicalInstrument> clonedSet = new SortedSet<MusicalInstrument>();
                                            foreach (var item in set)
                                            {
                                                if (item is Guitar)
                                                {
                                                    clonedSet.Add(item.Clone() as Guitar);
                                                }
                                                else if (item is ElectricGuitar)
                                                {
                                                    clonedSet.Add(item.Clone() as ElectricGuitar);
                                                }
                                                else if (item is Piano)
                                                {
                                                    clonedSet.Add(item.Clone() as Piano);
                                                }
                                                else if (item is MusicalInstrument)
                                                {
                                                    clonedSet.Add(item.Clone() as MusicalInstrument);
                                                }
                                            }
                                            foreach (var cloneElement in clonedSet)
                                            {
                                                Console.WriteLine(cloneElement);                                  
                                            }
                                            Console.WriteLine();
                                            break;
                                        }
                                    case 6: // Поиск элемента в множестве
                                        {
                                            Console.WriteLine("=== Поиск объекта в множестве ===");
                                            MusicalInstrument elementToSearch = new MusicalInstrument();
                                            elementToSearch.Init();
                                            if (set == null || elementToSearch == null)
                                                throw new Exception("Множество или элемент пусты");
                                            
                                            if (set.Contains(elementToSearch))
                                            {
                                                int pos = Search(set, elementToSearch);
                                                Console.WriteLine($"Элемент ' {elementToSearch} ' находится на {pos + 1} месте");
                                            }
                                            else
                                                Console.WriteLine("Элемента в множестве нет");
                                            break;
                                        }
                                    case 7: // Печать множества
                                        {
                                            foreach (MusicalInstrument item in set)
                                            {
                                                Console.WriteLine(item);
                                            }
                                            Console.WriteLine($"В множестве {set.Count} элементов");
                                            Console.WriteLine($"Емкость: {capacity}");
                                            Console.WriteLine();
                                            break;
                                        }
                                }
                            } while (ans2 != 0);
                            break;
                        }
                    case 3: // Измерение времени выполнения
                        {
                            Console.WriteLine("=== Измерение времени выполнения ===");
                            TestCollectoin test1 = new TestCollectoin(1000);
                            test1.MeasureTime();
                            Console.WriteLine();
                            break;
                        }
                }

            } while (answer != 0);
        }
    }
}
