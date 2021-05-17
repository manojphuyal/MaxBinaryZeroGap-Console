using System;

namespace TestQuestion_InfCom
{
    public class MaxBinaryGap
    {
        string result = "";
        string state="start";
        int maxZero= 0;
        int countZero = 0;
        int countOne = 0;
        public string DecimalToBinary(int deci)
        {
            if (deci < 0)
            {
                Console.WriteLine("Negative number not allowed.");
                return "0";
            }
            else if (deci == 0)
            {
                Console.WriteLine("0 doesn't contain a binary gap.");
                return "0";
            }
            else if(deci>0 ||deci<9999999)
            {
                int num = Convert.ToInt32(deci);

                while (num > 1)
                {
                    int remainder = num % 2;
                    result = remainder.ToString() + result;
                    num /= 2;
                }
                result = num + result;
                return result.ToString();
            }
            else
            {
                Console.WriteLine("Only decimal number allowed or Limit exceed.");
                return "0";
            }
        }

        public long maxZeros(long max)
        {                                          
            int length = max.ToString().Length;
            for (int i = 0; length > i; i++)
            { 
                long rem = max % 10;
                max = max / 10;
                if (rem == 1)
                {
                    if (state == "start" || state == "one")
                    {
                        countOne =  1;                                 
                    }
                    if (state=="zero")
                    {
                        countOne = 1;
                        countZero = 0;
                    }
                    state = "one";
                }
                if (rem == 0 )
                {
                    if (state == "start" || state == "one")
                    {
                        countZero = countZero + 1;
                        if (state == "start")
                        {
                            countZero = 0;
                        }
                        if (countZero> maxZero)
                        {
                            maxZero = countZero;
                        }
                    }
                    if (state == "zero" && countOne==1)
                    {
                        countZero = countZero + 1;
                        maxZero = countZero;
                    }
                    state = "zero";
                }
            }                               
            return maxZero;
        }
        public static void Main(string[] args)                  
        {
            Console.WriteLine("Please enter decimal number.");
            string deci = Console.ReadLine();
            MaxBinaryGap maxBinaryGap = new MaxBinaryGap();
            var binaryData = maxBinaryGap.DecimalToBinary(Convert.ToInt32(deci));
            var data = maxBinaryGap.maxZeros(Convert.ToInt64(binaryData));
            Console.WriteLine("The binary no of " + deci + " is: " + binaryData + " having max consutive 0's number is " + data);
        }
    }
}
