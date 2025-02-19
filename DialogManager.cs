using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;     // Panel dialog
    public TMP_Text dialogText;      // Teks dialog
    public TMP_Text speakerText;     // Nama pembicara
    private bool isShowing = false;  // Status dialog

    void Start()
    {
        dialogBox.SetActive(false); // Sembunyikan dialog di awal
    }

    public void ShowDialog(string speaker, string message)
    {
        isShowing = true;
        dialogBox.SetActive(true);
        speakerText.text = speaker;  // Menampilkan nama pembicara
        dialogText.text = message;  // Menampilkan teks dialog
    }

    public void HideDialog()
    {
        isShowing = false;
        dialogBox.SetActive(false);
    }

    public bool IsDialogShowing()
    {
        return isShowing;
    }
}
