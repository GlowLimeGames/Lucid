/* Author: Kevin Wang */

using UnityEngine;
using System.Collections;

public class ProgressResponse {

	public int currentID;
	public int currentChoice;
	public ChooseResponse allMessages;

	public ProgressResponse(LText[] texts){
		allMessages = new ChooseResponse (texts);
		currentID = 1;
		currentChoice = 1;
	}

	public void playerInput(int ID, string choice){
		int first = ID;
		int second = choice.ToCharArray()[0]-65;
		currentID = first;
		currentChoice = second;
		allMessages.getResponses (ID, choice);
		//display the message here
	}
}

