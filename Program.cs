// See https://aka.ms/new-console-template for more information
using System.Runtime.Serialization.Formatters;

Console.WriteLine("Hello, World!");

var nums = new int[] { 3,3 };
int target = 6;

var sol = Test_Solution.TargetInteger(nums, target);
sol = Test_Solution.BetterTargetInteger(nums, target);
Console.WriteLine($"Solution is: {sol[0]} ; {sol[1]}");
Console.ReadKey();

public class Test_Solution
{
    public static int[] TargetInteger(int[] intArray, int targetInt)
    {
        for (int i = 0; i < intArray.Length - 1; i++)
        {
            //for each element, I have to search the subtraction of it and the targetInt
            for (int j = i+1; j < intArray.Length; j++)
            {
                if (intArray[i] + intArray[j] == targetInt)
                {
                    // found the target!
                    return new int[] { i, j };
                }
            }
        }

            throw new ArgumentOutOfRangeException("This shouldn't happen"); // very bad
    }

    public static int[] BetterTargetInteger(int[] nums, int targetInt)
    {
        // create a hashset of the array
        var numsHashSet = new HashSet<int>(nums);
        // for every element of the array
        for (int i = 0; i < nums.Length; i++)
        {
            // we have to check whether the hashset has the "complement"
            int complement = targetInt - nums[i];
            if (numsHashSet.Contains(complement))
            {
                // found it!
                // search for the index
                for (int j = 0; j < nums.Length; j++)
                {
                    if (nums[j] == complement && i != j)
                    {
                        return new int[] { i, j };
                    }
                }
            }
        }

        throw new ArgumentOutOfRangeException("This shouldn't happen"); // very bad
    }
}