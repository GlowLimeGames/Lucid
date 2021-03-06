/* Author: Kevin Wang */

using UnityEngine;
using System.Collections;

public class ChooseResponse {

	private string[][][] responseIDs;

	public ChooseResponse(LText[] texts){
		for (int i = 0; i < texts.Length; i++) {
			int first = texts [i].IDNum;
			int second = texts [i].choice.ToCharArray () [0] - 65;
			responseIDs [first] [second] = texts [i].Responses;
		}
	}

	public string[] getResponses(int ID,string choice){
		return responseIDs [ID][choice.ToCharArray()[0]-65];
	}
}
