using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CommunicationsPanel : MonoBehaviour
{
    public PilotScreen pilotScreen;
    public TMProTypewriter typewriter;
    public TextMeshPro textMesh;

    public bool allowKeyboard;
    public bool playerRequestDialogueInput;

    private enum ScreenState { OFFLINE, REBOOTING, WORKING};
    private ScreenState state = ScreenState.OFFLINE;

    private TerminalDialogue[] dialogue1;

    public void Selected()
    {
        pilotScreen.EnableKeyboard(true);
    }

    public void Awake()
    {
        dialogue1 = new TerminalDialogue[18];

        dialogue1[0] = new TerminalDialogue(actorType.ENGINEER, "Hello? Is there anybody there?", 1f);
        dialogue1[1] = new TerminalDialogue(actorType.PLAYER, "This is your captain" , 0f);
        dialogue1[2] = new TerminalDialogue(actorType.ENGINEER, "What", 0.5f);
        dialogue1[3] = new TerminalDialogue(actorType.ENGINEER, "Where am I?", 1f);
        dialogue1[4] = new TerminalDialogue(actorType.ENGINEER, "You need to send help", 1f);
        dialogue1[5] = new TerminalDialogue(actorType.PLAYER, "The left engine has suffered damage, I need you to repair it immediately", 0f);
        dialogue1[6] = new TerminalDialogue(actorType.ENGINEER, "I can't feel my legs", 2f);
        dialogue1[7] = new TerminalDialogue(actorType.ENGINEER, "Please send someone", 1f);
        dialogue1[8] = new TerminalDialogue(actorType.PLAYER, "We're on a collision course with a planet. I need you to repair the engine right now.", 0f);

        dialogue1[9] = new TerminalDialogue(actorType.ENGINEER, "I can't remember anything", 5f);
        dialogue1[10] = new TerminalDialogue(actorType.ENGINEER, "Why can't I?", 1f);

        dialogue1[11] = new TerminalDialogue(actorType.PLAYER, "That isn't important right now. Get to work on the engine or the both of us will die", 0f);

        dialogue1[12] = new TerminalDialogue(actorType.ENGINEER, "Send someone please", 6f);

        dialogue1[13] = new TerminalDialogue(actorType.ENGINEER, "There's someone watching me", 3f);

        dialogue1[14] = new TerminalDialogue(actorType.ENGINEER, "please", 4f);

        dialogue1[15] = new TerminalDialogue(actorType.PLAYER, "I don't think there isn't anyone else alive onboard", 0f);
        dialogue1[16] = new TerminalDialogue(actorType.PLAYER, "You need to repair the engine asap", 0f);
        dialogue1[17] = new TerminalDialogue(actorType.PLAYER, "Engineer? Are you there?", 0f);


        StartCoroutine(Startup());
    }

    public void KeyboardPressed()
    {
        switch (state)
        {
                case (ScreenState.OFFLINE):
                {
                    allowKeyboard = false;
                    pilotScreen.EnableKeyboard(false);
                    StartCoroutine(Reboot());
                    state = ScreenState.REBOOTING;
                    break;
                }
                case (ScreenState.REBOOTING):
                {
                    allowKeyboard = false;
                    pilotScreen.EnableKeyboard(false);

                    state = ScreenState.WORKING;
                    break;
                }
                case ScreenState.WORKING:
                {
                    playerRequestDialogueInput = true;
                    pilotScreen.EnableKeyboard(false);
                    allowKeyboard = false;
                    break;
                }
        }
    }

    public IEnumerator Startup()
    {
        yield return new WaitForSeconds(typewriter.Type("", ". . .", 0.02f));
        yield return new WaitForSeconds(0.75f);
        yield return new WaitForSeconds(typewriter.Type("", "5sa./ ///a##2 aax72/n1   as__2z", 0.02f));
        yield return new WaitForSeconds(0.25f);
        yield return new WaitForSeconds(typewriter.Type("", "<size=34>Internal Ship Communication is in <color=#990c00>emergency shutdown</color></size>\n\n <size=40>Reboot? (Y/N)</size>", 0.02f));

        allowKeyboard = true;
        pilotScreen.EnableKeyboard(true);
    }

    public IEnumerator Reboot()
    {
        yield return new WaitForSeconds(0.25f);
        yield return new WaitForSeconds(typewriter.Type("", "<size=32>Rebooting</size>", 0.02f));
        yield return new WaitForSeconds(typewriter.Type("<size=32>Rebooting</size>", " . . .", 0.35f));

        textMesh.alignment = TextAlignmentOptions.Left;

        yield return new WaitForSeconds(typewriter.Type("", "<size=40>Terminal Status:</size><size=24>" +
            "\n 1) Medical bay............<color=#dd8323>[OFFLINE]</color>" +
            "\n 2) Stowage area...........<color=#d1af19>[UNRESPONSIVE]</color>" +
            "\n 3) Stasis Array...........<color=#dd8323>[OFFLINE]</color>" +
            "\n 4) Right Enginnering bay..<color=#dd8323>[OFFLINE]</color>" +
            "\n 5) Left Engineering bay...<color=#8feb34>[ONLINE]</color>" +
            "\n 6) Central Crawlspace.....<color=#d1af19>[UNRESPONSIVE]</color></size>", 0.02f));

        yield return new WaitForSeconds(1.5f);

        textMesh.alignment = TextAlignmentOptions.Center;

        yield return new WaitForSeconds(typewriter.Type("", "<size=50><color=#d1af19>Alert</color></size>\n<size=28>Terminal 5 (Left Engineering Bay) is requesting connection</size>\n\n Accept? (Y/N)", 0.02f));
        allowKeyboard = true;
        pilotScreen.EnableKeyboard(true);
  
        StartCoroutine(EngineerDialogue());
    }

    public IEnumerator EngineerDialogue()
    {
        bool showingDialogue = true;
        int iteration = 0;

        string megaString = "<size=28>Terminal #5 Comms:</size>";

        while (showingDialogue)
        {
            TerminalDialogue dialogue = dialogue1[iteration];

            if (dialogue.actor == actorType.ENGINEER)
            {
                yield return new WaitForSeconds(dialogue.waitTime);

                string formatted = "\n<size=20><color=#d1af19>T5 > </color></size>" + dialogue.content;

                megaString += formatted;

                textMesh.text = megaString;

                iteration++;
            }

            if (dialogue.actor == actorType.PLAYER )
            {
                if (playerRequestDialogueInput)
                {
                    // Show the dialogue being entered
                    playerRequestDialogueInput = false;

                    string formatted = "\n<size=20><color=#8feb34>Pilot > </color>" + dialogue.content + "</size>";

                    yield return new WaitForSeconds(typewriter.Type(megaString, formatted, 0.02f));

                    megaString += formatted;
                    iteration++;
                }
                else
                {
                    // Wait for the player to hit the keyboard
                    pilotScreen.EnableKeyboard(true);
                    allowKeyboard = true;
                }
                
            }

            yield return new WaitForSeconds(0.1f);
        }
                
        }
}

public enum actorType { PLAYER, ENGINEER }

public class TerminalDialogue
{
    public actorType actor;
    public string content;
    public float waitTime;

    public TerminalDialogue(actorType actor, string content, float waitTime)
    {
        this.actor = actor;
        this.content = content;
        this.waitTime = waitTime;
    }   
}
