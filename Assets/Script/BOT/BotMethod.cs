using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMethod : MonoBehaviour
{
    public int AlphaBetaSearch(int depth, int nodeIndex, bool max, int[] values, int a, int b)
    {
        if (depth == 0)
            return values[nodeIndex];

        if (max)
        {
            int best = int.MinValue;

            for (int i = 0; i < 2; i++)
            {
                int val = AlphaBetaSearch(depth - 1, nodeIndex * 2 + i, false, values, a, b);

                best = Mathf.Max(best, val);
                a = Mathf.Max(a, best);
                if (b <= a)
                    break;
            }
            return best;
        }
        else
        {
            int best = int.MaxValue;

            for (int i = 0; i < 2; i++)
            {
                int val = AlphaBetaSearch(depth - 1, nodeIndex * 2 + i, true, values, a, b);

                best = Mathf.Min(best, val);
                b = Mathf.Min(b, best);

                if (b <= a)
                    break;
            }
            return best;
        }
    }
}
