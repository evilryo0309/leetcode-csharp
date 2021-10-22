using System.Linq;

/// <summary>
/// 1. Two Sum
/// https://leetcode.com/problems/two-sum/
/// </summary>
int[] TwoSum(int[] nums, int target)
{
    var query = nums
        .Select((num, index) => new { num, index })
        .Where(item =>
            nums
                .Where((i, index) => index != item.index)
                .Contains(target - item.num)
            )
        .Select(item => item.index)
        .ToArray();

    return query;
}

/// <summary>
/// 2. Add Two Numbers
/// https://leetcode.com/problems/add-two-numbers/
/// </summary>
ListNode AddTwoNumbers(ListNode l1, ListNode l2)
{
    ListNode answer = new ListNode();
    ListNode cur = answer;
    while (true)
    {
        int sum =
            cur.val +
            (l1?.val).GetValueOrDefault() +
            (l2?.val).GetValueOrDefault();

        cur.val = sum % 10;

        l1 = l1?.next;
        l2 = l2?.next;
        if (l1 != null || l2 != null)
        {
            cur.next = new ListNode(sum >= 10 ? 1 : 0);
            cur = cur.next;
        }
        else if (l1 is null && l2 is null)
        {
            if (sum >= 10)
                cur.next = new ListNode(1);
            break;
        }
    }

    return answer;
}

/// <summary>
/// 3. Longest Substring Without Repeating Characters
/// https://leetcode.com/problems/longest-substring-without-repeating-characters/
/// </summary>
int LengthOfLongestSubstring(string s)
{
    int answer = default;

    foreach (var sub in s.Select((c, index) => s[index..]))
    {
        int count = 0;
        for (int i = 0; i < sub.Length; i++)
        {
            var check = sub[0..i];
            var c = sub[i];

            if (!check.Contains(c))
                count++;
            else
                break;
        }
        if (count > answer) answer = count;
    }

    return answer;
}

/// <summary>
/// 4. Median of Two Sorted Arrays
/// https://leetcode.com/problems/median-of-two-sorted-arrays/
/// </summary>
double FindMedianSortedArrays(int[] nums1, int[] nums2)
{
    double answer = default;

    var query = nums1.Concat(nums2)
        .OrderBy(i => i)
        .ToArray();

    if (query.Length % 2 == 0)
    {
        answer = (query[query.Length / 2] + query[query.Length / 2 - 1]) / 2d;
    }
    else
    {
        answer = query[(query.Length - 1) / 2];
    }

    return answer;
}

/// <summary>
/// 5. Longest Palindromic Substring
/// https://leetcode.com/problems/longest-palindromic-substring/
/// </summary>
string LongestPalindrome(string s)
{
    string answer = null;

    return answer;
}
