using UnityEngine;
using UnityEngine.UI;

public class StoneText : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;

    private PlayerInputHandler playerInputHandler;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerInputHandler = player.GetComponent<PlayerInputHandler>();
    }

    private void Update()
    {

        if (playerInRange)
        {
            if (playerInputHandler.InteractInput)
            {
                if (!dialogBox.activeInHierarchy)
                {
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                }
            }
            else
            {

                dialogBox.SetActive(false);
            }
        }
        else
        {  
            dialogBox.SetActive(false);
            playerInputHandler.UseInteractInput();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
