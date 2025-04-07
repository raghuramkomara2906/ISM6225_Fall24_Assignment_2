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

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
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
                for (int i = 0; i < nums.Length - 1; i++) // Ensuring we don't go out of bounds
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
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Initialize two pointers:
                // 'l' starts from the beginning, 'r' starts from the end
                int l = 0;
                int r = nums.Length-1;
                // Loop until the pointers meet
                while (l<r)
                {
                    // If the left number is even, it's in the right place, so moving the left pointer forward
                    if (nums[l]%2==0)
                    {
                        l++;
                    }
                    // If the right number is odd, it's in the correct place, so moving the right pointer backward
                    else if (nums[r]%2!=0)
                    {
                        r--;
                    }
                    else
                    {
                        // nums[l] is odd and nums[r] is even, so swap them
                        int temp = nums[r];
                        nums[r]=nums[l];
                        nums[l]=temp;
                        //Moving both pointers inward after the swap
                        l++;
                        r--;
                    }
                }
                return nums; // Returning the modified array with even numbers at the front, odd numbers at the back
            }
            catch (Exception)
            {
                // Rethrow the exception if any unexpected error occurs
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
                return Array.Empty<int>();  //Edge case : no valid pair found
            }
            catch (Exception)
            {
                // In case of unexpected errors (e.g., null array), rethrow the exception
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                if(nums== null || nums.Length <3) // Edge Case : Checking if the array is null or has less than 3 elements
                    throw new ArgumentException("Array must contain at least three numbers.");
                //Sort the array in ascending order
                Array.Sort(nums);
                int n = nums.Length;
                int product1 = nums[n-1]*nums[n-2]*nums[n-3]; // Product of three largest numbers
                int product2 = nums[0]*nums[1]*nums[n-1]; // Product of two smallest and one largest number
                int maxProduct = Math.Max(product1, product2);
                return maxProduct;// Returning the maximum of 2 proucts gives the maximum product of 3 numbers
            }
            catch (OverflowException)
            {
                Console.WriteLine("Overflow occurred while computing the product.");
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Use built-in .NET method to convert the decimal number to binary string.
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
                // Initializing two pointer for binary search
                int l =0;
                int r = nums.Length-1;
                // Running the loop till the pointers l and r meet
                while (l<r)
                {
                    int mid = l+(r-l)/2;// Calculating the mid index
                    // If middle element is greater than the rightmost element,
                   // the minimum must be in the right half (excluding mid)
                    if (nums[mid]>nums[r])
                    {
                        l=mid+1;
                    }
                    else
                    {
                        // Otherwise, the minimum is at mid or in the left half
                        r=mid;
                    }
                }
                // When loop ends, l == r, and both point to the minimum element
                return nums[l];
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
                if(x<0) return false;// Edge Case : negative numbers are not plaindromes
                int original = x;
                int reversed = 0;
                while (x>0)//This while loop iterates until x is greater than 0
                {
                    int digit = x %10;// This line gets the last digit of x
                    reversed = reversed*10 + digit;//This line reverses the number
                    x/=10;//This line removes the last digit from x
                }
                return original == reversed; // This line checks if the original number is equal to the reversed number
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
                if (n==0) return 0;//This line returns 0 if n is 0
                if (n==1) return 1;//This line returns 1 if n is 1
                int a = 0;
                int b = 1;
                int result = 0;
                for(int i = 2; i<=n; i++)//This for loop iterates from 2 to n
                {
                    result = a+b;// This line calculates the next Fibonacci number
                    a=b;// This lines stores the previous Fibonacci number
                    b=result;// This line stores the current Fibonacci number
                }
                return result; // This line returns the nth Fibonacci number
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
