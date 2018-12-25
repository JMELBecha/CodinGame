using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    public class Node
    {
        public int Value{get;set;}
        public Node(int value)
        {
            Value=value;
            Nodes = new List<Node>();
        }
        public List<Node> Nodes{get;}
    }
    static int Length=0;
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()); // the number of adjacency relations
        var AllNodes=new Dictionary<int,Node>();
        for (int i = 0; i < n; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            
            int xi = int.Parse(inputs[0]); // the ID of a person which is adjacent to yi
            int yi = int.Parse(inputs[1]); // the ID of a person which is adjacent to xi
            if(!AllNodes.ContainsKey(xi))
                AllNodes.Add(xi,new Node(xi));
            if(!AllNodes.ContainsKey(yi))
                AllNodes.Add(yi,new Node(yi));
            //Console.Error.WriteLine("{0} {1}",xi,yi);
            AllNodes[xi].Nodes.Add(AllNodes[yi]);
            AllNodes[yi].Nodes.Add(AllNodes[xi]);
        }
        Length=0;
        NodeLength(0,AllNodes.Values.First(node => node.Nodes.Count==1),null);
        Console.WriteLine(Math.Ceiling((double)Length/2));
        
    }
    static void NodeLength(int count,Node node, Node parent)
    {
        if(Length<count)
            Length=count;
        foreach(Node n in node.Nodes)
            if(!ReferenceEquals(n,parent))
                NodeLength(count+1,n,node);
    }
    
    
}
