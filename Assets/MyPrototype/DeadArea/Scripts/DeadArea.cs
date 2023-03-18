using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadArea : MonoBehaviour
{

    [SerializeField]
    GameObject GameOverUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<FirstPersonMovement>().enabled = false;

            other.gameObject.GetComponentInChildren<FirstPersonLook>().sensitivity = 0;
            //other.gameObject.GetComponentInChildren<FirstPersonLook>().enabled = false;
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            GameOverUI.SetActive(true);
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
