using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddEvenJumpCsharp
{
    internal class Solution
    {
        private int[] nums;
        private int numsLen;
        private int current;

        private Dictionary<int, bool> oddJumps = new();
        private Dictionary<int, bool> evenJumps = new();

        private int OddNewI(int i)
        {
            int iNum = nums[i];
            int newI = -1;
            int newINum = 0;
            int jNum;

            ++i;
            while (i < numsLen)
            {
                jNum = nums[i];
                if (iNum <= jNum)
                {
                    newI = i;
                    newINum = jNum;
                    ++i;
                    break;
                }
                ++i;
            }

            while (i < numsLen)
            {
                jNum = nums[i];
                if (iNum <= jNum && jNum < newINum)
                {
                    newI = i;
                    newINum = jNum;
                }
                ++i;
            }

            return newI;
        }

        private int EvenNewI(int i)
        {
            int iNum = nums[i];
            int newI = -1;
            int newINum = 0;
            int jNum;

            ++i;
            while (i < numsLen)
            {
                jNum = nums[i];
                if (iNum >= jNum)
                {
                    newI = i;
                    newINum = jNum;
                    ++i;
                    break;
                }
                ++i;
            }

            while (i < numsLen)
            {
                jNum = nums[i];
                if (iNum >= jNum && jNum > newINum)
                {
                    newI = i;
                    newINum = jNum;
                }
                ++i;
            }

            return newI;
        }

        private bool Jump(int i, bool isOdd)
        {
            if (i == -1) return false;
            if (i == numsLen - 1) return true;

            bool next;
            bool jump;

            if (isOdd)
            {
                if (oddJumps.TryGetValue(i, out jump)) return jump;
                next = Jump(OddNewI(i), false);
                if (current != i) oddJumps.Add(i, next);
                //oddJumps.Add(i, next);
            }
            else
            {
                if (evenJumps.TryGetValue(i, out jump)) return jump;
                next = Jump(EvenNewI(i), true);
                if (current != i) evenJumps.Add(i, next);
                //evenJumps.Add(i, next);
            }

            return next;
        }

        public int OddEvenJumps(int[] arr)
        {
            nums = arr;
            numsLen = arr.Length;

            int count = 1;
            current = 0;

            while (current < numsLen - 1)
            {
                // jumps 15366
                // was 1628
                if (Jump(current, true)) ++count;
                ++current;
            }
            return count;
        }
    }
}
