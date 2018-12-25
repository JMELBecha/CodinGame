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
class Solution
{
    public enum Carte
    {
        C_2 = 2,
        C_3 = 3,
        C_4 = 4,
        C_5 = 5,
        C_6 = 6,
        C_7 = 7,
        C_8 = 8,
        C_9 = 9,
        C_10 = 10,
        C_J = 11,
        C_Q = 12,
        C_K = 13,
        C_A =14
        
    }

    static void Main(string[] args)
    {
        var Player1 = new Queue<Carte>();
        var Player2 = new Queue<Carte>();
        
        int n = int.Parse(Console.ReadLine()); // the number of cards for player 1
        for (int i = 0; i < n; i++)
        {
            Player1.Enqueue(Parse(Console.ReadLine())); // the n cards of player 1
        }
        int m = int.Parse(Console.ReadLine()); // the number of cards for player 2
        for (int i = 0; i < m; i++)
        {
            Player2.Enqueue(Parse(Console.ReadLine()));
        }
        int tour = 0;
        Queue<Carte> P1 = new Queue<Carte>();
        Queue<Carte> P2 = new Queue<Carte>();
        while(true)
        {
            
            Carte C1 = Player1.Dequeue();
            P1.Enqueue(C1);
            Carte C2 = Player2.Dequeue();
            P2.Enqueue(C2);
            if(C1>C2)
            {
                tour++;
                while(P1.Count>0)
                    Player1.Enqueue(P1.Dequeue());
                while(P2.Count>0)
                    Player1.Enqueue(P2.Dequeue());
                
            }
            if(C2>C1)
            {
                tour++;
                while(P1.Count>0)
                    Player2.Enqueue(P1.Dequeue());
                while(P2.Count>0)
                    Player2.Enqueue(P2.Dequeue());
            }
            if(Player1.Count==0)
            {
                Console.WriteLine("2 {0}",tour);break;
            }
            if(Player2.Count==0)
            {
                Console.WriteLine("1 {0}",tour);break;
            }
            if(C1==C2)//bataille
            {
                if(Player1.Count<=3 || Player2.Count<=3)
                {   Console.WriteLine("PAT");break;}
                P1.Enqueue(Player1.Dequeue());
                P1.Enqueue(Player1.Dequeue());
                P1.Enqueue(Player1.Dequeue());
                P2.Enqueue(Player2.Dequeue());
                P2.Enqueue(Player2.Dequeue());
                P2.Enqueue(Player2.Dequeue());
            }
        }
        
    }
    
    public static Carte Parse(string s)
    {
        if(s.Length == 3)
            return Carte.C_10;
        if(Char.IsDigit(s[0]))
            return (Carte)int.Parse(s[0].ToString());
        if(s[0]=='J')
            return Carte.C_J;
        if(s[0]=='Q')
            return Carte.C_Q;
        if(s[0]=='K')
            return Carte.C_K;
        if(s[0]=='A')
            return Carte.C_A;
        return Carte.C_A;
    }
}
