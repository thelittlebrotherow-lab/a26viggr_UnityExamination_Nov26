
using System;
using System.Collections;
using System.Threading.Tasks;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class ConfinerTransition : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D mapBoundry;
    [SerializeField] private float directionOffset;
    [SerializeField] private Transform wayPoint;
    [SerializeField] private bool Locked;
    [SerializeField] Animator animator;

    public UnityEvent<bool> onBoolChanged;


    public void SetBoolTrue()
    {
        onBoolChanged.Invoke(true);
    }

    public void SetBoolFalse()
    {
        onBoolChanged.Invoke(false);
    }
    enum Direction
    {
        Left,
        Right,
        Up,
        Down,
    }

    [SerializeField] private Direction direction;
    private CinemachineConfiner2D confiner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        confiner = FindAnyObjectByType<CinemachineConfiner2D>();
    }

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !Locked)
        {
            StartCoroutine(UpdatePlayerPos(collision.gameObject));
        }
    }

    private IEnumerator UpdatePlayerPos(GameObject player)
    {
        SetBoolFalse();
        animator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        Vector3 playerpos = player.transform.position;
        confiner.BoundingShape2D = mapBoundry;
        
        switch (direction)
        {
            
            case Direction.Left:
                playerpos = new Vector3(wayPoint.position.x - directionOffset, wayPoint.position.y, 0);
                break;
            case Direction.Right:
                playerpos = new Vector3(wayPoint.position.x + directionOffset, wayPoint.position.y, 0);
                break;
            case Direction.Up:
                playerpos = new Vector3(wayPoint.position.x, wayPoint.position.y -directionOffset, 0);
                break;
            
            case Direction.Down:
                playerpos = new Vector3(wayPoint.position.x, wayPoint.position.y + directionOffset, 0);
                break;
        }

        player.transform.position = playerpos;

        yield return new WaitForSeconds(1.3f);
        player.SetActive(false);
        player.SetActive(true);

        animator.SetTrigger("FadeOut");
        SetBoolTrue();
    }
    
    
}
