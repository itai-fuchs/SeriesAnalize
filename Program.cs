using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesAnalize
{
    /// <summary>
    /// The program receives a list of numbers or as args 
    /// or from the console. 
    /// and performs several manipulations on the list.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            // make new list
                List<double> series = new List<double>();

            //get args
                bool isValidArgs()
                {
                    if (args.Length < 3)
                    {
                        return false;
                    }
                    foreach (string arg in args)
                    {
                        if (double.TryParse(arg, out double number) && number > 0) series.Add(number);
                        else
                        {
                            series.Clear();
                            return false;
                        }

                    }
                Console.WriteLine("Arguments received successfully");
                    return true;
                }

            //get numbers from console
                void GetNumbers()

                {
                    double number;
                    while (true)
                    {
                        Console.WriteLine("enter at least 3 positive numbers\n" +
                            "to continue press e:");
                        string temp = Console.ReadLine();
                        if (temp == "e")
                        {
                            if (series_Length(series) >= 3) break;

                            else Console.WriteLine("need at least 3 numbers\n");
                        }
                        else
                        {
                            bool is_number = double.TryParse(temp, out number);
                            if (is_number && number > 0) series.Add(number);

                            else Console.WriteLine("invalid input");
                        }
                    }
                }

            //display series
                void display_series(List<double> list)
                {
                    foreach (double arg in list) Console.Write($"{arg}, ");
                }

            //display revers_series
                void display_revers_series(List<double> list)
                {
                    for (int i = series_Length(series) - 1; i >= 0; i--)
                    {
                        Console.Write($"{list[i]}, ");
                    }
                }

            //return sorted list
                List<double> buble_Sort(List<double> list)
                {
                    List<double> sorted_list = new List<double>(list); ;
                    for (int i = 0; i < series_Length(sorted_list) - 1; i++)
                    {
                        bool sorted = true;
                        for (int j = 0; j < series_Length(sorted_list) - i - 1; j++)
                        {
                            if (sorted_list[j + 1] < sorted_list[j])
                            {
                                double temp = sorted_list[j];
                                sorted_list[j] = sorted_list[j + 1];
                                sorted_list[j + 1] = temp;
                                sorted = false;
                            }
                        }
                        if (sorted) return sorted_list;
                    }
                    return sorted_list;
                }

            //return max number
                double maxNumber(List<double> list)
                {
                    double max = 0;
                    foreach (double item in list)
                    {
                        if (item > max) max = item;

                    }
                    return max;
                }

            //return min number
                double minNumber(List<double> list)
                {
                    double min = list[0];
                    foreach (double item in list)
                    {
                        if (item < min) min = item;

                    }
                    return min;
                }

            // return average series
                double average(List<double> list)
                {
                    return series_sum(series) / series_Length(series);
                }

            //return series length
                int series_Length(List<double> list)
                {
                    int i = 0;
                    foreach (double item in list)
                    {
                        i++;
                    }
                    return i;
                }

            //return series sum
                double series_sum(List<double> list)
                {
                    double sum = 0;
                    for (int i = 0; i <= series_Length(list) - 1; i++) sum += list[i];
                    return sum;
                }

            //display menu
                string menu()
                {

                    Console.WriteLine("menu:\na.Input a Series. (Replace the current series)" +
                        "\nb.Display the series in the order it was entered." +
                        "\nc.Display the series in the reversed order it was entered." +
                        "\nd.Display the series in sorted order(from low to high)." +
                        "\ne.Display the Max value of the series." +
                        "\nf.Display the Min value of the series." +
                        "\ng.Display the Average of the series." +
                        "\nh.Display the Number of elements in the series." +
                        "\ni.Display the Sum of the series." +
                        "\nj.Exit.");

                    string user_choice = Console.ReadLine();
                    return user_choice;
                }

            //manager
                void manager()
                {
                // try to get args
                    bool valid = isValidArgs();
                // if there are not args, ask numbers from console
                    if (!valid) GetNumbers();

                    // menu architecture
                    string user_input = "";
                    while (user_input != "j")
                    {
                        Console.WriteLine("");
                        user_input = menu();
                        switch (user_input)
                        {
                            case "a":
                            series.Clear();
                            GetNumbers();
                            
                                break;
                            case "b":
                                display_series(series);
                                break;
                            case "c":
                                display_revers_series(series);
                                break;
                            case "d":
                                foreach (double number in buble_Sort(series))
                                    Console.Write($"{number}, ");
                                break;
                            case "e":
                                Console.WriteLine(maxNumber(series));
                                break;
                            case "f":
                                Console.WriteLine(minNumber(series));
                                break;
                            case "g":
                                Console.WriteLine(average(series));
                                break;
                            case "h":
                                Console.WriteLine(series_Length(series));
                                break;
                            case "i":
                                Console.WriteLine(series_sum(series));
                                break;
                            default:
                                Console.WriteLine("invalid input");
                                break;
                            case "j":
                                break;
                        }
                    }
                    Console.WriteLine("you are exit the program");
                }

            manager();

            }
        }
    }



















































