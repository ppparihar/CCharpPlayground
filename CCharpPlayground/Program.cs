//using System;
//using System.Threading.Tasks;

//namespace CCharpPlayground
//{
//    class Program
//    {
//        static int COUNTER = 0;
//        static async Task Main(string[] args)
//        {
//            var maxthread = 30;
//            var totalRecord = 1000;
//            await ParallelTask.SemaphoreSlimTask(maxthread, totalRecord);
//            await ParallelTask.ParallelForEach(maxthread, totalRecord);
//            Console.ReadLine();
//        }
//    }
//}
