using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogerT_Assign1
{
    class DogFood
    {

        //Defining properties
        //read-only property
        public string BrandName
        {
            get;
        }

        //read-only property
        public double CanUnitPrice
        {
            get;
        }

        //read-write property
        public int NumCans
        {
            get; set;
        }

        //read-only computed property
        public double BrandTotal
        {
            get
            {
                return NumCans * (CanUnitPrice);
            }
        }

        //Define constructors
        //Default constructor

        public DogFood()
        {


        }

        //Constructor with 2 paramaters
        public DogFood(string brandName, double canUnitPrice)
        {
            BrandName = brandName;
            CanUnitPrice = canUnitPrice;
        }

        //Define override ToString Method

        public override string ToString()
        {
            //Insert the formatted output for displaying BrandName, CnUnitPrice, NumCans and BrandTotal
            //in string variables objectStr1,2,3 and 4.
            //Then, when each object is called in the main program, it will return this information.

            string objectStr1 = String.Format(
                "*{0,35}: {1,-41}*", "BrandName", BrandName);
            string objectStr2 = String.Format(
                "*{0,35}: {1,-41}*", "UnitPrice", CanUnitPrice.ToString("C2"));
            string objectStr3 = String.Format(
                "*{0,35}: {1,-41}*", "NumCans", NumCans);
            string objectStr4 = String.Format(
                "*{0,35}: {1,-41}*", "BrandTotal", BrandTotal.ToString("C2"));

            return objectStr1 + "\n" +
                   objectStr2 + "\n" +
                   objectStr3 + "\n" +
                   objectStr4;
        }


    }
}