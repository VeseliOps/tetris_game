using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameState
    {
        private Block currentBlock;

        public Block CurrentBlock
        {
            get => currentBlock; private set
            {
                currentBlock = value; currentBlock.Reset(); for (int i = 0; i < 2; i++)
                {
                    currentBlock.Move(1, 0);
                    if (!BlockFits())
                    {
                        currentBlock.Move(-1, 0);
                    }
                }
            }
        }


        public GameGrid GameGrid { get; }
        public BlockQueue BlockQueue { get; }
        public bool GameOver { get; private set; }
        public int Score { get; private set; }

        public GameState()
        {
            GameGrid = new GameGrid(22, 10);
            BlockQueue = new BlockQueue();
            CurrentBlock = BlockQueue.GetAndUpdate();
        }

        private bool BlockFits()
        {
            foreach (var p in CurrentBlock.TilesPositions())
            {
                if (!GameGrid.IsEmpty(p.Row, p.Column))
                {
                    return false;
                }
            }
            return true;
        }

        public void RotateblockCW()
        {
            CurrentBlock.RotateForward();
            if (!BlockFits())
            {
                CurrentBlock.RotateBackward();
            }
        }

        public void RotateblockCCW()
        {
            CurrentBlock.RotateBackward();
            if (!BlockFits())
            {
                CurrentBlock.RotateForward();
            }
        }

        public void MoveBlockLeft()
        {
            CurrentBlock.Move(0, -1);

            if (!BlockFits())
            {
                CurrentBlock.Move(0, 1);
            }
        }
        public void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);

            if (!BlockFits())
            {
                CurrentBlock.Move(0, -1);
            }
        }

        public bool IsGameOver()
        {
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
        }
        public void PlaceBlock()
        {
            foreach (var p in CurrentBlock.TilesPositions())
            {
                GameGrid[p.Row, p.Column] = CurrentBlock.Id;
            }
            Score += GameGrid.ClearFullRows();

            if (IsGameOver())
            {
                GameOver = true;
            }
            else
            {
                CurrentBlock = BlockQueue.GetAndUpdate();
            }
        }

        public void MoveBlockDown()
        {
            CurrentBlock.Move(1, 0);
            if (!BlockFits())
            {
                CurrentBlock.Move(-1, 0);
                PlaceBlock();
            }
        }
      
    }
}
