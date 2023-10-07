using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCharpPlayground
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using CCharpPlayground.Hashing;

    class Program
    {
        static void Main(string[] args)
        {
            PasswordHashing.Run();

            Console.ReadKey();
        }

    }

}
