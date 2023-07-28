﻿using UnityEngine;

namespace BehaviourGraph.Visualizer
{
    public enum LinkType
    {
        FromTo,
        Ended,
        Global,
    }

    public enum FromType
    {
        Single,
        Multiple,
    }

    public class VisualizedLink : MonoBehaviour
    {
        public LinkType linkType;
        public VisualizedBranch[] froms;
        public VisualizedBranch to;
        public VisualizedCondition condition;
        
        [InspectorButton("Add Condition")]
        public void AddVisualiseCondition()
        {
            var conditionName = "Condition";
            var go = new GameObject(conditionName);
            go.transform.SetParent(transform);
            go.transform.localPosition = Vector3.zero;
        }

        [InspectorButton("Add Selector")]
        public void AddSelector()
        {
            var go = new GameObject("Selector");
            VisualizedSelector select = (VisualizedSelector)go.AddComponent(typeof(VisualizedSelector));
            go.transform.SetParent(transform);
            go.transform.localPosition = Vector3.zero;
            condition = select;
        }

        [InspectorButton("Add Sequencer")]
        public void AddSequencer()
        {
            var go = new GameObject("Sequencer");
            VisualizedSequencer sequen = (VisualizedSequencer)go.AddComponent(typeof(VisualizedSequencer));

            go.transform.SetParent(transform);
            go.transform.localPosition = Vector3.zero;
            condition = sequen;
        }
    }
}