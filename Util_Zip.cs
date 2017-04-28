using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;
using UnityEngine;
using System.Collections;

public static class Util_Zip
{
	private static string Pd = "^$*&(!";
	public static string CreateZip(string zipPath, string dirPath)
	{
		FastZip zip = new FastZip();
		zip.Password = Pd;
		zip.CreateZip(zipPath, dirPath, true, ".*\\.(bytes)$");
		return zipPath;
	}
	public static string ExtractZip(string zipPath, string dirPath)
	{
		FastZip zip = new FastZip();
		zip.Password = Pd;
		zip.ExtractZip(zipPath, dirPath, "");
		return dirPath;
	}
	public static string ExtractZip(Stream zipStream, string dirPath)
	{
		FastZip zip = new FastZip();
		zip.Password = Pd;
		zip.ExtractZip(zipStream, dirPath, FastZip.Overwrite.Always, null, "", "", false, true);
		return dirPath;
	}
}
