using System.Globalization;

namespace FinalReview_Part1_CSI120
{
    internal class Program
    {
        // Kady Tran
        // 06/05/2024
        // Lecture 15 - Final Review 1 + 2

        // Collections of Videos

        static Video[] videos = new Video[2];

        static void Main(string[] args)
        {
            Preload();



        } // Main

        // Menu
        // 1. Display all videos
        // 2. Add a video
        // 3. Edit a video
        // 4. Find by name
        // 5. Display average duration
        // 6. Display above a view count

        public static void Menu()
        {
            bool isRunning = true;

            do
            {

                Console.WriteLine("1. Display All Videos");
                Console.WriteLine("2. Add A Video");
                Console.WriteLine("3. Edit A Video");
                Console.WriteLine("4. Find By Name");
                Console.WriteLine("5. Display Average Duration");
                Console.WriteLine("6. Display Above A View Count (Optional) ");
                Console.WriteLine("7. Exit");

                Console.WriteLine("Please enter your choice: ");
                string userChoice = Console.ReadLine();

                switch(userChoice)
                {
                    case "1":
                        DisplayAllVideos();
                        break;
                    case "2":
                        AddVideo();
                        break;
                    case "3":

                        break;
                    case "4":
                        FindAndDisplayByName();
                        break;
                    case "5":
                        Console.WriteLine($"Average Duration of Videos are {AverageLengthOfVideos()}");
                        break;
                    case "6":
                        Console.Write("Enter a view count: ");
                        string userInput = Console.ReadLine();
                        int viewCount = int.Parse(userInput);

                        DisplayAllVideosAboveViewCount(viewCount);

                        break;
                    case "7":
                        isRunning = false;
                        Console.WriteLine("Thank you!");
                        break;
                    default:
                        Console.WriteLine("Enter a valid command");
                        break;

                }

                Console.WriteLine("\n\n");

            } while (isRunning);
        }

        public static void Preload()
        {
            videos[0] = new Video("Laugh Out Loud Moments", 0, 2592, 567794);
            videos[1] = new Video("My Morning Routine Vlog", 2, 4541, 70378);
        }

        //Create a class from data provided

        //Display All Videos ( Probably need a loop )
        public static void DisplayAllVideos()
        {

            // foreach ( TYPE varName in collection ) {}
            foreach (Video vid in videos)
            {
                if (vid != null)
                {
                    Console.WriteLine(vid.DisplayWithFormatting());
                }

            }

        }

        //Add Videos ( Collection expands if we run out of room ) ( Lecture 13 - Array Capacity  )
        public static void AddVideo()
        {
            // Name
            // Category
            // Duration
            // Views
            try
            {
                // Prompt User for Video Information
                Video usersVideo = GenerateUsersVideo();

                int openIndex = LastAvailableIndex();

                if (openIndex == -1)
                {
                    Console.WriteLine("The array is full");
                    IncreaseArraySize();
                    openIndex = LastAvailableIndex();
                }

                videos[openIndex] = usersVideo;
                DisplayAllVideos();

                //

            }
            catch (Exception ex)
            {
                Console.WriteLine("Please enter a valid number.");
            }

        }

        // Double the array size and move the elements from the first array to the second
        public static void IncreaseArraySize()
        {
            // Make a temp array double the size of the first array
            Video[] tempArray = new Video[videos.Length * 2];

            // Move the elements from the first array to the second
            for (int i = 0; i < videos.Length; i++)
            {
                tempArray[i] = videos[i];
            }

            // Replace the original array with the new one
            videos = tempArray;
        }


        // Checks for last open element
        public static int LastAvailableIndex()
        {
            // Go through each element in the array

            for (int i = 0; i < videos.Length; i++)
            {
                // checking to see if a spot in the array is null
                Video temp = videos[i];

                if (temp == null)
                {
                    // returning the index of the empty space
                    return i;
                }

            }

            // If no empty space is found, return -1
            return -1;
        }

        public static Video GenerateUsersVideo()
        {
            Console.Write("Enter a video name: ");
            string videoName = Console.ReadLine();
            Console.Write("Enter a Category name - 1 Comedy  - 2 Action - 3 Vlog - 4 Animation: ");
            int category = int.Parse(Console.ReadLine());
            Console.Write("Enter duration in seconds ");
            int duration = int.Parse(Console.ReadLine());
            Console.Write("Enter number of Views ");
            int views = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Video newVideo = new Video(videoName, category, duration, views);
            return newVideo;
        }


        //Edit Videos (Refresher)
        // - 1 List all videos including their index ( or find the video by searching and get the index )\
        // - 2 Give an option for th euser to change different fields, including cancelling the option

        //Create Menu for everything ( Create a menu using a switch and while loop )



        // Not included in final : Return all videos by category ( Using Linear Search - Returning a new array )

        //Find and Display Video by Name ( Using Linear Search )

        // void FindAndDisplayByName()
        // Method : searches through your array, checks for a name, displays result if found

        // 1. Remove case sensitivity
             // How to remove case sensitivity
             
        // 2. Display a message incase video is not found

        /*
        public static void FindAndDisplayByName(string nameToSearchFor)
        {
            // Converting the users argument into all uppercase
            nameToSearchFor = nameToSearchFor.ToUpper();
            // Find = Search through an array
            // Step 1: Loop through our array
            for (int i = 0; i < videos.Length; i++)
            {
                Video currentVideo = videos[i];

                // Compare the nameToSearchFor to the currentVideo.name
                // If they are the same, display information
                if(currentVideo.Name.ToUpper() == nameToSearchFor)
                {
                    // IF the name is found, display the information to screen
                    Console.WriteLine(currentVideo.DisplayWithFormatting());
                }



            }
        }
        */

        // Separate our method into 2 parts
        // 1. Is find by name
        // 2. Is display result
        public static int FindByName(string nameToSearchFor)
        {
            nameToSearchFor = nameToSearchFor.ToLower();

            for (int i = 0; i < videos.Length; i++)
            {
                Video currentVideo = videos[i];

                if (nameToSearchFor == currentVideo.Name.ToLower())
                {
                    return i;
                }

            }

            // Return -1 if the Video is not found 
            return -1;
        }

        // Display information based on if a video is found

        public static void FindAndDisplayByName()
        {
            Console.Write("Enter a name to search for: ");
            string userInput = Console.ReadLine();

            int nameIndex = FindByName(userInput);


            DisplayByName(nameIndex);
        }


        public static void DisplayByName(int videoIndex)
        {
            // Check to see if the video index is greather than number of elements in the array
            //if(videoIndex > videos.Length)
            //{
            //    Console.WriteLine("That number is out of bounds");
            //}

            if(videoIndex == -1)
            {
                Console.WriteLine("That video does not exist");
            }
            else
            {
                Video videoByName = videos[videoIndex];
                Console.WriteLine(videoByName.DisplayWithFormatting());
            }

        }

        //Get Average Length of Videos ( Loop and Operations )
        // double AverageLengthOfVideos()
        // Method: Return the average length of all the videos, in a second format
        public static double AverageLengthOfVideos()
        {
            // Sum all the numbers
            // Divide by number of elements

            double sum = 0;

            for (int i = 0; i < videos.Length; i++)
            {
                sum += videos[i].Duration;
            }

            // Divide by the number of elements
            // 5 videos, / 5
            // arrayName.Length
            double average = sum / videos.Length;

            return average;

        }


        // Display All Videos Above a certain view count ( Linear Search )
        // void DisplayAllVideosAboveACertainViewCount(int)
        public static void DisplayAllVideosAboveViewCount(int viewCount)
        {
            // Keep count of how many videos are ABOVE the view count
            // If the amount is 0, display no videos above the count

            // 1. Loop through our array
            foreach (Video currentVideo in videos)
            {
                // 2. Check if current view is great than the argument
                if (currentVideo.Views > viewCount)
                {
                    // 3. Display if true
                    Console.WriteLine(currentVideo.DisplayWithFormatting());
                }
            } 
        }




        #region Examples

        public static void TimeFormattingExample()
        {
            int numOfSeconds = 17779;
            int secondsInMinutes = 60;
            int minutesInHours = 60;

            // This equation will get the TOTAL minutes
            int totalMinutes = numOfSeconds / secondsInMinutes;

            int hours = totalMinutes / minutesInHours;

            int minutes = totalMinutes % minutesInHours;

            // This equation will always return the remaining seconds
            int seconds = numOfSeconds % secondsInMinutes;
            //numOfSeconds %= secondsInMinutes;

            string formattedTime = $"{hours}:{minutes}:{seconds}";

            //Console.WriteLine(hours);
            //Console.WriteLine(minutes);
            //Console.WriteLine(seconds);
            Console.WriteLine(formattedTime);
        }

        public static void FindByNameExamples()
        {
            // Testing out our method FindAndDisplayByName(string)
            // Works: Will display the name
            // If Not: Displays Nothing
            //FindAndDisplayByName("Laugh Out loud Moments");

            // Testing : Find by name
            // Results :
            // if found return index
            // if not found return -1

            int searchForVideo = FindByName("Eternal Sunshine");

            DisplayByName(searchForVideo);
            
        }

        #endregion Examples

    } // class Program



    // ---- In My Namespace, but underneath program create our new class, Video

    public class Video
    {
        // Fields
        public string Name;
        public int Category;
        public int Duration;
        public int Views;

        // Constructors
        public Video(string name, int category, int duration, int views)
        {
            Name = name;
            Category = category;
            Duration = duration;
            Views = views;
        }

        // Default Constructor
        public Video()
        {
            Name = "No Video";
            Category = -1;
            Duration = 0;
            Views = 0;
        }


        // Methods

        public string DisplayFormattedTime()
        {

            int numOfSeconds = Duration;
            int secondsInMinutes = 60;
            int minutesInHours = 60;

            // This equation will get the TOTAL minutes
            int totalMinutes = numOfSeconds / secondsInMinutes;

            // Get total hours
            int hours = totalMinutes / minutesInHours;

            // Get Total Minutes
            int minutes = totalMinutes % minutesInHours;

            // This equation will always return the remaining seconds
            int seconds = numOfSeconds % secondsInMinutes;
            //numOfSeconds %= secondsInMinutes;

            string formattedTime = $"{hours}:{minutes}:{seconds}";

            return formattedTime;
        }

        public string DisplayCategory()
        {
            //        Categories
            //- Comedy : 0
            //- Action : 1
            //- Vlog : 2
            //- Animation : 3
            string categoryName = "";

            switch (Category)
            {
                case 0:
                    categoryName = "Comedy";
                    break;
                case 1:
                    categoryName = "Action";
                    break;
                case 2:
                    categoryName = "Vlog";
                    break;
                case 3:
                    categoryName = "Animation";
                    break;
                default:
                    categoryName = "No Category";
                    break;

            }

            return categoryName;
        }

        public string DisplayWithFormatting()
        {
            //Display With Formatting ( Do i create a method in program, or can I create a method in the Data class to do this )

            //- Video Name
            //- Category ( Name, not number )
            //- Duration ( In Formatted Time )
            //- Number of View

            string formattedString = "";
            formattedString += Name + "\n"; // Name
            formattedString += DisplayCategory() + "\n"; // Category
            formattedString += DisplayFormattedTime() + "\n"; // Formatted Time
            formattedString += $"Views: {Views} \n"; // Views : Views

            return formattedString;
        }

    }

} // namespace

