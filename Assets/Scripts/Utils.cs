using UnityEngine;
using System.Collections;

public static class Utils {

	public static T RandElement<T>(this T[] ary) where T:class {
		return ary[Random.Range(0, ary.Length)];
	}
}
