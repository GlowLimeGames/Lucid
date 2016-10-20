/*
 * Author(s): Isaiah Mann
 * Description: Used to load JSON
 */

using UnityEngine;
using System.Collections;

public class LJsonController : Controller, IJsonController {

	public T Parse<T> (string json) {
		return JsonUtility.FromJson<T>(json);
	}

}
