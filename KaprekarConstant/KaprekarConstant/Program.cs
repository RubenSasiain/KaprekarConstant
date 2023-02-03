using System;

namespace KaprekarConstant
{
    class Program
    {
        static void Main(string[] args)
        {
            char repeat = 'y';
            string intext = null;
            do
            {
                MainProcess();
                
                do
                {
                    Console.WriteLine("Repeat? y/n");
                    intext = Console.ReadLine();
                    
                } while (intext == null || intext.Trim() == "");

                repeat = intext.ToLower()[0];
                
                Console.Clear();
                
            } while (repeat == 'y');
            GC.Collect();
        }

        private static void MainProcess()
        {
            bool error;
            string count = "0 times";
            do
            {
                error = false;
                string number;
                do
                {
                    Console.WriteLine("Insert a 4 digits number: ");
                    number =  Console.ReadLine();
                } while (number != null && number.Trim().Length != 4);


                try
                {
                    if (number != null)
                    {
                        count = Operation(Int32.Parse(number));
                    }
                    else error = true;
                }
                catch (Exception e)
                {
                    error = true;
                } 
            } while (error == true);
            
            Console.WriteLine(count);

        }
        
        public static string Operation(int number)
        {
            string ret = null;
            int count = 0;
            do
            {
                count++;
                int maxMin = OrderMaxToMin(number);
                int minMax = OrderMinToMax(number);
                Console.WriteLine("number =  " +number);
                number = maxMin - minMax;
                Console.WriteLine("\n \n " + maxMin + "\n-"+ minMax + "\n ====\n "+number);
            } while (number != 6174);

            ret = count + " times to get 6174";
            
            return ret;
        }

        private static int OrderMaxToMin(int number)
        {
            string ordenatedNumber = number.ToString();

            char[] digits = ordenatedNumber.ToCharArray();
            
            Array.Sort(digits);
            
            Array.Reverse(digits);

            int returnNumber = Int32.Parse(new string(digits));
            
            return returnNumber;
        }
        
        private static int OrderMinToMax(int number)
        {
            string ordenatedNumber = number.ToString();

            char[] digits = ordenatedNumber.ToCharArray();
            
            Array.Sort(digits);

            int returnNumber = Int32.Parse(new string(digits));
            
            return returnNumber;
        }
    }
}