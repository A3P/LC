using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public CourseNode[] nodes;
    public bool[] visited;

    public class CourseNode
    {
        public int val;
        public List<CourseNode> edges;

        public CourseNode(int val)
        {
            this.val = val;
            edges = new List<CourseNode>();
        }

        public void Add(CourseNode node)
        {
            edges.Add(node);
        }
    }

    // Right now we are traversing index 0 but I need to traverse all of it. I need to handle nulls for traversal. cause right now, we are hardcoding skipping the first one.
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        nodes = new CourseNode[numCourses];
        visited = new bool[numCourses];
        //Console.WriteLine($"Length: {prerequisites.Length}");
        for (int i  = 0; i < prerequisites.Length;i++)
        {
            int currentCourse = prerequisites[i][0];
            int preReq = prerequisites[i][1];

            if (nodes[currentCourse] == null)
            {
                nodes[currentCourse] = new CourseNode(currentCourse);
                //Console.WriteLine($"Create currentCourse {currentCourse} Node");
            }
            if (nodes[preReq] == null)
            {
                nodes[preReq] = new CourseNode(preReq);
                //Console.WriteLine($"Create preReq {preReq} Node");
            }
            //Console.WriteLine($"{currentCourse} add preReq {preReq}");
            //Console.WriteLine($"{nodes[currentCourse].val} add preReq {preReq}");
            nodes[currentCourse].Add(nodes[preReq]);
            //Console.WriteLine($"{currentCourse} add preReq {preReq}");
        }
        //Console.WriteLine($"nodes legnth: {nodes.Length}");
        if(prerequisites.Length < 1)
        {
            return true;
        }
        for (int i = 0; i < nodes.Length;i++)
        {
            if (nodes[i] != null && !visited[i])
            {
                bool[] cycled = new bool[numCourses];
                if(!Traverse(nodes[i], cycled))
                {
                    return false;
                }
            }
        }
        return true;
    }

    private bool Traverse(CourseNode course, bool[] cycled)
    {
        if (cycled[course.val]) {
            return false;
        }
        if (visited[course.val])
        {
            return true;
        }
        cycled[course.val] = true;
        //Console.WriteLine($"Traversing {course.val}");

        foreach(CourseNode edge in course.edges)
        {
            if (!visited[edge.val])
            {
                if (!Traverse(edge, cycled))
                {
                    return false;
                }
            }
        }
        cycled[course.val] = false;
        visited[course.val] = true;
        return true;
    }
}