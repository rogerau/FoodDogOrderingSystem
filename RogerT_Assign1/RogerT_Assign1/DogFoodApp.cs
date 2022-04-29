using System;
using static System.Console;

namespace RogerT_Assign1
{
    class DogFoodApp
    {
        static void Main(string[] args)
        {
            //Create 3 instances of class DogFood using constructor of 2 parameters and set the values 
            //of BrandName and CanUnitPrice properties for each one.
            //Each object/instance will represent one brand.
            //Create the first object/instance
            DogFood DogFoodObject1 = new DogFood("Ricocan", 15.25);


            //Create the second object/instance
            DogFood DogFoodObject2 = new DogFood("Pedigree", 16.75);


            //Creat the third object/instance
            DogFood DogFoodObject3 = new DogFood("Kabo", 18.90);

            //Display instructions(program objetive and program inputs).
            DisplayInstructions();
            WriteLine();

            //Display initial information about the store (store name, stock brands and unit prices), by passing each object information as parameter.
            DisplayInitialInfo(DogFoodObject1, DogFoodObject2, DogFoodObject3);
            WriteLine("Let us begin by entering the number of cans you need for each of these dog food brands...");
            WriteLine();

            //Prompt users to enter the number of cans they want for each brand and update the values of NumCans property for each object,
            //by passing each object as a parameter.
            UpdateNumCans(DogFoodObject1);
            UpdateNumCans(DogFoodObject2);
            UpdateNumCans(DogFoodObject3);
            WriteLine("The number of cans for each brand name has been entered");
            WriteLine();

            //Prompt users to decide what to do (view order, update order or quit the program) and,
            //allow users to see/answer what they ordered/required with the option selected, by passing each object information as a parameter.
            PerformAction(DogFoodObject1, DogFoodObject2, DogFoodObject3);
            WriteLine();
            ReadKey();

        }

        //Void method to write program instructions(program objective and program inputs)
        static void DisplayInstructions()
        {
            WriteLine("The following program implements a dog food ordering system\n" +
                "that allows users to make an order between three dog food brands.\n" +
                "Users can decide how many cans they want for each brand based on their unit price.\n" +
                "Also, the program allows user to see their order in detail, including the bill for each dog food brand selected\n" +
                "the total bill before discount, total discount (if applicable), and the total bill after discount.\n" +
                "Furthermore, allows the user to update their order for each brand selected.\n");

            Write("To achieve that, the program requires the following information from the user:\n" +
                "   1. The quantity of cans for each brand selected. \n" +
                "   2. Select options about if they want to view or update the order or quit the program. \n" +
                "If you are ready to start the program, press a key: ");
            ReadKey();
        }

        //Void method to write initial information about store (store name, stock brands and unit prices)
        //Each object is passed as a parameter to allow the individual information of each object is displayed.
        static void DisplayInitialInfo(DogFood anyDogFood1, DogFood anyDogFood2, DogFood anyDogFood3)
        {
            string asterisk = new string('*', 80);
            WriteLine(asterisk);
            WriteLine("*{0,65} {1,-12}*", "HappyDog Online Dog Food Ordering System", " ");
            WriteLine("*{0,55} {1,-22}*", "Place your order now!", " ");
            WriteLine(asterisk + "\n");
            WriteLine(asterisk);
            WriteLine("*{0,55} {1,-22}*", "Dog Food Brands in stock given below", " ");
            WriteLine("*{0,30} {1,-7}: {2,-38:C2}*", "Can Unit Price for", anyDogFood1.BrandName, anyDogFood1.CanUnitPrice);
            WriteLine("*{0,29} {1,-8}: {2,-38:C2}*", "Can Unit Price for", anyDogFood2.BrandName, anyDogFood2.CanUnitPrice);
            WriteLine("*{0,33} {1,-4}: {2,-38:C2}*", "Can Unit Price for", anyDogFood3.BrandName, anyDogFood3.CanUnitPrice);
            WriteLine(asterisk);
        }

        //Void method to allow users to enter the numbers of cans wanted for each brand
        //and to update the values of NumCans property of each object.
        static void UpdateNumCans(DogFood anyDogFood)
        {
            Write("Enter the number of cans for " + anyDogFood.BrandName + ": ");
            anyDogFood.NumCans = int.Parse(ReadLine());
        }

        //Void method to allow users to decide to view orders, update orders, or quit the program. 
        //Each object is passed as a parameter to allow the individual information of each object to be used by the user
        //to see/answer whatever is needed in each option.
        static void PerformAction(DogFood anyDogFood1, DogFood anyDogFood2, DogFood anyDogFood3)
        {
            //Prompt users to select only one of the 3 numbers (1:view, 2:update or 3:quit).
            WriteLine("What would you like to do?");
            Write("Press 1 for View Order, " +
                "Press 2 for Update Order, " +
                "Press 3 for quitting the application: ");
            int numElection;
            //Validate that values entered by users are whole numbers or 1, 2, or 3.
            //If the value entered is incorrect, the program prompt again the users.
            while (!int.TryParse(ReadLine(), out numElection) || numElection < 1 || numElection > 3)
            {
                Write("Error!. You must decide between 1, 2 or 3. Please try again: ");
            }
            //If the value entered is correct, the program checks each option to decide which belongs to the value entered
            //and perform the action related to the number selected.
            if (numElection == 1)
            {
                //If the number selected is 1, display the order in detail
                ViewOrder(anyDogFood1, anyDogFood2, anyDogFood3);

            }
            if (numElection == 2)
            {
                //If the number selected is 2, allow users to update their order
                UpdateOrder(anyDogFood1, anyDogFood2, anyDogFood3);

            }
            if (numElection == 3)
            {
                //If the number selected is 3, allow users to quit the program
                Write("Thank you for placing the dog food order. Goob Bye!");
            }
        }

        //Void method to display in detail the order made by the users (brand name, can unit price, number of cans ordered for each brand, total amount of each brand,
        //the total amount before Discount, total discount and total amount after Discount).
        //Each object is passed as a parameter to allow the individual information of each object is displayed.
        static void ViewOrder(DogFood anyDogFood1, DogFood anyDogFood2, DogFood anyDogFood3)
        {
            //Store the result of ComputerOrderSummary method in variable totalAfterDiscount.
            double totalAfterDiscount = ComputerOrderSummary(anyDogFood1, anyDogFood2, anyDogFood3, out double totalBeforeDiscount, out double discountAmount);
            WriteLine("Your Dog Food Order");
            string asterisk = new string('*', 80);
            WriteLine(asterisk);
            WriteLine(anyDogFood1);
            WriteLine("*{0,39} {0,38}*", " ");
            WriteLine(anyDogFood2);
            WriteLine("*{0,39} {0,38}*", " ");
            WriteLine(anyDogFood3);
            WriteLine("*{0,39} {0,38}*", " ");
            WriteLine("*{0,35}: {1,-41}*", "Total before discount", totalBeforeDiscount.ToString("C2"));
            WriteLine("*{0,35}: {1,-41}*", "Discount", discountAmount.ToString("C2"));
            WriteLine("*{0,35}: {1,-41}*", "Total after discount", totalAfterDiscount.ToString("C2"));
            WriteLine(asterisk);
            WriteLine();
            //After displaying the users' orders, allow users to decide if they want to view their order again, update their orders, or quit the program. 
            PerformAction(anyDogFood1, anyDogFood2, anyDogFood3);
        }

        //Value return method to compute the total amount after discount based on the total amount before discount and total discount (if applicable).
        //Each object is passed as a parameter to allow the method to use each object information to do the computation.
        static double ComputerOrderSummary(DogFood anyDogFood1, DogFood anyDogFood2, DogFood anyDogFood3, out double totalBeforeDiscount, out double discountAmount)
        {
            //Calculate the total amount before discount by adding each brand total amount.
            totalBeforeDiscount = anyDogFood1.BrandTotal + anyDogFood2.BrandTotal + anyDogFood3.BrandTotal;
            //Check if the total amount before discount excess of 75 dollars or not.
            if (totalBeforeDiscount > 75)
            {
                //If excess 75 dollars, add 15% discount to the total amount before discount.
                discountAmount = 0.15 * totalBeforeDiscount;
            }
            else
            {
                //If not, do not add any discount to the total amount before the discount.
                discountAmount = 0;
            }

            return (totalBeforeDiscount - discountAmount);
        }

        //Void method to allow users to decide if they want to update the number of cans ordered of one of the brands selected
        //Each object is passed as a parameter to allow the individual information of each object is displayed and to assign
        //a new value to NumCans property of the object selected.
        static void UpdateOrder(DogFood anyDogFood1, DogFood anyDogFood2, DogFood anyDogFood3)
        {
            //Prompt user to select only one of the 3 brands (ricocan, pedigree or kabo) for update.
            WriteLine("Updating your dog food order");
            Write("Press 1 to update number of cans for " + anyDogFood1.BrandName + "\n");
            Write("Press 2 to update number of cans for " + anyDogFood2.BrandName + "\n");
            Write("Press 3 to update number of cans for " + anyDogFood3.BrandName + "\n");
            Write("Enter the number (1,2, 3): ");
            int updateNumber;
            //Validate that values entered by users are whole numbers or 1, 2, or 3.
            //If the value entered is incorrect, the program prompt again the users.
            while (!int.TryParse(ReadLine(), out updateNumber) || updateNumber < 1 || updateNumber > 3)
            {
                Write("Error!. You must decide between 1, 2 or 3. Please try again: ");
            }
            //If the value entered is correct, the program checks each option to decide which belongs to the value entered
            //and perform the action related to the number selected.
            if (updateNumber == 1)
            {
                //If the number selected is 1, prompt users to enter the new value of the Ricocan brand, assign the new value to NumCans property and
                //display the value entered.
                Write("Enter the new quantity for " + anyDogFood1.BrandName + ": ");
                anyDogFood1.NumCans = int.Parse(ReadLine());
                Write("Great! Quantity for " + anyDogFood1.BrandName + " has been updated to " + anyDogFood1.NumCans + "\n");
            }

            if (updateNumber == 2)
            {
                //If the number selected is 2, prompt users to enter the new value of the Pedigree brand, assign the new value to NumCans property and
                //display the value entered.
                Write("Enter the new quantity for " + anyDogFood2.BrandName + ": ");
                anyDogFood2.NumCans = int.Parse(ReadLine());
                Write("Great! Quantity for " + anyDogFood2.BrandName + " has been updated to " + anyDogFood2.NumCans + "\n");
            }

            if (updateNumber == 3)
            {
                //If the number selected is 3, prompt users to enter the new value of the Kabo brand, assign the new value to NumCans property and
                //display the value entered.
                Write("Enter the new quantity for " + anyDogFood3.BrandName + ": ");
                anyDogFood3.NumCans = int.Parse(ReadLine());
                Write("Great! Quantity for " + anyDogFood3.BrandName + " has been updated to " + anyDogFood3.NumCans + "\n");
            }

            WriteLine();
            //After updating the users' orders, allow users to decide if they want to view their order again, update their orders, or quit the program. 
            PerformAction(anyDogFood1, anyDogFood2, anyDogFood3);

        }

    }
}