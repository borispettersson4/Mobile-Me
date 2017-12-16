using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class Antagonist : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for

        private float distance;
        private bool chase = false;
        private bool patrol = true;
        private bool active = true;
        private bool outOfSight = true;
        private bool isOnWaypoint = false;
        private int waypointCount = 0;
        private int currentWaypoint = 0;
        private float lostValue;
        private bool lostPlayer = true;

        private bool isInRoom = false;
        WaypointGroup roomWaypoints;
        private int roomWaypointDestinationCount = 0;

        public Animator animator;
        public WaypointGroup waypoints;
        public float destinationResetTime = 1.0f;
    //    public Collider hitBox;
    //    public Collider AIAttackRange;
        private float originalSpeed;
        private WaypointGroup originalWaypoints;
        public Collider hitBox;

        public Camera eyes;
        public DamageSystem damageSystem;
        public float health;
        public float runMultiplier = 1.5f;

    // Native bools for hit
    bool isInjured1 = false;
    bool isInjured2 = false;
    bool isInjured3 = false;

    //Death
    public bool generateSomethingOnDeath = false;
    public Transform generateLocation;
    public GameObject generatedItem;
    bool activeDeath = true;
    public bool hasEffects = false;
    public GameObject[] effects;

    private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

            agent.updateRotation = false;
            agent.updatePosition = true;

            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            waypointCount = waypoints.getLength();
            changeWaypoint();
            originalSpeed = agent.speed;
            originalWaypoints = waypoints;
    }

        private void Update()
        {
        AINavigationManager();
        AIHealthManager();
      //  Debug.Log(lostValue);
        }

        IEnumerator chaseTarget()
    {
      //  Debug.Log("isChasing :" + Time.deltaTime);

        agent.speed = originalSpeed * runMultiplier;


        yield return new WaitForSeconds(0.1f);
        if (distance > 1)
            agent.SetDestination(target.position);
     //   else
       //     agent.SetDestination(agent.transform.position);
        // active = true;
        StopCoroutine(chaseTarget());
    }

        IEnumerator chaseLastLocationTarget()
    {

        agent.speed = originalSpeed * 1.5f;


        if (agent.transform.position == agent.destination)
        {
            yield return new WaitForSeconds(2f);
            patrol = true;
        }
        yield return new WaitForSeconds(0.1f);
        // active = true;
        StopCoroutine(chaseLastLocationTarget());
    }

        IEnumerator attack()
    {
      //  agent.Stop();
        active = false;
        animator.CrossFade("Attack", 0.3f);
        yield return new WaitForSeconds(0.1f);
        hitBox.enabled = true;
        yield return new WaitForSeconds(0.1f);
        hitBox.enabled = false;
     //   agent.Resume();
        yield return new WaitForSeconds(1f);
        active = true;
        StopCoroutine(attack());
    }

        IEnumerator isHit()
    {
   //     Debug.Log("OUCH");
        active = false;
        animator.CrossFade("Is Hit", 0.3f);
        yield return new WaitForSeconds(0.2f);
        agent.Stop();
        yield return new WaitForSeconds(1.5f);
        agent.Resume();
        active = true;
        StopCoroutine(isHit());
    }

        IEnumerator patrolArea()
    {

        agent.speed = originalSpeed;
//Debug.Log(lostValue + "This is the value");

        float distance = Vector3.Distance(agent.transform.position, agent.destination);

        if (distance < 0.02f)
        {
            active = false;
            agent.Stop();
            int newWaypoint = Random.RandomRange(0, waypointCount);
            agent.SetDestination(waypoints.waypoints[newWaypoint].position);
            yield return new WaitForSeconds(2f);
            agent.Resume();
            yield return new WaitForSeconds(4f);
            active = true;

        }

        //Debug.Log("Patrol Continued");
        StopCoroutine(patrolArea());
    }

        IEnumerator patrolRoom()
    {
        agent.speed = originalSpeed;

        float distance = Vector3.Distance(agent.transform.position, agent.destination);

        if (distance < 0.02f)
        {
            active = false;
            agent.isStopped = true;
            agent.SetDestination(roomWaypoints.waypoints[roomWaypointDestinationCount].position);
            yield return new WaitForSeconds(2f);
            agent.isStopped = false;
            yield return new WaitForSeconds(4f);
            active = true;
            roomWaypointDestinationCount++;
        }

        if(roomWaypointDestinationCount >= roomWaypoints.waypoints.Length)
        {
            roomWaypointDestinationCount = 0;
            isInRoom = false;
            patrol = true;
        }
        StopCoroutine(patrolRoom());
    }

        IEnumerator resetPath()
    {
        active = false;
        agent.Stop();
        changeWaypoint();
        yield return new WaitForSeconds(3f);
        agent.Resume();
        active = true;
        StopCoroutine(resetPath());
    }

        void changeWaypoint()
    {
        int newWaypoint = Random.RandomRange(0, waypointCount);
        agent.SetDestination(waypoints.waypoints[newWaypoint].position);
        currentWaypoint = newWaypoint;
    }

        void eyesManager()
    {
        RaycastHit hit;
        Vector3 screenPoint = eyes.WorldToViewportPoint(target.position);
        if (screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1)
        {
            if (Physics.Linecast(eyes.transform.position, target.GetComponentInChildren<Renderer>().bounds.center, out hit))
            {
                if (hit.transform.tag == "Player")
                {

                    StopCoroutine(patrolRoom());
                    StopCoroutine(patrolArea());

                    chase = true;
                    patrol = false;
                    lostPlayer = false;
                    lostValue = 0;
               //     Debug.Log("FOUND YOU" + lostValue);
                }
                else
                {
                    if (lostValue > 5)
                    {
                        lostPlayer = true;
                  //      Debug.Log("LOST YOU" + lostValue);
                    }
                }
            }
        }
        //Look at Player
        if (eyes.GetComponent<Looker>() != null)
        {
            if (chase)
            {
                eyes.GetComponent<Looker>().enabled = true;
            }
            else
            {
                eyes.GetComponent<Looker>().enabled = false;
            }
        }

    }

        void AINavigationManager()
    {
        distance = Vector3.Distance(agent.transform.position, target.transform.position);
    //    Debug.Log(roomWaypointDestinationCount);
        if (distance < 2)
            lostValue = 0;
        else
            lostValue += 0.04f;

        if (lostPlayer && chase)
        {
            chase = false;
            patrol = false;
        }

        if (chase && !patrol && active)
        {
            // Debug.Log("IS CHASING");
            if (distance > 3f)
                StartCoroutine(chaseTarget());
            else
                StartCoroutine(attack());

            if(damageSystem.isHit())
            if(!isInjured1 && health < (750))
            {
               //     Debug.Log("750");
                isInjured1 = true;
                StartCoroutine(isHit());
            }
            else if (!isInjured2 && health < (500))
            {
             //       Debug.Log("500");
                    isInjured2 = true;
                StartCoroutine(isHit());
            }
            else if (!isInjured3 && health < (250))
            {
           //         Debug.Log("250");
                    isInjured3 = true;
                StartCoroutine(isHit());
            }

        }

        else if (patrol && !chase && active)
        {
            StartCoroutine(patrolArea());
        }

        else if (!patrol && !chase && active && !isInRoom)
        {
            StartCoroutine(chaseLastLocationTarget());
        }

        else if (!patrol && !chase && active && isInRoom)
        {
            StartCoroutine(patrolRoom());
        }

        // Debug.Log("Active : " + active);

        //Sets the A.I.
        if (agent.remainingDistance > agent.stoppingDistance)
            character.Move(agent.desiredVelocity, false, false);
        else
            character.Move(Vector3.zero, false, false);

        //Sees the Player
        eyesManager();

    }

        void AIHealthManager()
    {
        if (damageSystem.isHit())
        {
            health -= damageSystem.damageTaken();
            chase = true;
            patrol = false;
            agent.SetDestination(target.transform.position);
            //Debug.Log("DAMAGE HIT : " + health);
        }
        if (health <= 0)
        {
            die();
        }
    }
  
        void die()
    {

        if (hasEffects)
        {
            for(int i = 0;i < effects.Length; i++)
            {
                Destroy(effects[i]);
            }
        }

        if (generateSomethingOnDeath && activeDeath)
        {
            activeDeath = false;
            generatedItem.SetActive(true);
            //GameObject newgenItem = GameObject.Instantiate(generatedItem);
           // newgenItem.transform.position = generateLocation.position;
            //  Destroy(generateLocation);
        }


        if (GetComponent<CharacterController>() != null)
        GetComponent<CharacterController>().enabled = false;
        if (GetComponent<UnityEngine.AI.NavMeshAgent>() != null)
            GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        if (GetComponent<ThirdPersonCharacter>() != null)
            GetComponent<ThirdPersonCharacter>().enabled = false;

        foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
            if(GetComponentsInChildren<Rigidbody>() != null)
            rb.isKinematic = false;

        animator.enabled = false;
        transform.DetachChildren();
        Destroy(gameObject,0.2f);
    }

        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        public bool isNearPlayer(int x)
        {
        float distance = Vector3.Distance(agent.transform.position, target.transform.position);
        return distance < x;
        }

        public bool isChasing()
        {
        return chase;
        }

        public bool isSearching()
        {
        return !chase && !patrol;
        }

        private void OnTriggerEnter(Collider other)
        {
        if (other.GetComponent<Room>() != null)
        {
            isInRoom = true;
            roomWaypoints = other.GetComponent<Room>().waypoints;
        }
        }

        private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Room>() != null)
        {
            isInRoom = false;
            roomWaypoints = null;
        }
    }

}
