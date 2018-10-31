using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Enigma.Cellular_Automata.Game_of_Life;

namespace Algorithm_Tester.Cellular_Automata
{
    /// <summary>
    /// Descrizione del riepilogo per GameOfLifeUnitTest
    /// </summary>
    [TestClass]
    public class GameOfLifeUnitTest
    {
        #region Attributi di test aggiuntivi
        //
        // È possibile utilizzare i seguenti attributi aggiuntivi per la scrittura dei test:
        //
        // Utilizzare ClassInitialize per eseguire il codice prima di eseguire il primo test della classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilizzare ClassCleanup per eseguire il codice dopo l'esecuzione di tutti i test della classe
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilizzare TestInitialize per eseguire il codice prima di eseguire ciascun test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilizzare TestCleanup per eseguire il codice dopo l'esecuzione di ciascun test
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: aggiungere qui la logica del test
            //
            GameOfLifeAlgorithm algorithm = new GameOfLifeAlgorithm();

            algorithm.AddCell(
                new Cell(5,5), 
                new Cell(6,5), 
                new Cell(5,6), 
                new Cell(6,6));

            algorithm.Run();
            Assert.IsTrue(true);
        }
    }
}
