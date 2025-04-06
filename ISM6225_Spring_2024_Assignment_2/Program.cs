using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            //// Question 8: Fibonacci Number
            //Console.WriteLine("Question 8:");
            //int n = 4;
            //int fibonacciNumber = Fibonacci(n);
            //Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                List<int> missingNumbers = new List<int>();

                // Step 1: Sort the array to handle the numbers in order
                Array.Sort(nums);

                // Step 2: Loop through the array to find gaps
                for (int i = 0; i < nums.Length - 1; i++) // Ensure we don't go out of bounds
                {
                    int current = nums[i];
                    int next = nums[i + 1];

                    // Step 3: If there's a gap between current and next
                    if (current + 1 != next)
                    {
                        // Add all missing numbers between current and next
                        for (int j = current + 1; j < next; j++)
                        {
                            missingNumbers.Add(j);
                        }
                    }
                }

                // Step 4: Check if the largest number is less than the length of the array
                if (nums[nums.Length - 1] < nums.Length)
                {
                    missingNumbers.Add(nums.Length);
                }

                // Step 5: Handle the edge case for an empty array
                if (nums.Length == 0)
                {
                    return missingNumbers;
                }

                return missingNumbers;
            }
            catch (Exception)
            {
                //Console.WriteLine("An error occurred: " + ex.Message);
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                int l= 0;
                int r = nums.Length-1;
                while (l<r)
                {
                    if (nums[l]%2==0)
                    {
                        l++;
                    }
                    else if (nums[r]%2!=0)
                    {
                        r--;
                    }
                    else
                    {
                        int temp = nums[r];
                        nums[r]=nums[l];
                        nums[l]=temp;
                        l++;
                        r--;
                    }
                }
                return nums; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                for (int i =0; i <nums.Length; i++)
                {
                    for (int j=1;j< nums.Length; j++)
                    {
                        if (nums[i]+nums[j]==target)
                        {
                            return new int[] {i,j};
                        }
                    }
                }
                return Array.Empty<int>(); // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                Array.Sort(nums);
                int n = nums.Length;
                int product1 = nums[n-1]*nums[n-2]*nums[n-3]; // Product of three largest numbers
                int product2 = nums[0]*nums[1]*nums[n-1]; // Product of two smallest and one largest number
                int maxProduct = Math.Max(product1, product2);
                return maxProduct;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                string binary_number = Convert.ToString(decimalNumber,2);
                return binary_number;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                int l=0;
                int r = nums.Length-1;
                while (l<r)
                {
                    int mid = l+(r-l)/2;
                    if (nums[mid]>nums[r])
                    {
                        l=mid+1;
                    }
                    else
                    {
                        r=mid;
                    }
                }
                return nums[l]; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                if(x<0) return false;
                int original = x;
                int reversed = 0;
                while (x>0)
                {
                    int digit = x %10;
                    reversed = reversed*10 + digit;
                    x/=10;
                }
                return original == reversed; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Write your code here
                return 0; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
