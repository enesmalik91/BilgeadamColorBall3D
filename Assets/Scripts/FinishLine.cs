using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Complete");

            GameManager.Instance.isFinish = true;

            StartCoroutine(UIManager.Instance.OpenCompletePanel());
        }
    }
}
