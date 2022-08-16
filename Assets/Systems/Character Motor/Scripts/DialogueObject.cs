using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;



namespace UnityStandardAssets.Characters.FirstPerson
{
    [Serializable]

    public class DialogueOBJ
    {
        public string[] Dialogues;
        public string CharacterName;

    }

    public class DialogueObject : MonoBehaviour
    {
        public PlayerData data;

        public TextMeshProUGUI nameText;
        public TextMeshProUGUI DialogueText;
        public CharacterMotor rigid;

        private QuestObj obj;



        private int currentDialogueNum = 0;
        private DialogueOBJ curDialogue = null;

        [Header("Dialogue objects")]

        public DialogueOBJ dialgoue1;
        public DialogueOBJ dialgoue1o5;

        [Header("NPCS")]
        public NPC1 NPC1;

        private void Awake()
        {
            obj = FindObjectOfType<QuestObj>();

        }


        private void OnEnable()
        {

            switch (data.DialogueNumber)
            {
                case 1:
                    PlayDialogue(dialgoue1);
                    curDialogue = dialgoue1;
                    break;

                case 1.5f:
                    PlayDialogue(dialgoue1o5);
                    curDialogue = dialgoue1o5;
                    break;
            }
        }



        void PlayDialogue(DialogueOBJ tempobj)
        {
            nameText.text = tempobj.CharacterName;
            if (currentDialogueNum < tempobj.Dialogues.Length)
            {
                DialogueText.text = tempobj.Dialogues[currentDialogueNum];
            }
            else
            {
                rigid.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                switch (data.DialogueNumber)
                {
                    case 1:
                        NPC1.hasTalked = true;
                        NPC1!.isInDialogue = false;
                        obj.StartNewQuest(obj.questObjs[0]);
                        break;
                    case 1.5f:
                        NPC1!.isInDialogue = false;
                        break;

                }
                data.DialogueNumber = 0;
                currentDialogueNum = 0;
                curDialogue = null;
                this.gameObject.SetActive(false);
                //end
            }
        }


        public void next()
        {
            if (curDialogue != null)
            {
                currentDialogueNum++;
                PlayDialogue(curDialogue);
            }
        }
    }
}
