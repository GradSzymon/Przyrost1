using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjektPP1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPP1.Tests
{
    [TestClass()]
    public class KlasaTestowaTests
    {
        [TestMethod()]
        public void DodajDoListyTest()
        {
            
        }

        [TestMethod()]
        public void SprawdZapytanieTest()
        {
            string numerkomendydobrej = "2";
            string numerkomendyzlej = "r";
            string komendaDobra = "SELECT FROM WHERE ORDER BY";
            string komendaDobraCzesciowo = "SELECT FROM";
            string komendaZla = "FROM SELECT";
           
            KlasaTestowa klasa = new KlasaTestowa();
            Assert.AreEqual(true,klasa.SprawdZapytanie(numerkomendydobrej,komendaDobra));
            Assert.AreEqual(true, klasa.SprawdZapytanie(numerkomendydobrej, komendaDobraCzesciowo));
            Assert.AreEqual(false, klasa.SprawdZapytanie(numerkomendydobrej, komendaZla));
            Assert.AreEqual(false, klasa.SprawdZapytanie(numerkomendyzlej, komendaDobra));
        }
    }
}
