using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class B5Selector : Selector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int cellA, Direction direction, bool isFlipped)
        {
            var cellB = direction switch
            {
                Direction.Up => !isFlipped ? GetNext(cellA, Direction.Left) : GetNext(cellA, Direction.Right),
                Direction.Right => !isFlipped ? GetNext(cellA, Direction.Up) : GetNext(cellA, Direction.Down),
                Direction.Down => !isFlipped ? GetNext(cellA, Direction.Right) : GetNext(cellA, Direction.Left),
                Direction.Left => ! isFlipped ? GetNext(cellA, Direction.Down) : GetNext(cellA, Direction.Up),
                _ => !isFlipped ? GetNext(cellA, Direction.Left) : GetNext(cellA, Direction.Right),
            };
            var cellC = direction switch
            {
                Direction.Up => !isFlipped ? GetNext(cellB, Direction.Left) : GetNext(cellB, Direction.Right),
                Direction.Right => !isFlipped ? GetNext(cellB, Direction.Up) : GetNext(cellB, Direction.Down),
                Direction.Down => !isFlipped ? GetNext(cellB, Direction.Right) : GetNext(cellB, Direction.Left),
                Direction.Left => ! isFlipped ? GetNext(cellB, Direction.Down) : GetNext(cellB, Direction.Up),
                _ => !isFlipped ? GetNext(cellB, Direction.Left) : GetNext(cellB, Direction.Right),
            };            
            var cellD = direction switch
            {
                Direction.Up => !isFlipped ? GetNext(cellA, Direction.Right) : GetNext(cellA, Direction.Left),
                Direction.Right => !isFlipped ? GetNext(cellA, Direction.Down) : GetNext(cellA, Direction.Up),
                Direction.Down => !isFlipped ? GetNext(cellA, Direction.Left) : GetNext(cellA, Direction.Right),
                Direction.Left => !isFlipped ? GetNext(cellA, Direction.Up) : GetNext(cellA, Direction.Down),
                _ => !isFlipped ? GetNext(cellA, Direction.Right) : GetNext(cellA, Direction.Left),
            };
            var cellE = direction switch
            {
                Direction.Up => GetNext(cellD, Direction.Down),
                Direction.Right => GetNext(cellD, Direction.Left),
                Direction.Down => GetNext(cellD, Direction.Up),
                Direction.Left => GetNext(cellD, Direction.Right),
                _ => GetNext(cellD, Direction.Down),
            };
            List<Vector2Int> cells = new()
        {
            cellA,
            cellB,
            cellC,
            cellD,
            cellE
        };
            return cells;
        }
    }
}
