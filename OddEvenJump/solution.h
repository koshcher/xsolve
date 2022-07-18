#pragma once

#include <vector>
#include <map>

// All functions are inline to speed up
class Solution
{
private:
    std::vector<int> nums;
    int nums_len;
    int current;
    std::map<int, bool> odd_jumps;
    std::map<int, bool> even_jumps;

private:
    inline int oddNewI(const int& i)
    {
        int inum = nums[i];
        int new_i = -1;
        int jnum;

        int j = i + 1;
        while (j < nums_len)
        {
            if (inum <= nums[j]) {
                new_i = j;
                break;
            }
            ++j;
        }

        while (j < nums_len)
        {
            jnum = nums[j];
            if (inum <= jnum && jnum < nums[new_i])
            {
                new_i = j;
            }
            ++j;
        }

        return new_i;
    }

    inline int evenNewI(const int& i)
    {
        int inum = nums[i];
        int new_i = -1;

        int j = i + 1;
        while (j < nums_len)
        {
            if (inum >= nums[j]) {
                new_i = j;
                break;
            }
            ++j;
        }

        while (j < nums_len)
        {
            int jnum = nums[j];
            if (inum >= jnum && jnum > nums[new_i])
            {
                new_i = j;
            }
            ++j;
        }

        return new_i;
    }

    inline bool jump(const int& i, const bool& isOdd)
    {
        if (i == -1) return false;
        if (i == nums_len - 1) return true;

        bool next_jump;
        std::map<int, bool>::const_iterator jump_num;

        if (isOdd)
        {
            jump_num = odd_jumps.find(i);
            if (jump_num != odd_jumps.end()) return jump_num->second;

            next_jump = jump(oddNewI(i), false);
            if (current != i) odd_jumps.insert(std::pair<int, bool> {i, next_jump});
        }
        else
        {
            jump_num = even_jumps.find(i);
            if (jump_num != even_jumps.end()) return jump_num->second;

            next_jump = jump(evenNewI(i), true);
            if (current != i) even_jumps.insert(std::pair<int, bool> {i, next_jump});
        }
        return next_jump;
    }

public:

    // was 3169713
    inline int oddEvenJumps(std::vector<int>& arr)
    {
        nums = arr;
        nums_len = arr.size();

        int count = 1;
        current = 0;
        while (current < nums_len - 1)
        {
            if (jump(current, true)) ++count;
            even_jumps.erase(current);
            odd_jumps.erase(current);
            ++current;
        }
        return count;
    }
};

//std::vector<int> subnums = { nums.begin() + j, nums.end() };
//std::sort(subnums.begin(), subnums.end());
//for (int k = 0; k < subnums.size(); k++)
//{
//    jNum = subnums[k];
//    if (iNum <= jNum && jNum < nums[newI])
//    {
//        //wI = std::find(subnums.begin(), subnums.end(), jNum);
//    }
//}
