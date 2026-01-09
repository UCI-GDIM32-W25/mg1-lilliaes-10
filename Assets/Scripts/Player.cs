using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _plantPrefab;
    [SerializeField] private int _numSeeds = 5; 
    [SerializeField] private PlantCountUI _plantCountUI;

    private int _numSeedsLeft;
    private int _numSeedsPlanted;

    private void Start ()
    {
        GetComponent<Rigidbody2D>();
        _numSeedsLeft = 5;
        _numSeedsPlanted = 0;
    }

    private void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            moveDirection += Vector3.up;
        if (Input.GetKey(KeyCode.S))
            moveDirection += Vector3.down;
        if (Input.GetKey(KeyCode.A))
            moveDirection += Vector3.left;
        if (Input.GetKey(KeyCode.D))
            moveDirection += Vector3.right;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // if the player doesn't have any seeds left
            // DO NOT plant a seed
            if (_numSeedsLeft <= 0)
                return;
            PlantSeed();
        }

        _playerTransform.Translate(moveDirection.normalized * _speed * Time.deltaTime);
    }

    public void PlantSeed ()
    {
        Instantiate(_plantPrefab, _playerTransform.position, Quaternion.identity);
        _numSeedsLeft -= 1;
        _numSeedsPlanted += 1;
        _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);
    }

}