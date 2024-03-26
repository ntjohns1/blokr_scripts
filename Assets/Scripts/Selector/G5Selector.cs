using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class G5Selector : Selector, ISelector
    {

        public static int Size { get { return 5; } }
        
        public override List<Vector2Int> CalculateAdjacentPositions(Vector2Int gridpoint, Direction direction, bool isFlipped)
        {
            Direction OffsetAxis(Direction offset)
            {
                return (Direction)(((int)direction + (int)offset) % 4);
            }
            List<Vector2Int> output = new()
            {
                GetNext(gridpoint,OffsetAxis(!isFlipped?Direction.Down:Direction.Up))
            };
            Direction[] refDirections =
            {
                Direction.Left,
                !isFlipped?Direction.Up:Direction.Down,
                !isFlipped?Direction.Up:Direction.Down,
                !isFlipped?Direction.Up:Direction.Down,
                !isFlipped?Direction.Up:Direction.Down,
                Direction.Right,
                Direction.Right,
                !isFlipped?Direction.Down:Direction.Up,
                !isFlipped?Direction.Down:Direction.Up,
                Direction.Right,
                Direction.Right,
                !isFlipped?Direction.Down:Direction.Up,
                !isFlipped?Direction.Down:Direction.Up,
                Direction.Left,
                Direction.Left
            };

            for (int i = 0; i < refDirections.Length; i++)
            {
                output.Add(GetNext(output[i], OffsetAxis(refDirections[i])));

            }
            return output;
        }

        public override List<Vector2Int> CalculatePlayablePositions(List<Vector2Int> adjacentPositions)
        {
            return new() {adjacentPositions[1], adjacentPositions[5], adjacentPositions[7], adjacentPositions[11], adjacentPositions[13]};
        }

        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {
            List<(Vector2Int, int)> cells = new()
            {
                (baseCell, 1)
            };
            List<Vector2Int> temp = CalculatePositions(baseCell, direction, cells);
            cells.Add((temp[1], 1));
            cells.Add(!isFlipped ? (baseCell, 0) : (baseCell, 2));
            temp = CalculatePositions(baseCell, direction, cells);
            cells.Add(!isFlipped ? (temp[3], 0) : (temp[3], 2));
            return CalculatePositions(baseCell, direction, cells);
        }
    }
}