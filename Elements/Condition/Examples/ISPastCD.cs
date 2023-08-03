using BehaviourGraph;
using BehaviourGraph.Conditions;

public class ISPastCD : DefaultCondition
{
    public ISPastCD(ILeaf leaf, float duration)
    {
        _leaf = leaf;
        _duration = duration;
    }

    private ILeaf _leaf;
    private float _duration;

    public override UpdateStatus OnUpdate()
    {
        return _leaf.CheckCD(_duration) ? UpdateStatus.Successed : UpdateStatus.Failure;
    }
}
