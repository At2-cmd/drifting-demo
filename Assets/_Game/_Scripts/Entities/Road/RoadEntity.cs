using UnityEngine;

public class RoadEntity : MonoBehaviour
{
    [SerializeField] private NPCCarGenerator npcCarGenerator;
    [SerializeField] private CoinGenerator coinGenerator;
    [SerializeField] private TriggerHandler roadEndTrigger;
    [SerializeField] private MeshRenderer meshRenderer;

    private RoadController _roadController;
    private Vector3 _initialRoadPosition;
    public float RoadLength => meshRenderer.bounds.size.z;

    public void Initialize(RoadController roadController)
    {
        npcCarGenerator.Initialize();
        coinGenerator.Initialize();
        roadEndTrigger.OnTriggered += OnPlayerReachedRoadEnd;
        _roadController = roadController;
        _initialRoadPosition = transform.position;
    }

    private void OnPlayerReachedRoadEnd(Transform player)
    {
        _roadController.OnRoadEndReached(this);

        npcCarGenerator.ResetGeneratedObjects();
        npcCarGenerator.GenerateObjects();

        coinGenerator.ResetGeneratedObjects();
        coinGenerator.GenerateObjects();
    }
    
    public void ResetRoadToInitialStatus()
    {
        transform.position = _initialRoadPosition;

        npcCarGenerator.ResetGeneratedObjects();
        npcCarGenerator.GenerateObjects();

        coinGenerator.ResetGeneratedObjects();
        coinGenerator.GenerateObjects();
    }
}
