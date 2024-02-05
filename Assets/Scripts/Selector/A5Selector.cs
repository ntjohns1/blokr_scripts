using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class A5Selector : Selector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int cellA, Direction direction, bool isFlipped)
        {

            var cellB = direction switch
            {
                Direction.Up => !isFlipped ? GetNext(cellA, Direction.Right) : GetNext(cellA, Direction.Left),
                Direction.Right => !isFlipped ? GetNext(cellA, Direction.Down): GetNext(cellA, Direction.Up),
                Direction.Down => !isFlipped ? GetNext(cellA, Direction.Left) : GetNext(cellA, Direction.Right),
                Direction.Left => !isFlipped ? GetNext(cellA, Direction.Up) : GetNext(cellA, Direction.Down),
                _ => !isFlipped ? GetNext(cellA, Direction.Right) : GetNext(cellA, Direction.Left),
            };
            var cellC = direction switch
            {
                Direction.Up => !isFlipped ? GetNext(cellA, Direction.Left) : GetNext(cellA, Direction.Right),
                Direction.Right => !isFlipped ? GetNext(cellA, Direction.Up) : GetNext(cellA, Direction.Down),
                Direction.Down => !isFlipped ? GetNext(cellA, Direction.Right) : GetNext(cellA, Direction.Left),
                Direction.Left => !isFlipped ? GetNext(cellA, Direction.Down) : GetNext(cellA, Direction.Up),
                _ => !isFlipped ? GetNext(cellA, Direction.Left) : GetNext(cellA, Direction.Right),
            };            
            var cellD = direction switch
            {
               Direction.Up => !isFlipped ? GetNext(cellB, Direction.Right) : GetNext(cellB, Direction.Left),
                Direction.Right => !isFlipped ? GetNext(cellB, Direction.Down): GetNext(cellB, Direction.Up),
                Direction.Down => !isFlipped ? GetNext(cellB, Direction.Left) : GetNext(cellB, Direction.Right),
                Direction.Left => !isFlipped ? GetNext(cellB, Direction.Up) : GetNext(cellB, Direction.Down),
                _ => !isFlipped ? GetNext(cellB, Direction.Right) : GetNext(cellB, Direction.Left),
            };
            var cellE = direction switch
            {
                Direction.Up => !isFlipped ? GetNext(cellC, Direction.Left) : GetNext(cellC, Direction.Right),
                Direction.Right => !isFlipped ? GetNext(cellC, Direction.Up) : GetNext(cellC, Direction.Down),
                Direction.Down => !isFlipped ? GetNext(cellC, Direction.Right) : GetNext(cellC, Direction.Left),
                Direction.Left => !isFlipped ? GetNext(cellC, Direction.Down) : GetNext(cellC, Direction.Up),
                _ => !isFlipped ? GetNext(cellC, Direction.Left) : GetNext(cellC, Direction.Right),
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