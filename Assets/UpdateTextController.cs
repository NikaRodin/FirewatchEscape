using UnityEngine;
using UnityEngine.UI;

public class KeypadController : MonoBehaviour
{
    public Text inputField;
    public SafeDoorController safeDoorController;
    public HingeJoint safeDoorHingeJoint;
    public GameObject protectedObject;

    public int maxCharacters = 6;
    public string correctPin = "1234";

    private bool messageDisplayed = false;

    public void AddCharacter(string character)
    {
        if (safeDoorHingeJoint.angle > 2) return;

        if (messageDisplayed) {
            this.ClearAll();
            inputField.color = Color.red;
            messageDisplayed = false;
        }

        if (inputField.text.Length < maxCharacters)
        {
            inputField.text += character;
        }
    }

    public void ClearAll()
    {
        if (safeDoorHingeJoint.angle > 2) return;

        inputField.text = string.Empty;
    }

    public void ClearLastCharacter()
    {
        if (safeDoorHingeJoint.angle > 2) return;

        if (messageDisplayed) 
        {
            ClearAll();
        }
        else if (inputField.text.Length > 0)
        {
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
        }
    }

    public void CheckPin()
    {
        if (safeDoorHingeJoint.angle > 2) return;

        if (inputField.text == correctPin)
        {
            inputField.text = "OPEN";
            inputField.color = Color.green;
            safeDoorController.UnlockDoor();
            //protectedObject.SetActive(true);
        }
        else
        {
            inputField.text = "LOCKED";
            inputField.color = Color.red;
            safeDoorController.LockDoor();
            //protectedObject.SetActive(false);
        }

        messageDisplayed = true;
    }
}