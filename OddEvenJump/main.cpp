/* Problem:

https://leetcode.com/problems/odd-even-jump/

You are given an integer array arr. From some starting index, you can make a series of jumps. The (1st, 3rd, 5th, ...) jumps in the series are called odd-numbered jumps,
and the (2nd, 4th, 6th, ...) jumps in the series are called even-numbered jumps. Note that the jumps are numbered, not the indices.

You may jump forward from index i to index j (with i < j) in the following way:

 - During odd-numbered jumps (i.e., jumps 1, 3, 5, ...), you jump to the index j such that arr[i] <= arr[j] and arr[j] is the smallest possible value.
   If there are multiple such indices j, you can only jump to the smallest such index j.

 - During even-numbered jumps (i.e., jumps 2, 4, 6, ...), you jump to the index j such that arr[i] >= arr[j] and arr[j] is the largest possible value.
   If there are multiple such indices j, you can only jump to the smallest such index j.

A starting index is good if, starting from that index, you can reach the end of the array (index arr.length - 1) by jumping some number of times (possibly 0 or more than once).
Return the number of good starting indices.

*/

#include <iostream>
#include <chrono>
#include "solution.h"

int main()
{
    Solution sln;

    auto start = std::chrono::high_resolution_clock::now();

    // real array for tests see at arr.txt
    std::vector<int> arr{
        10, 123,432,54    
    };

    // still too slow
    int count = sln.oddEvenJumps(arr);

    auto stop = std::chrono::high_resolution_clock::now();
    auto duration = std::chrono::duration_cast<std::chrono::milliseconds>(stop - start);

    std::cout << "jumps: " << count << '\n';
    std::cout << "duration: " << duration.count() << '\n';
}