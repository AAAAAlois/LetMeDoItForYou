using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    Chips chips;
    BgmPlayer bgmPlayer;

    public float lookRadius = 10f;
    public float HP = 100f;


    Transform target;
    NavMeshAgent agent;

    AudioSource enemyAudio;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        //target = GameManager.instance.player.transform;
        target = FindObjectOfType<PlayerObj>().transform;
        //transform.rotation = Quaternion.Euler(-90, 0, 0);

        chips = FindObjectOfType<Chips>();

        enemyAudio = GetComponent<AudioSource>();
        //audio.Pause();

        bgmPlayer = FindObjectOfType<BgmPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        target = FindObjectOfType<PlayerObj>().transform;

        if (target)
        {
            float distance = Vector3.Distance(target.position, transform.position);

            if (distance <= lookRadius && chips.isSuccess == false)
            {
                agent.SetDestination(target.position);
                FaceTarget();
                if (!enemyAudio.isPlaying)
                {
                    enemyAudio.Play();
                }

                bgmPlayer.GetComponent<AudioSource>().Pause();
            }
            else
            {
                enemyAudio.Stop();
                bgmPlayer.GetComponent<AudioSource>().UnPause();
            }

            if (HP <= 0)
            {
                Destroy(gameObject);
            }
        }

      

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime * 5.0f);
        //transform.forward = target.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            GameManager.instance.HP--;
            Debug.Log("Enter Player");
        }

        Debug.Log(collision.transform.name);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            GameManager.instance.HP--;
        }
        //Debug.Log(collision.transform.name);
    }
}
