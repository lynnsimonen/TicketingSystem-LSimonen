using System;
using System.IO;

namespace TicketingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
           string file = "TicketingSystem.csv";
            string choice;
            do
            {
                // ask user a question
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();

                if (choice == "1")
                {
                     // read data from file
                    if (File.Exists(file))
                    {
                       
                        // read data from file
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            // convert string to array
                            string[] arr = line.Split(',');
                            // display array data
                            Console.WriteLine("{0}.{1}, {2}, {3}, {4}, {5}, {6})", arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);                           
                        }
                        sr.Close();
                       
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
                else if (choice == "2")
                {
                    // create file from data
                    StreamWriter sw = new StreamWriter(file);
                    sw.WriteLine("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching");
                    for (int i = 0; i < 7; i++)
                    {
                        // ask a question  -- USING STRING INTERPOLATION
                        Console.WriteLine("Enter new ticket (Y/N)?");
                        // input the response
                        string resp = Console.ReadLine().ToUpper();
                        // if the response is anything other than "Y", stop asking
                        if (resp != "Y") { break; }

                        // create and save TicketID automatically
                        int TicketID = i + 1;
                        //Console.WriteLine(TicketID + ",");

                        // prompt for summary
                        Console.WriteLine("Enter a summary of the computer problem");
                        // save the summary
                        string summary = Console.ReadLine();

                        // prompt for status
                        Console.WriteLine("Enter ticket status: Open OR Closed");
                        // save the status
                        string status = Console.ReadLine();

                         // prompt for priority
                        Console.WriteLine("Enter ticket priority: High OR Low");
                        // save the priority
                        string priority = Console.ReadLine();

                        // prompt for submitter
                        Console.WriteLine("Please enter your name as submitter");
                        // save the submitter
                        string submitter = Console.ReadLine();

                        // prompt for assigned
                        Console.WriteLine("Enter person assigned project");
                        // save the assigned
                        string assigned = Console.ReadLine();

                        // prompt for watching
                        Console.WriteLine("Enter person watching project");
                        // save the watching
                        string watching = Console.ReadLine();

                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", TicketID, summary, status, priority, submitter, assigned, watching);
                    }
                    sw.Close();
                }
            } while (choice == "1" || choice == "2");
        }
    }
}
