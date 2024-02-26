using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Node[] ConnectsTo;
    public Node[] ConnectsTo2;

    private void OnDrawGizmos()
    {
        foreach (Node n in ConnectsTo)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, (n.transform.position - transform.position).normalized * 2);
        }

        foreach (Node n in ConnectsTo2)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, (n.transform.position - transform.position).normalized * 2);
        }
    }

}
