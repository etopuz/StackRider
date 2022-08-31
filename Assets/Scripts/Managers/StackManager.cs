using System.Collections.Generic;
using UnityEngine;

public class StackManager : Singleton<StackManager>
{
    [Header("References")]
    [SerializeField]
    private Transform mainBall;
    [SerializeField] 
    private Transform stackedBallsContainer;
    [SerializeField] 
    private Transform freeBallsContainer;
    
    
    private float _distanceBetweenBalls;
    
    private List<Transform> _stack = new List<Transform>();
    
    private void Start()
    {
        _distanceBetweenBalls = mainBall.localScale.y;
        _stack.Add(mainBall);
    }
    
    public void Pickup(Transform ball)
    {
        Vector3 lastItemPos = _stack[^1].position;
        ball.position = lastItemPos;
        
        ShiftStack();
        
        _stack.Add(ball);
        ball.transform.parent = stackedBallsContainer;
    }

    private void ShiftStack()
    {
        for (int i = 0; i < _stack.Count; i++)
        {
            _stack[i].localPosition = new Vector3(0, (_stack.Count - i) * _distanceBetweenBalls, 0);
        }
    }

    public void Drop(Transform ball)
    {
       _stack.Remove(ball);
       ball.transform.parent = freeBallsContainer;
    }


}
