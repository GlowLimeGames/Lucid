/*
 * Author(s): Isaiah Mann
 * Description: Handles tracking progress in the game's narrative
 */

using UnityEngine;
using System.Collections;

public class LStoryController : SingletonController<LStoryController>, IStoryController {
	public LTime CurrentTime = LTime.Default;

}
