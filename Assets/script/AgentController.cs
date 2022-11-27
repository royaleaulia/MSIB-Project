using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    // Start is called before the first frame update
    public float knockRadius = 20.0f;


    IEnumerator PlayKnock()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                this.GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(hit.point);
            }
        }

        if (Input.GetKey("space"))
        {
            StartCoroutine(PlayKnock());
            //Create the sphere collider
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, knockRadius);
            for (int i = 0; i < hitColliders.Length; i++)// Check the collisions
            {
                // If it's a guard, trigger the Investigation!
                hitColliders[i].GetComponent<GuardController>().InvestigatePoint(this.transform.position);
            }
        }

    }
}
