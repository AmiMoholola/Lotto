using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace myApp
{
    [TestClass]
    public class UnitTestDivision3
    {
        [TestMethod]
        public void TestWinnerDivision3()
        {
            //MATCH 5 --- WINNER Division 3
            var lotto = new lottonumbers();
            lotto.AddGame("SA Lotto","2018-06-07");
            lotto.capture_draw(29, 15, 22, 41, 19, 4, 17);
            var results = lotto.LottoGame(3, 15, 19, 22, 29, 41);
            Assert.AreEqual(results, "MATCH 5 --- WINNER Division 3");  
        }

    }
    [TestClass]
    public class UnitTestDivision2
    {
        [TestMethod]
        public void TestWinnerDivision2()
        {
            //MATCH 5 + BONUS --- WINNER Division 2
            var lotto = new lottonumbers();
            lotto.AddGame("SA Lotto","2018-06-07");
            lotto.capture_draw(29, 15, 22, 41, 19, 4, 17);
            var results = lotto.LottoGame(17,15,19,22,29,41);
            Assert.AreEqual(results, "MATCH 5 + BONUS --- WINNER Division 2");
        }
    }


    [TestClass]
    public class Unitjackpotwinner
    {
        [TestMethod]
        public void TestWinnerDivision1()
        {
            //MATCH 6 --- WINNER Division 1
            var lotto = new lottonumbers();
            lotto.AddGame("SA Lotto","2018-06-07");
            lotto.capture_draw(29, 15, 22, 41, 19, 4, 17);
            var results = lotto.LottoGame(4,15,19,22,29,41);
            Assert.AreEqual(results, "MATCH 6 --- WINNER Division 1");
        }
    }
    

    [TestClass]
    public class UnitTestLosser
    {
        [TestMethod]
        public void TestLosser()
        {
            //NOT A WINNER 
            var lotto = new lottonumbers();
            lotto.AddGame("SA Lotto","2018-06-07");
            lotto.capture_draw(29, 15, 22, 41, 19, 4, 17);
            var results = lotto.LottoGame(9,16,20,30,29,41);
            Assert.AreEqual(results, "NOT A WINNER");    
        }
    }

    [TestClass]
    public class UnitTestError1
    {
        [TestMethod]
        public void TestError1()
        {
            //Error Numbers must be between 1 and 52 inclusive 
            var lotto = new lottonumbers();
            lotto.AddGame("SA Lotto","2018-06-07");
            lotto.capture_draw(29, 15, 22, 41, 19, 4, 17);
            var results = lotto.LottoGame(9, 16, 20, 30, 29, 60);
            Assert.AreEqual(results, "Error Numbers must be between 1 and 52 inclusive");             
        }
    }

    [TestClass]
    public class UnitTestError2
    {
        [TestMethod]
        public void TestError2()
        {
            //Error Numbers in your set must not be duplicated  
            var lotto = new lottonumbers();
            lotto.AddGame("SA Lotto","2018-06-07");
            lotto.capture_draw(29, 15, 22, 41, 19, 4, 17);
            var results = lotto.LottoGame(9, 15, 41, 17, 29, 29);
            Assert.AreEqual(results, "Error Numbers in your set must not be duplicated");
             
        }
    }

    [TestClass]
    public class UnitTestError3
    {
        [TestMethod]
        public void TestError3()
        {
            //Error Winning numbers not provided  
            var lotto = new lottonumbers();
            lotto.AddGame("SA Lotto","2018-06-07");
            var results = lotto.LottoGame(3, 15, 19, 22, 29, 41);
            Assert.AreEqual(results, "Error Winning numbers not provided");
        }
    }
}
