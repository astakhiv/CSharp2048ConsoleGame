namespace ConsoleGame2048
{

    public class Grid
    {
        private readonly int[][] _grid = new int[][]
        {
            new[] {0, 0, 0, 0},
            new[] {0, 0, 0, 0},
            new[] {0, 0, 0, 0},
            new[] {0, 0, 0, 0}
        };
        private readonly int[] _randomNums = new[] { 2, 4 };
        private int _nullsToAdd;
        private void SetNewRandomNumber()
        {
            var random = new Random();
            var randomNum = _randomNums[random.Next(0, 2)];
            while (true)
            {
                var randomX = random.Next(0, 4);
                var randomY = random.Next(0, 4);
                if (_grid[randomX][randomY] == 0)
                {
                    _grid[randomX][randomY] = randomNum;
                    break;
                }
            }
        }

        private int[] SumByFalling(int[] allNums)
        {
            for (int j = allNums.Length - 1; j >= 0; j--)
            {
                if (j > 0 && allNums[j] == allNums[j - 1])
                {
                    allNums[j] *= 2;
                    allNums[j - 1] = 0;
                }
            }

            return allNums;
        }

        private int[] SumByRising(int[] allNums)
        {
            for (int j = 0; j < allNums.Length; j++)
            {
                if (j < allNums.Length - 1 && allNums[j] == allNums[j + 1])
                {
                    allNums[j] *= 2;
                    allNums[j + 1] = 0;
                }
            }

            return allNums;
        }

        public void CreateGrid()
        {
            SetNewRandomNumber();
            SetNewRandomNumber();
        }

        public string ReturnGrid()
        {
            var grid = "";
            var maxValues = new List<int>();
            foreach (var item in _grid)
            {
                maxValues.Add(item.Max());
            }
            for (var i = 0; i < 4; i++)
            {
                grid = grid + "\n";
                for (var j = 0; j < 4; j++)
                {
                    grid = grid + "|";
                    var whiteSpacesToAdd = maxValues.Max().ToString().Length - _grid[i][j].ToString().Length;
                    for (int k = 0; k < whiteSpacesToAdd; k++)
                    {
                        grid = grid + " ";
                    }
                    grid = grid + _grid[i][j];
                }
                grid = grid + "|" + "\n";
            }

            return grid;
        }

        private int[] MoveCharacters(int[] arrayToMove, string upOrDown, int iteratorNumber, int maxLoopNumber)
        {
          var allNums = arrayToMove.Where(x => x != 0).ToArray(); 
          allNums = upOrDown == "Up" ? SumByRising(allNums) : SumByFalling(allNums); 
          allNums = allNums.Where(x => x != 0).ToArray(); 
          var result = new int[4]; 
          _nullsToAdd = arrayToMove.Length - allNums.Length;
          
          if (_nullsToAdd < 4) 
          { 
              var index = 0; 
              for (var j = iteratorNumber == -1 ? _nullsToAdd : iteratorNumber; 
                   j < (maxLoopNumber == -1 ? allNums.Length : maxLoopNumber); 
                   j++)
              { 
                  result[j] = allNums[index]; 
                  index++;
              }
          }

          return result; 
        }

        public void MoveCharactersToRight()
        {
            for (int i = 0; i < 4; i++) _grid[i] = MoveCharacters(_grid[i], "Down", -1, 4);
            SetNewRandomNumber();
        }

        public void MoveCharactersToLeft()
        {
            for (int i = 0; i < 4; i++)  _grid[i] = MoveCharacters(_grid[i], "Up", 0, -1);
            SetNewRandomNumber();
        }
        public void MoveCharactersToUpAndDown(string upOrDown)
        {
            for (int i = 0; i < _grid.Length; i++)
            {
                List<int> allNums = new List<int>();
                for (int j = 0; j < 4; j++) allNums.Add(_grid[j][i]);
                
                int[] result = upOrDown.ToLower() == "up" ? 
                    MoveCharacters(allNums.ToArray(), "Up", 0, -1) : 
                    MoveCharacters(allNums.ToArray(), "Down", -1, 4);
                
                for (var j = 0; j < 4; j++) _grid[j][i] = result[j];
            }
            SetNewRandomNumber();
        }
    }
}