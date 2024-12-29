using UnityEngine;
using Zenject;

public class CarCrashSimulator : MonoBehaviour
{
    [Inject] IGameManager _gameManager;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Collider collider;
    [SerializeField] private PhysicMaterial lowFrictionMaterial;
    [SerializeField] private float upwardForce;
    [SerializeField] private float forwardForce;
    [SerializeField] private float torqueMultiplier;

    private bool _isPhysicsActive = false;

    public void Initialize()
    {
        DeactivatePhysics();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out NPCCarEntity npcCar))
        {
            ActivatePhysics();
            _gameManager.OnGameFailed();
        }
    }

    private void ActivatePhysics()
    {
        if (_isPhysicsActive) return;
        _isPhysicsActive = true;
        rb.isKinematic = false;
        collider.isTrigger = false;

        Vector3 randomTorque = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        ).normalized * torqueMultiplier;
        rb.AddTorque(randomTorque, ForceMode.Impulse);
        rb.AddForce((Vector3.up * upwardForce) + (Vector3.forward * forwardForce) , ForceMode.Impulse);
    }

    public void DeactivatePhysics()
    {
        _isPhysicsActive = false;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        collider.isTrigger = true;
    }
}
