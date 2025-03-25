using System;
using System.Collections.Generic;

public class Solution {
    public int[] SingleNumber(int[] nums) {
        /XOR всех элементов
        int xor = 0;
        foreach (int num in nums) {
            xor ^= num;
        }
        
       
        int diffBit = xor & -xor;
        
        int num1 = 0, num2 = 0;
        //   числа на две  грпы по этому биту
        foreach (int num in nums) {
            if ((num & diffBit) != 0) {
                num1 ^= num;
            } else {
                num2 ^= num;
            }
        }
        
        return new int[] { num1, num2 };
    }
}
