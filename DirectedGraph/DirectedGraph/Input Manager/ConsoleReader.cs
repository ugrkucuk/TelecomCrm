﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectedGraph.Algorithm_Manager;
using DirectedGraph.Input_Manager.Input_Validator;
using System.IO;
using static System.Int32;

namespace DirectedGraph.Input_Manager
{
    public class ConsoleReader : IReader
    {

        private IValidator validator;

        public List<Node> Read()
        {
            if (validator == null)
            {
                validator = ValidatorFactory.GetValidator();
            }

            var graph = new List<Node>();
            Console.WriteLine("Enter your input like AB5, XY4, ZT3 etc.\n");
            var nodes = Console.ReadLine();
            var nodeList = nodes.Replace(" ", "").Split(',');
            foreach (var v in nodeList)
            {
                if (validator.Validate(v.Trim()))
                {
                    var startNode = new Node { Name = v[0].ToString() };
                    var endNode = new Node { Name = v[1].ToString() };
                    var startNodeExist = false;
                    var endNodeExist = false;

                    foreach (var node in graph)
                    {
                        if (startNode.Name.Equals(node.Name))
                        {
                            startNode = node;
                            startNodeExist = true;
                        }

                        if (endNode.Name.Equals(node.Name))
                        {
                            endNode = node;
                            endNodeExist = true;
                        }
                    }

                    var edge = new Edge
                    {
                        Target = endNode,
                        Length = Parse(v.Trim().Substring(2))
                    };
                    startNode.Edges.Add(edge);
                    if (!startNodeExist)
                    {
                        endNode.Index = graph.Count;
                        graph.Add(startNode);
                    }
                    if (!endNodeExist)
                    {
                        endNode.Index = graph.Count;
                        graph.Add(endNode);
                    }
                }
            }
            return graph;
        }
    }
}