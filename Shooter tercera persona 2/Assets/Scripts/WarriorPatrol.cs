using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class WarriorPatrol : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Follow,
        Die
    }
    public EnemyState currentState;
    //enemy's variables
    private NavMeshAgent agent;
    public Transform target;
    public float moveSpeed = 3.0f;
    public float rotateSpeed = 3.0f;
    public Transform[] Waypoints;
    public Material originalMaterial;
    public Material material;
    public float followRange = 10.0f;//Distancia de detección del enemigo
    public float idleRange = 10.0f;//Distáncia de vuelta al estado idle
    public bool dead = false;

    public Transform WaypointsParent;
    public Transform targetWP;

    public int targetWPIndex;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        targetWPIndex = 1;
        target= GameObject.FindGameObjectWithTag("Waypoints" + targetWPIndex).transform;
        agent.SetDestination(target.position);
        GoToNextState();
    }

    void Update()
    {       
        
        
    }
    IEnumerator IdleState()
    {

        GameObject insecto = GameObject.FindGameObjectWithTag("warrior");
        Animator warriorAnimator = insecto.GetComponent<Animator>();
        Transform insect=null;
        if (isAlive())
        {
            insect = GameObject.FindGameObjectWithTag("Player").transform;
            Vector3 positionInsect = insect.position;
        }
        else
            this.currentState = EnemyState.Die;

        target = GameObject.FindGameObjectWithTag("Waypoints" + targetWPIndex).transform;

        while (this.currentState == EnemyState.Idle && isAlive())
        {
            warriorAnimator.Play("PA_WarriorForward_Clip");
            //this.transform.position = Vector3.MoveTowards(this.transform.position,
            //    new Vector3(this.target.transform.position.x, 2, this.target.transform.position.z)
            //    , this.moveSpeed * Time.deltaTime);


            //RotateTowardsTarget();
            agent.SetDestination(target.position);
            if (GetDistance(insect.transform) < followRange)
            {
                this.currentState = EnemyState.Follow;
            }
            if (GetDistance(target.transform) < 1.0f)
            {
                if (targetWPIndex == 5)
                {
                    targetWPIndex = 1;
                }
                else
                    targetWPIndex++;
                target = GameObject.FindGameObjectWithTag("Waypoints" + targetWPIndex).transform;
            }
            nextTarger(targetWPIndex);
            yield return 0;
        }

        GoToNextState();
    }
    IEnumerator FollowState()
    {
        Debug.Log("entrar follow state");
        GameObject insecto = GameObject.FindGameObjectWithTag("warrior");
        Animator warriorAnimator = insecto.GetComponent<Animator>();
        if (isAlive())
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else
            this.currentState = EnemyState.Die;

        while (this.currentState == EnemyState.Follow && isAlive())
        {
            warriorAnimator.Play("PA_WarriorForward_Clip");

            //GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
            //this.transform.position = Vector3.MoveTowards(this.transform.position,
            //    new Vector3(this.target.transform.position.x, 2, this.target.transform.position.z)
            //    , this.moveSpeed * Time.deltaTime);
            //RotateTowardsTarget();
            agent.SetDestination(target.position);
            if (GetDistance(target.transform) > idleRange && target.tag.CompareTo("Player")==0)
            {
                this.currentState = EnemyState.Idle;
            }
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>().attachedRigidbody.constraints==RigidbodyConstraints.FreezePosition&&this.currentState==EnemyState.Follow)
            {
                this.GetComponent<Warrior2_shot>().fireRate = 6.06f;
                target.GetComponent<Renderer>().material = material;
                agent.SetDestination(this.transform.position);
                StartCoroutine(waitforseconds());
                
            }
            //else
            //{
            //    this.GetComponent<Warrior2_shot>().fireRate = 0.5f;
            //    agent.SetDestination(target.position);
            //}

            //if (GetDistance(target.transform) < 1.0f)
            //{
            //    GameObject.FindGameObjectWithTag("warrior").GetComponent<Rigidbody>().velocity.Set(3f, 3f, 3f);
            //}else
            //    //GameObject.FindGameObjectWithTag("warrior").GetComponent<Rigidbody>().velocity=1constraints = RigidbodyConstraints.None;
            if (dead)
            {
                this.currentState = EnemyState.Die;
            }
            yield return 0;
        }
        Debug.Log("salir follow state");
        GoToNextState();
    }

    IEnumerator waitforseconds()
    {   
        yield return new WaitForSeconds(3);
        this.GetComponent<Warrior2_shot>().fireRate = 0.5f;
        agent.SetDestination(target.position);
        target.GetComponent<Renderer>().material = originalMaterial;
        target.GetComponent<Collider>().attachedRigidbody.constraints = RigidbodyConstraints.None;
    }

    public Transform nextTarger(int i)
    {
        target = Waypoints[targetWPIndex-1];
        return target;
    }

    public bool isAlive()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            return true;
        }
        else
            return false;
    }
    IEnumerator DieState()
    {
        yield return 0;
    }
    //Calcula la distáncia entre el enemigo y su objetivo
    float GetDistance(Transform objetivo)
    {
        Vector3 director = this.transform.position - objetivo.position;

        return director.magnitude;
    }
    //Transiciona al siguiente estado que deba
    void GoToNextState()
    {
        //El nombre del método que voy a ejecutar a continuación
        string methodName = this.currentState.ToString() + "State";
        System.Reflection.MethodInfo info = GetType().GetMethod(methodName,
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        StartCoroutine((IEnumerator)info.Invoke(this, null));
    }

    void RotateTowardsTarget()
    {
        /*Direction indica el vector que empieza donde el enemigo
         * y acaba donde el objetivo*/
        Vector3 direction = target.position - this.transform.position;
        /*DirectionToFace indica la rotatción que debo 
         * sufrir para mirar hacia el objetivo*/
        Quaternion directionToFace = Quaternion.LookRotation(direction);
        /*El ángulo de rotación viene dado por s=v*t*/
        float angleToRotate = this.rotateSpeed * Time.deltaTime;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
            directionToFace, angleToRotate);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (!other.CompareTag("colliderWarrior"))
        //{
        //    dead = true;
        //}
    }
        void GetWayPoinsts()
        {
            int num0fWPs = WaypointsParent.childCount;
            Waypoints = new Transform[num0fWPs];
            for(int i = 0; i < Waypoints.Length; i++)
            {
                Waypoints[i] = WaypointsParent.GetChild(i);
            }
        }       
}
