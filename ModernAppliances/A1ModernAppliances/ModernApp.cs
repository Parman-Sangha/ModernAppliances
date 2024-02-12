using System;
using System.Collections.Generic;
using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            // Prompt the user to enter the item number of an appliance
            Console.WriteLine("\nEnter the item number of an appliance: ");
            // Create a variable to hold the item number
            long itemNum;
            // Get the user's input as a string
            string userIn = Console.ReadLine();
            // Convert the user's input from a string to a long integer
            itemNum = long.Parse(userIn);
            // Create a variable to hold the found appliance
            List<Appliance> foundAppliance = new List<Appliance>();
            // Loop through the list of appliances
            foreach (Appliance app in Appliances)
            {
                // Test if the appliance's item number matches the entered item number
                if (app.ItemNumber == itemNum)
                {
                    // Assign the appliance to the foundAppliance variable
                    foundAppliance.Add(app);
                    // Break out of the loop
                    break;
                }
            }
            // Test if no appliance was found
            if (foundAppliance.Count == 0)
            {
                // Write a message indicating that no appliances were found
                Console.WriteLine("\nNo appliances found with that item number.");
            }
            else
            {
                // Get the first appliance from the foundAppliance list (since there should only be one)
                Appliance applianceToCheckout = foundAppliance[0];
                // Test if the appliance is available
                if (applianceToCheckout.IsAvailable == true)
                {
                    // Check out the appliance
                    applianceToCheckout.Checkout();

                    // Write a message indicating that the appliance has been checked out
                    Console.WriteLine("\nAppliance \"" + applianceToCheckout.ItemNumber.ToString() + "\" has been checked out.");
                }
                else
                {
                    // Write a message indicating that the appliance is not available
                    Console.WriteLine("\nThe appliance is not available to be checked out.");
                }
            }
        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            // Write "Enter brand to search for:"
            Console.WriteLine("Enter brand to search for:");
            // Create string variable to hold entered brand
            // Get user input as string and assign to variable.
            string brand = Console.ReadLine();

            // Create list to hold found Appliance objects
            List<Appliance> found = new List<Appliance>();

            // Iterate through loaded appliances
            foreach (Appliance app in Appliances)
            {
                // Test current appliance brand matches what user entered
                if (app.Brand.Contains(brand))
                {
                    // Add current appliance in list to found list
                    found.Add(app);
                }
            }
            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            Console.WriteLine("Enter number of doors: 2 (double door, 3 (three doors) or 4 (four doors)");
            // Create variable to hold entered number of doors
            // Get user input as string and assign to variable
            // Convert user input from string to int and store as number of doors variable.
            int numOfDoors = Convert.ToInt32(Console.ReadLine());

            // Create list to hold found Appliance objects
            List<Appliance> found = new List<Appliance>();

            // Iterate/loop through Appliances
            foreach (Appliance app in Appliances)
            {
                // Test that current appliance is a refrigerator
                if (app is Refrigerator)
                {
                    // Down cast Appliance to Refrigerator
                    Refrigerator fridge = (Refrigerator)app;

                    // Test user entered 0 or refrigerator doors equals what user entered.
                    if (numOfDoors == 0 | fridge.Doors == numOfDoors)
                    {
                        // Add current appliance in list to found list
                        found.Add(fridge);
                    }
                }
            }
            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        public override void DisplayVacuums()
        {
            // Write "Enter battery voltage value. 18 V (low) or 24 V (high)"
            Console.WriteLine("Enter battery voltage value. 18 V (low) or 24 V (high)");

            // Get user input for voltage
            int voltage = Convert.ToInt32(Console.ReadLine());

            // If input is not a valid option (18 or 24)
            if (voltage != 18 && voltage != 24)
            {
                // Write "Invalid option."
                Console.WriteLine("Invalid option.");
                // Return to calling (previous) method
                return;
            }

            // Create found variable to hold list of found appliances.
            List<Appliance> found = new List<Appliance>();

            // Loop through Appliances
            foreach (Appliance app in Appliances)
            {
                // Check if current appliance is vacuum
                if (app is Vacuum)
                {
                    // Down cast current Appliance to Vacuum object
                    Vacuum vacuum = (Vacuum)app;

                    // Test grade is "Any" or grade is equal to current vacuum grade and voltage is 0 or voltage is equal to current vacuum voltage
                    if (voltage == 0 | voltage == vacuum.BatteryVoltage)
                    {
                        // Add current appliance in list to found list
                        found.Add(vacuum);
                    }
                }
            }
            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            // Display options.
            Console.WriteLine("Room where the microwave will be installed: K (kitchen) or W (work site):");

            // Get user input as char
            char roomType = Convert.ToChar(Console.ReadLine());

            // Check if inputted room type is invalid.
            if (roomType != 'K' && roomType != 'W')
            {
                // Write "Invalid option."
                Console.WriteLine("Invalid option.");
                // Return to calling method
                return;
            }
            // Create variable that holds list of 'found' appliances
            List<Appliance> found = new List<Appliance>();

            // Loop through Appliances
            foreach (Appliance app in Appliances)
            {
                // Test current appliance is Microwave
                if (app is Microwave)
                {
                    // Down cast Appliance to Microwave
                    Microwave microwave = (Microwave)app;

                    // Test room type equals 'K' or 'W'
                    if (roomType == 'K' || roomType == 'W')
                    {
                        // Add current appliance in list to found list
                        found.Add(microwave);
                    }
                }
            }
            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            // Display options
            Console.WriteLine("Enter the sound rating of the dishwasher: Qt (quietest), Qr (Quieter), Qu (Quiet) or M (Moderate):");
            // Get user input as string
            string sound = Console.ReadLine();

            // Put valid options in array to make it easier to check if a valid option was selected
            string[] sounds = { "Qt", "Qr", "Qu", "M" };
            if (Array.Exists(sounds, s => s == sound) == false)
            {
                // Write "Invalid option."
                Console.WriteLine("Invalid option.");
                // Return to calling method
                return;
            }

            // Create variable that holds list of found appliances
            List<Appliance> found = new List<Appliance>();

            // Loop through Appliances
            foreach (Appliance app in Appliances)
            {
                // Test if current appliance is dishwasher
                if (app is Dishwasher)
                {
                    // Down cast current Appliance to Dishwasher
                    Dishwasher washer = (Dishwasher)app;

                    // Test sound rating is "Any" or equals soundrating for current dishwasher
                    if (sound == "Any" | sound == washer.SoundRating)
                    {
                        // Add current appliance in list to found list
                        found.Add(washer);
                    }
                }
            }
            // Display found appliances (up to max. number inputted)
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            // Write "Enter number of appliances: "
            Console.WriteLine("Enter number of appliances:");
            // Get user input as string and assign to variable
            // Convert user input from string to int
            int num = Convert.ToInt32(Console.ReadLine());

            // Create variable to hold list of found appliances
            List<Appliance> found = new List<Appliance>();

            // Add the appliances to a found list so they they can be randomly resorted without it affecting the original list of appliances
            foreach (Appliance app in Appliances)
            {
                found.Add(app);
            }

            // Randomize list of found appliances
            found.Sort(new RandomComparer());

            // Display found appliances (up to max. number inputted)
            DisplayAppliancesFromList(found, num);
        }

        // Implement DisplayAppliancesFromList method
        private void DisplayAppliancesFromList(List<Appliance> appliances, int maxCount)
        {
            int count = 0;
            foreach (Appliance app in appliances)
            {
                Console.WriteLine(app);
                count++;
                if (count == maxCount) break;
            }
        }
    }
}
