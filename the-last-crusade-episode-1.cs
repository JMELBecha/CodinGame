using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Player
{
    
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]); // number of columns.
        int H = int.Parse(inputs[1]); // number of rows.
        var Lines = new List<int[]>();
        for (int i = 0; i < H; i++)
        {
            string LINE = Console.ReadLine(); // represents a line in the grid and contains W integers. Each integer represents one room of a given type.
            Console.Error.WriteLine(LINE);
            Lines.Add(Array.ConvertAll(LINE.Split(' '), int.Parse).ToArray());
        }
        int EX = int.Parse(Console.ReadLine()); // the coordinate along the X axis of the exit (not useful for this first mission, but must be read).
        Console.Error.WriteLine(EX);
        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int X = int.Parse(inputs[0]);
            int Y = int.Parse(inputs[1]);
            string POS = inputs[2];
            Console.Error.WriteLine("Cell:{3} X:{0} Y:{1} POS:{2} ",X,Y, POS,Lines[Y][X]);
            switch(Lines[Y][X])
            {
                case 0:break;
                case 1:
                    Y++;
                    break;
                case 2:
                    if(POS=="LEFT")     X++;
                    if(POS=="RIGHT")    X--;
                    break;
                case 3:
                    Y++;break;
                case 4:
                    if(POS=="TOP")     X--;
                    if(POS=="RIGHT")   Y++;
                    break;
                case 5:
                    if(POS=="TOP")     X++; 
                    if(POS=="LEFT")    Y++;
                    break;
                case 6:
                    if(POS=="LEFT")    X++;
                    if(POS=="RIGHT")   X--;
                    break;
                case 7:
                    if(POS=="TOP" || POS=="RIGHT")    Y++;
                    break;
                case 8:
                    if(POS=="LEFT" || POS=="RIGHT")    Y++;
                    break;
                case 9:
                    if(POS=="TOP" || POS=="LEFT")    Y++;
                    break;
                case 10:
                    if(POS=="TOP")  X--;
                    break;
                
                case 11:
                    if(POS=="TOP")  X++;
                    break;
                case 12:
                    if(POS=="RIGHT") Y++;
                    break;
                case 13:
                    if(POS=="LEFT") Y++;
                    break;    
            }
            Console.WriteLine(X + " " + Y);
        }
    }
}
