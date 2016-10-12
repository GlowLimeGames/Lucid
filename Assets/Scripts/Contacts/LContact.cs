/*
 * Author: Joseph Gillen
 * Initial Date: 12th October 2016
 * Description: This class is used to create contacts
 * Initialization: To initialize a contact using JSON use the follow,
 * instanceOfLContact.InitializeContactWithJson(jsonFileName);
 */

using UnityEngine;

[System.Serializable]
public class LContact {
    public string _ID; // Some way to reference contact
    public string _Name; // Name to be displayed on screen
    public int _MessagesRecieved; // The total number of messages a contact has recieved
    public int _MessagesSent; // The total number of messsages a contact has sent
    public Sprite _ContactImage; // An image to represent a contact
    public bool _isMessageUnread; // A bool to represent if a contacts message is sitting unread
    public bool _isContact; // Is contact known to the player, .i.e. not annoymous


    // Getters and Setters
    public string ID {
        get { return _ID; }
        set { _ID = value; }
    }
    public string Name {
        get { return _Name; }
        set { _Name = value; }
    }
    public int GetMessagesRecieved {
        get { return _MessagesRecieved; }
        set { _MessagesRecieved = value; }
    }
    public int GetMessagsSent {
        get { return _MessagesSent; }
        set { _MessagesSent = value; }
    }
    public Sprite ContactImage
    {
        get { return _ContactImage; }
        set { _ContactImage = value; }
    }
    public bool IsMessageUnread
    {
        get { return _isMessageUnread; }
        set { _isMessageUnread = value; }
    }
    public bool IsContact
    {
        get { return _isContact; }
        set { _isContact = value; }
    }
    // A function to load JSON data into a contact object
    public void InitializeContactWithJson(string data)
    {
        JsonUtility.FromJson<LContact>(data);
    }
    // A function to load JSON data into an existing contact object
    public void UpdateContactWithJson(string data)
    {
        JsonUtility.FromJsonOverwrite(data, this);
    }
    // A function to return a stringified version of LConacts JSON
    public string GetAsJson()
    {
        return JsonUtility.ToJson(this);
    }
}
