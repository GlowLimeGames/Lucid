/* 
 * Created by: Kevin Wang
 * Description: Stores some meta-data about the individual message screens
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LConversation {
	public float barLocation;
	public LText[] totalConversation = new LText[1];
	public int numberOfMessages = 0;

	public void addMessage(LText message){
		if (numberOfMessages == totalConversation.Length) {
			LText[] newConversation = new LText[totalConversation.Length * 2];
			for (int i = 0; i < numberOfMessages; i++)
				newConversation [i] = totalConversation [i];
			totalConversation = newConversation;
		}
		totalConversation [numberOfMessages++] = message;
	}
}


