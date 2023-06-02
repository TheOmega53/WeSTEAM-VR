using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDialogues : MonoBehaviour
{
    // Start is called before the first frame update

    public DialogueTrigger DialogueTrigger;
    private void Start()
    {
        DialogueTrigger.TriggerDialogue();
    }
}
