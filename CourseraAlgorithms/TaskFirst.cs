using System;
using System.Collections.Generic;
using System.Text;

namespace CourseraAlgorithms
{
    public class TaskFirst
    {
        private int[] id;   //Component id
        private int[] sz;   //The magnitude of the component corresponding to each root node
        private int count;  //Component quantity
        private int[] max;

        public TaskFirst(int N)
        {
            count = N;
            id = new int[N];
            sz = new int[N];
            max = new int[N];
            for (int i = 0; i < N; i++)
            {
                id[i] = i;
                sz[i] = 1;
                max[i] = i;
            }
        }

        public bool find(int p, int q)
        {
            return root(p) == root(q);
        }

        public void union(int p, int q)
        {
            int i = root(p);
            int j = root(q);
            if (i == j) return;
            if (sz[i] > sz[j])
            {
                id[j] = i;
                sz[i] += sz[j];
            }
            else
            {
                id[i] = j;
                var n = sz[j];
                sz[j] += sz[i];
                sz[i] += n;
            }
        }

        public int root(int i)
        {
            while (id[i] != i)
            {
                id[i] = id[id[i]];
                i = id[i];
            }
            return i;
        }

       
    }

    public class Log
    {
        public int FirstId { get; set; }
        public int SecondId { get; set; }
        public DateTime Date { get; set; }
    }
}