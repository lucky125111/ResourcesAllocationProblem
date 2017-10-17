﻿using ASD.Graphs;

namespace AllocationService
{
    public class BestAllocationFinder
    {
        public ExpertProjectInformation ExpertProjectInformation { get; }
        public Graph FlowGraph { get; set; }
        
        public BestAllocationFinder(ExpertProjectInformation expertProjectInformation)
        {
            ExpertProjectInformation = expertProjectInformation;
            FlowGraph = GraphConverter.ExpertProjectInformationToGraph(expertProjectInformation);
        }

        public Graph CalculateMaxFlow()
        {
            Graph resGraph;

            //narazie na cele testow samego pomyslu kozystamy z gotowego rozwiazania
            FlowGraph.FordFulkersonDinicMaxFlow(0, FlowGraph.VerticesCount - 1, out resGraph, MaxFlowGraphExtender.MaxFlowPath);

            return resGraph;
        }

        public AllocationResult CalculateBestAllocation()
        {
            var resGraph = CalculateMaxFlow();

            var res = resGraph.GraphToAllocationResult(ExpertProjectInformation.ProjectCount, ExpertProjectInformation.SkillCount, ExpertProjectInformation.ExpertCount);

            return res;
        }
    }
}