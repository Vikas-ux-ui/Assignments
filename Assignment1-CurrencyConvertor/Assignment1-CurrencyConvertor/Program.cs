//Courency Covertor {   INR To USD, CAD, Euro, GBP  }

Console.Write("Enter the amount (INR) ");
var inr = Console.ReadLine();//Reading INR amount 

double INRamount = double.Parse(inr);//Parsing string to double

if (INRamount >0)
{
    Console.WriteLine("INR in USD " + Math.Round(INRamount / 88.22, 2));//calculating INR in USD
    Console.WriteLine("INR in Euro " + Math.Round(INRamount / 103.28,2));//Calculating INR in Euro
    Console.WriteLine("INR in CAD " + Math.Round(INRamount / 63.65,2));//Calculating INR in CAD
    Console.WriteLine("INR in GBP " + Math.Round(INRamount / 119.36,3));//Calculating INR in GBP
}
else
{
    Console.WriteLine("Amount is negative");//if amount is negative
}


 


