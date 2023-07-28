using BehaviourGraph.Trees;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BehaviourGraph.Visualizer
{

    public class VisualizedEmptyBranch : VisualizedBranch
    {
        public List<VisualizedBranch> leafs;
        public List<VisualizedLink> links = new List<VisualizedLink>();
        public int startableLeaf_ID = 0;

        private string _visLeafsName = "Leafs";
        private string _visLinkName = "Links";


        public override HierarchyBranch GetInstance(AIBehaviourGraph graph)
        {
            return new HierarchyBranch(graph);
        }

        [InspectorButton("Add Link")]
        public void AddVisualizedLink()
        {
            var parent = transform.Find(_visLinkName)?.gameObject;
            if (parent == null)
            {
                parent = new GameObject(_visLinkName);
                parent.transform.SetParent(transform);
                parent.transform.localPosition = Vector3.zero;

            }

            var go = new GameObject("Link1");
            VisualizedLink vLink = (VisualizedLink)go.AddComponent(typeof(VisualizedLink));
            go.transform.SetParent(parent.transform);
            go.transform.localPosition = Vector3.zero;
            links.Add(vLink);
        }

        [InspectorButton("Add Leaf")]
        public void AddVisualizedLeaf()
        {
            var parent = transform.Find(_visLeafsName)?.gameObject;
            if (parent == null)
            {
                parent = new GameObject(_visLeafsName);
                parent.transform.SetParent(transform);
                parent.transform.localPosition = Vector3.zero;
            }

            var go = new GameObject("Leaf1");
            go.transform.SetParent(parent.transform);
            go.transform.localPosition = Vector3.zero;
        }

        [InspectorButton("Add Branch")]
        public void AddVisualizedBranch()
        {
            var parent = transform.Find(_visLeafsName)?.gameObject;
            if (parent == null)
            {
                parent = new GameObject(_visLeafsName);
                parent.transform.SetParent(transform);
                parent.transform.localPosition = Vector3.zero;
            }

            var go = new GameObject("Branch1");
            VisualizedEmptyBranch branchComp = (VisualizedEmptyBranch)go.AddComponent(typeof(VisualizedEmptyBranch));
            go.transform.SetParent(parent.transform);
            go.transform.localPosition = Vector3.zero;

            leafs.Add(branchComp);
        }

        [InspectorButton("Get Child Links")]
        public void GetVisualizedLinks()
        {
            links.Clear();

            var ls = transform.GetComponentsInChildren<VisualizedLink>();

            foreach (var l in ls)
            {
                links.Add(l);
            }
        }

        [InspectorButton("Get Child Leafs")]
        public void GetVisualizedLeafs()
        {
            leafs.Clear();

            List<VisualizedBranch> ls = new List<VisualizedBranch>();
            foreach (Transform c in transform)
            {
                if (c.name == _visLeafsName)
                {
                    for (int i = 0; i < c.childCount; i++)
                    {
                        var c2 = c.GetChild(i);
                        if (c2.TryGetComponent<VisualizedBranch>(out var outLeaf))
                            ls.Add(outLeaf);
                    }
                }
                else
                {
                    var cL = c.Find(_visLeafsName);
                    if (cL == null)
                        continue;

                    for (int i = 0; i < cL.childCount; i++)
                    {
                        var c2 = cL.GetChild(i);
                        if (c2.TryGetComponent<VisualizedBranch>(out var outLeaf))
                            ls.Add(outLeaf);
                    }
                }
            }

            //foreach (var l in ls)
            //    leafs.Add(l);

            leafs.AddRange(ls);

         
        }

    }
}
