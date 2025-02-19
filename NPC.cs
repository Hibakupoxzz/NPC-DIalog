using UnityEngine;

public class NPC : MonoBehaviour
{
    public Dialog[] dialogLines;  // Array dialog berbalas
    private int currentLine = 0;
    private DialogManager dialogManager;
    private bool playerNearby = false;

    void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogManager.IsDialogShowing())
            {
                ShowNextLine();
            }
            else
            {
                ShowCurrentLine();
            }
        }
    }

    void ShowCurrentLine()
    {
        if (currentLine < dialogLines.Length)
        {
            var dialog = dialogLines[currentLine];
            dialogManager.ShowDialog(dialog.speaker, dialog.line);
        }
    }

    void ShowNextLine()
    {
        currentLine++;
        if (currentLine < dialogLines.Length)
        {
            ShowCurrentLine();
        }
        else
        {
            dialogManager.HideDialog();
            currentLine = 0; // Reset dialog
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            dialogManager.HideDialog();
        }
    }
}
