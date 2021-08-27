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
                Console.WriteLine("");

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
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6}", arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);                           
                           
                        }
                        sr.Close();
                       Console.WriteLine("");
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
                    // Write column headers to first line .csv file 
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

                        //------------------------------------------------------------
                        //Loop to create array of names of all people watching project
                        string [] watch = new string[6];
                        //index of watch arr set at 0
                        int j=0;
                        //create variable for another watching answer
                        string another;			
                            do {
                                // prompt for watching
                                Console.WriteLine("Enter person watching project");
                                // save the watching into array
                                watch[j] = Console.ReadLine();
                                // increment the array index
                                j++;
                                //ask user whether there is another person watching
                                Console.WriteLine("Is there another person watching the project (Y/N)?");
                                // input whether another is watching
                                another = Console.ReadLine().ToUpper();
                                // while another person watching is "Y", continue loop
                            } while (another == "Y");
                            //create a string to hold names of all people watching (starts empty)
                            string watching = "";
                            //if more than one person watching, do loop
                            if (j>=1){
                                //loop through all except last name listed and put pipe between them 
                                for (int k=0; k<j-1; k++) {
                                    watching += watch[k] + "|";
                                }
                                //cap string with last name listed
                                watching = watching + watch[j-1];
                            } else
                                //if only one name, no need for pipes 
                                {
                                    watching = watch[0];
                                }
			            //---------------------------------------------------------		

                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", TicketID, summary, status, priority, submitter, assigned, watching);
                    }
                    sw.Close();
                }
            } while (choice == "1" || choice == "2");
        }
    }
}
