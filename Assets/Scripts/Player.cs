using System;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float R = 6;
    [SerializeField] private bool _isEnemy = true;

    private Player _p;
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
       Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, R);


       colliders = colliders.Where(x => x.TryGetComponent(out Player player) && player._isEnemy != _isEnemy)
           .OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).ToArray();

        if(colliders.Length != 0)
       print(colliders.First().gameObject.name);
       //foreach (var collider in colliders)
       //{
       //    if (collider.TryGetComponent(out Player player) && player._isEnemy != _isEnemy)
       //    {

       //    }
       //}

       //Debug.Log();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,R);
    }

    void Update()
    {
        
    }
}
