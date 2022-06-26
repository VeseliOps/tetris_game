using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Tetris
{
    public abstract class Block //ROTATIONS 
    {
        protected abstract Position[][] Tiles { get; }
        protected abstract Position StartOffset { get; }
        public abstract int Id { get; }

        private int rotationState;
        private Position offSet;

        public Block()
        {
            offSet = new Position(StartOffset.Column, StartOffset.Row);
        }

        public IEnumerable<Position> TilesPositions()
        {
            foreach (var p in Tiles[rotationState])
            {
                yield return new Position(p.Row + offSet.Row, p.Column + offSet.Column);
            }
        }

        public void RotateForward() //ROTATE CLOCK WISE
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }
        public void RotateBackward() //COUNTER CLOCK WISE
        {
            if (rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }
        public void Move(int rows, int columns)
        {
            offSet.Row += rows;
            offSet.Column += columns;
        }


        public void Reset()
        {
            rotationState = 0;
            offSet.Row = StartOffset.Row;
            offSet.Column = StartOffset.Column;
        }
    }
}
