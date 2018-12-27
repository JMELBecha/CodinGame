/*
JMEL Becha
27/12/2018
+21625214111
*/
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string[] inputs = Console.ReadLine().Split(' ');
        List<int> perte = new List<int>();
        perte.Add(0);
        int v = int.Parse(inputs[0]);
        int max_value = v; 
        int min_value = v;
        for (int i = 1; i < n; i++)
        {
            v = int.Parse(inputs[i]);
            if(v<min_value)
                min_value = v;
            if(v>max_value)
                max_value = v;
            if(v<max_value)
                perte.Add(v-max_value);
        }
        Console.WriteLine(perte.Min());
    }
}
