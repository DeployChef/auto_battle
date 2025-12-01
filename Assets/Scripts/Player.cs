using System;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private float R = 6;
    [SerializeField] private bool _isEnemy = true;
    [SerializeField] private NavMeshAgent _agent;

    private Player _p;
    void Start()
    {
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }
    
    private void FixedUpdate()
    {
       Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, R);


       colliders = colliders.Where(x => x.TryGetComponent(out Player player) && player._isEnemy != _isEnemy)
           .OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).ToArray();

       if (colliders.Length != 0)
       {
           var closeTarget = colliders.First();
           print(closeTarget.gameObject.name);
           var Target = closeTarget.transform.position;


           float dis = Vector3.Distance(Target, transform.position);
           dis -= 2;

           print(dis);
           if (dis < 0)
               return;



           _agent.SetDestination(transform.position + (Target - transform.position).normalized * dis);
       }
      
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


        // https://github.com/h8man/NavMeshPlus.git
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,R);
    }

    void Update()
    {
        //transform.position += new Vector3(0, 0.1f, 0);
    }
}
