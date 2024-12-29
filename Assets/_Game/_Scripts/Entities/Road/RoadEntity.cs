using UnityEngine;

public class RoadEntity : MonoBehaviour
{
    [SerializeField] private TriggerHandler roadEndTrigger;
    [SerializeField] private Transform roadEndPoint;
    [SerializeField] private MeshRenderer meshRenderer;

    private RoadController _roadController;
    public float RoadLength => meshRenderer.bounds.size.z;
    public Transform RoadEndPoint => roadEndPoint;

    public void Initialize(RoadController roadController)
    {
        roadEndTrigger.OnTriggered += OnPlayerReachedRoadEnd;
        _roadController = roadController;
    }

    private void OnPlayerReachedRoadEnd(Transform player)
    {
        _roadController.OnRoadEndReached(this);
    }
}
