using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoDatDictionaries.Hash;

using AlgoDatDictionaries.Hash;
namespace Tests.Hash
{
    [TestClass]

    public class HashTabQuadProbTest
    {

        HashTabQuadProb a = new HashTabQuadProb();

        [TestMethod]
        public void InsertTest()
        {
            Assert.IsTrue(a.Insert(76));
            Assert.IsTrue(a.Insert(40));
            Assert.IsTrue(a.Insert(48));
            Assert.IsTrue(a.Insert(5));
            Assert.IsTrue(a.Insert(20));
            a.Print();
            
        }
        

        //    Console.WriteLine(a.Insert(76));
        //    Console.WriteLine(a.Insert(40));
        //    Console.WriteLine(a.Insert(48));
        //    Console.WriteLine(a.Insert(5));
        //    Console.WriteLine(a.Insert(20));

        //    a.Print();
        //    Console.WriteLine();

        //    Console.WriteLine(a.Delete(76));
        //    Console.WriteLine(a.Delete(100));

        //    a.Print();
        //    Console.WriteLine();

        //    Console.WriteLine(a.Search(76));
        //    Console.WriteLine(a.Search(40));
        //    Console.WriteLine(a.Search(48));
        //    Console.WriteLine(a.Search(5));
        //    Console.WriteLine(a.Search(20));
        //    Console.WriteLine(a.Search(2));

        //    Console.WriteLine(a.Insert(8));
        //    Console.WriteLine(a.Insert(11));
        //    Console.WriteLine(a.Insert(76));

        //    a.Print();
        //    Console.WriteLine();

        //    Console.WriteLine(a.Insert(23));
        //    a.Print();


        //    Console.WriteLine();



    }
}

