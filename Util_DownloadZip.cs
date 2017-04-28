using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public class Util_DownloadZip : MonoBehaviour
{
	public void DownloadTo(string url, string targetDirectory, Action<string> failedDel, Action completeDel)
	{
		StartCoroutine(DownloadURL(url, targetDirectory, failedDel, completeDel));
	}
	private IEnumerator DownloadURL(string url, string targetDirectory, Action<string> failedDel, Action completeDel)
	{
		WWW www = new WWW(url);
		yield return www;
		if (www.error == null)
		{
			try
			{
				Util_Zip.ExtractZip(new MemoryStream(www.bytes), targetDirectory);
				if (completeDel != null)
				{
					completeDel();
				}
			}
			catch (Exception ex)
			{
				if (failedDel != null)
				{
					failedDel("Util_Zip.ExtractZip error:" + ex.Message);
				}
			}
		}
		else
		{
			if (failedDel != null)
			{
				failedDel(www.error + "\r\n" + url);
			}
		}
	}
}
