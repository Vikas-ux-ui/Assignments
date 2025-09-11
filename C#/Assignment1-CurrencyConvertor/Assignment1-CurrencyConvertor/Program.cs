//Courency Covertor {   USD, CAD, Euro, GBP To INR  }

Console.Write("Enter the amount (INR)");
var inr = Console.ReadLine();//Reading INR amount 

double INRamount = double.Parse(inr);//Parsing string to double

Console.WriteLine("INR in USD"+INRamount * 88.22);//calculating USD
Console.WriteLine("INR in Euro" + INRamount * 103.28);//Calculating INR in Euro
Console.WriteLine("INR in CAD" + INRamount * 63.65);//Calculating INR in CAD
Console.WriteLine("INR in GBP" + INRamount * 119.36);//Calculating INR in GBP


 


