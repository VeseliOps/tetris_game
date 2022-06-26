using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class BlockQueue
    {
        private readonly Block[] blocks = new Block[] {

            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock()

        };

        private readonly Random rand = new Random();
        public Block NextBlock { get; private set; } //PREVIEW THIS BLOCK THAT PLAYER KNOWS WHATS COMING

        public BlockQueue()
        {
            NextBlock = RandomBlock();
        }
        private Block RandomBlock()
        {
            return blocks[rand.Next(blocks.Length)];
        }

        public Block GetAndUpdate()
        {
            Block block = NextBlock;

            do
            {
                NextBlock = RandomBlock();
            }
            while (block.Id == NextBlock.Id);
            return block;
        }


    }
}
