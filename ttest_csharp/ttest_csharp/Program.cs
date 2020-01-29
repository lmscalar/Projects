using System;


namespace ttest_csharp
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {
                var number = "122345";
                byte b = Convert.ToByte(number);
                Console.WriteLine(b);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("The number could not be converted!");
            }

            for(int i=0; i < 10; i++)
            {
      
                Console.WriteLine(i);
            }
            

            
        }
    }
}
