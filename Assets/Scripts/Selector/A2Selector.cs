using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class A2Selector : Selector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {
            List<(Vector2Int, int)> cells = new() { !isFlipped ? (baseCell, 1) : (baseCell, 3) };
            return CalculatePositions(baseCell, direction, cells);
        }
    }
}