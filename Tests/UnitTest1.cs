using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicForRecruitment;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LetterTest()
        {
            string ala = "Ala ma kota";

            string czeko = "B-ardzo lu b[iĘ czekolade.";

            LetterCounter Count1 = new LetterCounter(ala);
            Count1.Count();
            Assert.AreEqual(Count1.StringForTest(), "a-4,l-1,m-1,k-1,o-1,t-1,");

            LetterCounter Count2 = new LetterCounter(czeko);
            Count2.Count();
            Assert.AreEqual(Count2.StringForTest(), "b-2,a-2,r-1,d-2,z-2,o-2,l-2,u-1,i-1,ę-1,c-1,e-2,k-1,");

        }

        [TestMethod]
        public void FileTest()
        {
            FileEquality Instance = new FileEquality(@"E:\T1.txt", @"E:\T2.txt");
            Instance.GetDifferenses();
        }
    }
}
