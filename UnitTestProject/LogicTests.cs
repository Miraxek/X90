using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToePlusGame.GameLogic;

namespace UnitTestProject
{
    [TestClass]
    public class LogicTests
    {
        public TicTacToeLogic logic;

        [TestMethod]
        public void Test_MakeMove_simpleMove_currectResult()
        {
            logic = new TicTacToeLogic();
            logic.MakeMove(0, 0, 0, 0, 1);
            Assert.AreEqual(1, logic.GetInsideCell(0, 0, 0, 0));
            Assert.AreEqual(0, logic.GetOutsideCell(0, 0));
        }

        [TestMethod]
        public void Test_MakeMove_oneFullOutsideCell_currectResult()
        {
            logic = new TicTacToeLogic();
            MakeFullOutsideCell(0, 0);
            Assert.IsTrue(logic.GetOutsideCell(0, 0) > 2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
        "Can't move")]
        public void Test_MakeMove_makeSameMoveTwice_ThrowsExeption()
        {
            logic = new TicTacToeLogic();
            logic.MakeMove(0, 0, 0, 0, 1);
            logic.MakeMove(0, 0, 0, 0, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
        "Can't move")]
        public void Test_MakeMove_makeMoveInFinishedCell_ThrowsExection()
        {
            logic = new TicTacToeLogic();
            MakeTeamWonInOneCellDiag(0, 0, 1);
            logic.MakeMove(0, 0, 1, 2, 2);
        }

        [TestMethod]
        public void Test_MakeMove_WonInOneCellDiag_CurrectResult()
        {
            logic = new TicTacToeLogic();
            MakeTeamWonInOneCellDiag(0, 0, 1);
            Assert.AreEqual(1, logic.GetOutsideCell(0, 0));
        }

        [TestMethod]
        public void Test_MakeMove_WonInOneCellRows_CurrectResult()
        {
            for (int i = 0; i < 3; i++)
            {
                logic = new TicTacToeLogic();
                MakeTeamWonInOneCellRow(0, 0, 1, i);
                Assert.AreEqual(1, logic.GetOutsideCell(0, 0));
            }            
        }

        [TestMethod]
        public void Test_MakeMove_WonInOneCellColumn_CurrectResult()
        {
            for (int i = 0; i < 3; i++)
            {
                logic = new TicTacToeLogic();
                MakeTeamWonInOneCellColumn(0, 0, 1, i);
                Assert.AreEqual(1, logic.GetOutsideCell(0, 0));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
        "Unknown team")]
        public void Test_MakeMove_makeMoveWrongTeam_ThrowsExection()
        {
            logic = new TicTacToeLogic();
            logic.MakeMove(0, 0, 1, 2, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test_MakeMove_makeMoveWrongInsideIndex_ThrowsExection()
        {
            logic = new TicTacToeLogic();
            logic.MakeMove(0, 0, 3, 2, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test_MakeMove_makeMoveWrongOutSideIndex_ThrowsExection()
        {
            logic = new TicTacToeLogic();
            logic.MakeMove(0, 3, 2, 2, 1);
        }

        [TestMethod]
        public void Test_IsFull_NotFull1_CurrectResult()
        {
            logic = new TicTacToeLogic();
            Assert.IsFalse(logic.IsFull());
        }

        [TestMethod]
        public void Test_IsFull_NotFull2_CurrectResult()
        {
            logic = new TicTacToeLogic();
            MakeFullOutsideCell(0, 0);
            MakeFullOutsideCell(1, 1);
            MakeFullOutsideCell(2, 2);
            Assert.IsFalse(logic.IsFull());
        }

        [TestMethod]
        public void Test_IsFull_NotFull3_CurrectResult()
        {
            logic = new TicTacToeLogic();
            MakeFullOutsideCell(0, 0);
            MakeFullOutsideCell(1, 1);
            MakeFullOutsideCell(2, 2);
            MakeTeamWonInOneCellDiag(0, 1, 1);
            MakeTeamWonInOneCellDiag(0, 2, 1);
            MakeTeamWonInOneCellDiag(1, 2, 2);
            MakeTeamWonInOneCellDiag(1, 0, 2);
            MakeTeamWonInOneCellDiag(2, 0, 1);
            Assert.IsFalse(logic.IsFull());
        }

        [TestMethod]
        public void Test_IsFull_Full1_CurrectResult()
        {
            logic = new TicTacToeLogic();
            MakeFullOutsideCell(0, 0);
            MakeFullOutsideCell(1, 1);
            MakeFullOutsideCell(2, 2);
            MakeTeamWonInOneCellDiag(0, 1, 1);
            MakeTeamWonInOneCellDiag(0, 2, 1);
            MakeTeamWonInOneCellDiag(1, 2, 2);
            MakeTeamWonInOneCellDiag(1, 0, 2);
            MakeTeamWonInOneCellDiag(2, 0, 1);
            MakeTeamWonInOneCellDiag(2, 1, 1);
            Assert.IsTrue(logic.IsFull());
        }

        [TestMethod]
        public void Test_IsWon_Won1_CurrectResult()
        {
            logic = new TicTacToeLogic();
            MakeTeamWonInOneCellDiag(0, 1, 1);
            MakeTeamWonInOneCellDiag(0, 2, 1);
            MakeTeamWonInOneCellDiag(0, 0, 1);
            Assert.IsTrue(logic.IsWon(1));
        }

        [TestMethod]
        public void Test_IsWon_Won2_CurrectResult()
        {
            logic = new TicTacToeLogic();
            MakeTeamWonInOneCellDiag(1, 1, 2);
            MakeTeamWonInOneCellDiag(2, 2, 2);
            MakeTeamWonInOneCellDiag(0, 0, 2);
            Assert.IsTrue(logic.IsWon(2));
        }

        [TestMethod]
        public void Test_IsWon_NoWon1_CurrectResult()
        {
            logic = new TicTacToeLogic();
            MakeTeamWonInOneCellDiag(0, 1, 1);
            MakeTeamWonInOneCellDiag(0, 2, 1);
            MakeTeamWonInOneCellDiag(0, 0, 1);
            Assert.IsFalse(logic.IsWon(2));
        }


        [TestMethod]
        public void Test_IsDraw_Draw1_CurrectResult()
        {
            logic = new TicTacToeLogic();
            MakeFullOutsideCell(0, 0);
            MakeFullOutsideCell(1, 1);
            MakeFullOutsideCell(2, 2);
            MakeTeamWonInOneCellDiag(0, 1, 1);
            MakeTeamWonInOneCellDiag(0, 2, 1);
            MakeTeamWonInOneCellDiag(1, 2, 2);
            MakeTeamWonInOneCellDiag(1, 0, 2);
            MakeTeamWonInOneCellDiag(2, 0, 1);
            MakeTeamWonInOneCellDiag(2, 1, 1);
            Assert.IsTrue(logic.IsDraw());
        }

        [TestMethod]
        public void Test_IsDraw_NoDraw1_CurrectResult()
        {
            logic = new TicTacToeLogic();
            MakeTeamWonInOneCellDiag(0, 1, 1);
            MakeTeamWonInOneCellDiag(0, 2, 1);
            MakeTeamWonInOneCellDiag(0, 0, 1);
            Assert.IsFalse(logic.IsDraw());
        }


        [TestMethod]
        public void Test_IsDraw_NoDraw2_CurrectResult()
        {
            logic = new TicTacToeLogic();
            MakeFullOutsideCell(0, 0);
            MakeFullOutsideCell(1, 1);
            MakeFullOutsideCell(2, 2);
            MakeTeamWonInOneCellDiag(0, 1, 1);
            MakeTeamWonInOneCellDiag(0, 2, 1);
            MakeTeamWonInOneCellDiag(1, 2, 2);
            MakeTeamWonInOneCellDiag(1, 0, 2);
            MakeTeamWonInOneCellDiag(2, 0, 1);
            Assert.IsFalse(logic.IsDraw());
        }
        void MakeFullOutsideCell(int i, int j)
        {
            logic.MakeMove(i, j, 0, 0, 1);
            logic.MakeMove(i, j, 0, 1, 2);
            logic.MakeMove(i, j, 0, 2, 1);
            logic.MakeMove(i, j, 1, 0, 1);
            logic.MakeMove(i, j, 2, 0, 2);
            logic.MakeMove(i, j, 1, 1, 2);
            logic.MakeMove(i, j, 1, 2, 1);
            logic.MakeMove(i, j, 2, 2, 2);
            logic.MakeMove(i, j, 2, 1, 1);
        }

        void MakeTeamWonInOneCellDiag(int i, int j, int team)
        {
            logic.MakeMove(i, j, 0, 0, team);
            logic.MakeMove(i, j, 1, 1, team);
            logic.MakeMove(i, j, 2, 2, team);
        }

        void MakeTeamWonInOneCellRow(int i, int j, int team, int row)
        {
            logic.MakeMove(i, j, row, 0, team);
            logic.MakeMove(i, j, row, 1, team);
            logic.MakeMove(i, j, row, 2, team);
        }

        void MakeTeamWonInOneCellColumn(int i, int j, int team, int column)
        {
            logic.MakeMove(i, j, 0, column, team);
            logic.MakeMove(i, j, 1, column, team);
            logic.MakeMove(i, j, 2, column, team);
        }
    }
}
